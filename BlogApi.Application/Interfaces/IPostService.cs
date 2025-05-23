using BlogApi.Application.Dtos;
using BlogApi.Application.Dtos.PostDTO;
using BlogApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.Interfaces
{
    public interface IPostService
    {

        Task<PostReadDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<PostReadDto>> GetAllAsync(int pageNumber, int pageSize);
        Task<ResponseDto> CreateAsync(PostCreateDto dto);
        Task<ResponseDto> UpdateAsync(Guid id, PostUpdateDto dto);
        Task<ResponseDto> DeleteAsync(Guid id);
    }
}
