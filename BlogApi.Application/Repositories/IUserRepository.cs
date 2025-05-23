using BlogApi.Application.Dtos;
using BlogApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync(int pageNumber, int pageSize);
        Task AddAsync(User user);
        void Update(User user);
        void Remove(User user);
    }
}
