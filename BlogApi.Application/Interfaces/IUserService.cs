using BlogApi.Application.Dtos;
using BlogApi.Application.Dtos.UserDTO;
using BlogApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserReadDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<UserReadDto>> GetAllAsync(int pageNumber, int pageSize);
        Task<ResponseDto> CreateAsync(UserCreateDto dto);
        Task<ResponseDto> UpdateAsync(Guid id, UserUpdateDto dto);
        Task<ResponseDto> DeleteAsync(Guid id);

    }
}
