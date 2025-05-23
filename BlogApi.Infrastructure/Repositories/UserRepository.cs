using BlogApi.Application.Dtos;
using BlogApi.Application.Interfaces;
using BlogApi.Application.Repositories;
using BlogApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly DbSet<User> _dbSet;

        public UserRepository(IApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Users;
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _dbSet
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _dbSet.AddAsync(user);
        }

        public void Update(User user)
        {
            _dbSet.Update(user);
        }

        public void Remove(User user)
        {
            _dbSet.Remove(user);
        }
    }

}
