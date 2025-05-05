using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InDoorMappingAPI.Data;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Services;
using Microsoft.AspNetCore.Identity;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.Services.Interfaces;
using System.Text.RegularExpressions;
using InDoorMappingAPI.Helpers;

namespace InDoorMappingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly JwtService _jwtService;
        private readonly IRecoveryService _recService;
        private readonly EmailService _emailService;
        private readonly IMapper _mapper;

        public AuthController(DataContext context, JwtService jwtService, IRecoveryService recService, EmailService emailService, IMapper mapper)
        {
            _context = context;
            _jwtService = jwtService;
            _recService = recService;
            _emailService = emailService;
            _mapper = mapper;
        }

        [HttpGet("register")]
        public async Task<IActionResult> Register(string nome, string email, string password, int tipoId, int mobilidadeId = 1)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Email == email))
                return BadRequest("Email já está em uso.");


            var usuario = new Usuario
            {
                Nome = nome,
                Email = email,
                TipoUsuarioId = tipoId,
                MobilidadeId = mobilidadeId,
            };

            var hasher = new PasswordHasher<Usuario>();
            usuario.PasswordHash = hasher.HashPassword(usuario, password);

            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            // carrega o TipoUsuario manualmente
            usuario.TipoUsuario = await _context.TiposUsuarios.FindAsync(tipoId);

            // agora sim, podes gerar o token
            var token = _jwtService.GenerateToken(usuario);
            return Ok(new { token });
        }
        [HttpPost("register2")]
        public async Task<IActionResult> Register(PostRegisterDTO dto)
        {
            if (!EmailValidator.IsValidIsepEmail(dto.Email))
            {
                return BadRequest("Invalid email. You must use your institutional ISEP email (7 digits + @isep.ipp.pt).");
            }

            if (await _context.Usuarios.AnyAsync(u => u.Email == dto.Email))
            {
                return BadRequest("Email already registered.");
            }               

            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                TipoUsuarioId = dto.TipoId,
                MobilidadeId = dto.MobilidadeId,
            };

            var hasher = new PasswordHasher<Usuario>();
            usuario.PasswordHash = hasher.HashPassword(usuario, dto.Password);

            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            // carrega o TipoUsuario manualmente
            usuario.TipoUsuario = await _context.TiposUsuarios.FindAsync(dto.TipoId);

            // agora sim, podes gerar o token
            var token = _jwtService.GenerateToken(usuario);
            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(PostLoginDTO dto)
        {

            var usuario = await _context.Usuarios
                .Include(u => u.TipoUsuario)
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            var hasher = new PasswordHasher<Usuario>();
            var result = hasher.VerifyHashedPassword(usuario, usuario.PasswordHash, dto.Password);

            if (result == PasswordVerificationResult.Failed)
                return Unauthorized("Credenciais inválidas.");
            
            var token = _jwtService.GenerateToken(usuario);
            return Ok(new { token });
        }
        [HttpPost("recover")]
        public async Task<IActionResult> RecoverAccount([FromBody] PostRecoverAccountDTO dto)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
                return NotFound("User with this email does not exist.");

            var token = await _recService.GenerateRecoveryToken(user.UsuarioId);

            await _emailService.SendRecoveryTokenEmail(user.Email, token);

            return Ok("Recovery token has been sent to your email.");
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] PostResetPasswordDTO dto)
        {
            var recoveryToken = await _recService.GetValidToken(dto.Token);
            if (recoveryToken == null)
                return BadRequest("Invalid or expired recovery token.");

            var user = await _context.Usuarios.FindAsync(recoveryToken.UserId);
            if (user == null)
                return NotFound("User not found.");

            var hasher = new PasswordHasher<Usuario>();
            user.PasswordHash = hasher.HashPassword(user, dto.NewPassword);

            await _context.SaveChangesAsync();
            await _recService.InvalidateToken(recoveryToken);

            return Ok("Password has been reset successfully.");
        }
        [HttpGet("validate-token")]
        public async Task<IActionResult> ValidateToken([FromQuery] string token)
        {
            var recoveryToken = await _recService.GetValidToken(token);
            if (recoveryToken == null)
                return BadRequest("Invalid or expired recovery token.");

            return Ok("Token is valid.");
        }
    }
}
