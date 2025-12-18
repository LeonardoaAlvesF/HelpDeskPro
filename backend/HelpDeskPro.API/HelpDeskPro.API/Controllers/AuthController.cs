using BCrypt.Net;
using HelpDeskPro.API.Data;
using HelpDeskPro.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace HelpDeskPro.API.Controllers
{

    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private string GerarToken(Usuario usuario)
        {
            var jwtSettings = _configuration.GetSection("Jwt");

            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
        new Claim(ClaimTypes.Role, usuario.Tipo.ToString()),
        new Claim(JwtRegisteredClaimNames.Email, usuario.Email)
    };

            var key = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(jwtSettings["Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(
                    double.Parse(jwtSettings["ExpireHours"])
                ),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private readonly AppDbContext _context;
    
    [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (usuario == null)
                return Unauthorized("Usuário ou senha inválidos");

            bool senhaValida = BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.SenhaHash);

            if (!senhaValida)
                return Unauthorized("Usuário ou senha inválidos");

            var token = GerarToken(usuario);

            return Ok(new
            {
                token
            });

        }

    }
}

