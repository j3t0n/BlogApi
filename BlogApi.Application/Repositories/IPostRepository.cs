using BlogApi.Application.Dtos;
using BlogApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.Repositories
{
    public interface IPostRepository
    {
        Task<Post?> GetByIdAsync(Guid id);
        Task<IEnumerable<Post>> GetAllAsync(int pageNumber, int pageSize);
        Task AddAsync(Post post);
        void Update(Post post);
        void Remove(Post post);
    }
}
