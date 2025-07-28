using Localiza_Aplicattion.Data;
using Localiza_Aplicattion.DTO.DTO_Usuario;
using Localiza_Aplicattion.Interfaces;
using Localiza_Aplicattion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Localiza_Aplicattion.Services
{
    public class AuthService : IAutencticaService
    {
        private readonly DataContexto _context;
        private readonly IConfiguration _configuration;

        public AuthService(DataContexto context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<Usuario?> Register(RegistroDTO registerDto)
        {
            // Verifica se o email já existe
            if (await _context.Usuarios.AnyAsync(u => u.Email == registerDto.Email))
            {
                return null;
            }

            string senhaHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Senha);

            var usuario = new Usuario
            {
                Nome = registerDto.Nome,
                Email = registerDto.Email,
                SenhaHash = senhaHash
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<LogInResponseDTO?> Login(LogInDTO loginDto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(loginDto.Senha, usuario.SenhaHash))
            {
                return null;
            }

            // Gera o token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not configured."));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Email, usuario.Email)
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:ExpiresInMinutes"] ?? "60")),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new LogInResponseDTO
            {
                Token = tokenString,
                UserId = usuario.Id,
                UserName = usuario.Nome
            };
        }
    }
}
