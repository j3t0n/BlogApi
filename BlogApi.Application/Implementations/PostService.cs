using BlogApi.Application.Dtos;
using BlogApi.Application.Dtos.PostDTO;
using BlogApi.Application.Interfaces;
using BlogApi.Application.Repositories;
using BlogApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.Implementations
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IApplicationDbContext _context;

        public PostService(IPostRepository postRepository, IApplicationDbContext context)
        {
            _postRepository = postRepository;
            _context = context;
        }

        public async Task<PostReadDto?> GetByIdAsync(Guid id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null)
                return null;

            return new PostReadDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                AuthorId = post.AuthorId,
            };
        }

        public async Task<IEnumerable<PostReadDto>> GetAllAsync(int pageNumber, int pageSize)
        {
            var posts = await _postRepository.GetAllAsync(pageNumber, pageSize);
            var result = new List<PostReadDto>();

            foreach (var post in posts)
            {
                result.Add(new PostReadDto
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    AuthorId = post.AuthorId,
                    CreatedDate=post.CreatedAt,
                });
            }

            return result;
        }

        public async Task<ResponseDto> CreateAsync(PostCreateDto dto)
        {
            var post = new Post
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Content = dto.Content,
                Description=dto.Description,
                Slug=dto.Slug,
                AuthorId = dto.AuthorId,
            };

            await _postRepository.AddAsync(post);
            await _context.SaveChangesAsync();

            return new ResponseDto { Success = true, Message = "Post created successfully." };
        }

        public async Task<ResponseDto> UpdateAsync(Guid id, PostUpdateDto dto)
        {
            var existing = await _postRepository.GetByIdAsync(id);
            if (existing == null)
                return new ResponseDto { Success = false, Message = "Post not found." };

            existing.Title = dto.Title;
            existing.Content = dto.Content;

            _postRepository.Update(existing);
            await _context.SaveChangesAsync();

            return new ResponseDto { Success = true, Message = "Post updated successfully." };
        }

        public async Task<ResponseDto> DeleteAsync(Guid id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null)
                return new ResponseDto { Success = false, Message = "Post not found." };

            _postRepository.Remove(post);
            await _context.SaveChangesAsync();

            return new ResponseDto { Success = true, Message = "Post deleted successfully." };
        }
    }
}
