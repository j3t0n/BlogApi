using BlogApi.Application.Dtos;
using BlogApi.Application.Interfaces;
using BlogApi.Application.Repositories;
using BlogApi.Domain.Entities;
using BlogApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly DbSet<Post> _dbSet;

        public PostRepository(IApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Posts;
        }

        public async Task<Post?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Post>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _dbSet
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task AddAsync(Post post)
        {
            await _dbSet.AddAsync(post);
        }

        public void Update(Post post)
        {
            _dbSet.Update(post);
        }

        public void Remove(Post post)
        {
            _dbSet.Remove(post);
        }
    }

}
