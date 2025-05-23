using BlogApi.Application.Dtos.AuthDto;
using BlogApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        Task<LoginResponseDto> GenerateToken(string username,string password);
    }
}
