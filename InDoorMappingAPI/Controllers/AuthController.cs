using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InDoorMappingAPI.Data;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Services;
using Microsoft.AspNetCore.Identity;
using InDoorMappingAPI.DTOs.POSTs;

namespace InDoorMappingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly JwtService _jwtService;
        private readonly IMapper _mapper;

        public AuthController(DataContext context, JwtService jwtService, IMapper mapper)
        {
            _context = context;
            _jwtService = jwtService;
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
            if (await _context.Usuarios.AnyAsync(u => u.Email == dto.Email))
                return BadRequest("Email já está em uso.");


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
    }
}
