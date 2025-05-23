using BlogApi.Application.Dtos.AuthDto;
using BlogApi.Application.Interfaces;
using BlogApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Infrastructure.Services
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration _configuration;
        private readonly IApplicationDbContext _context;

        public JwtTokenGenerator(IConfiguration configuration, IApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<LoginResponseDto> GenerateToken(string username, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
                return new LoginResponseDto { Success = false, Message = "User not found" };

            if (user.PasswordHash != password) //um using only string not hashed passwords just for testing purposes
                return new LoginResponseDto { Success = false, Message = "Wrong password" };

            var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]);


            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username)
        }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new LoginResponseDto
            {
                Success = true,
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
