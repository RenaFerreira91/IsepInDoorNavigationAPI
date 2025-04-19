using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IndoorMappingAPI.Data;
using IndoorMappingAPI.Models;
using IndoorMappingAPI.Services;
using Microsoft.AspNetCore.Identity;
using IndoorMappingAPI.DTOs.POSTs;

namespace IndoorMappingAPI.Controllers
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

        [HttpPost("register")]
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

            var token = _jwtService.GenerateToken(usuario);
            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(PostLoginDTO dto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == dto.Email);

            var hasher = new PasswordHasher<Usuario>();
            var result = hasher.VerifyHashedPassword(usuario, usuario.PasswordHash, dto.Password);

            if (result == PasswordVerificationResult.Failed)
                return Unauthorized("Credenciais inválidas.");
            
            var token = _jwtService.GenerateToken(usuario);
            return Ok(new { token });
        }
    }
}
