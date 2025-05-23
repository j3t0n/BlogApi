using BlogApi.Application.Dtos;
using BlogApi.Application.Dtos.UserDTO;
using BlogApi.Application.Interfaces;
using BlogApi.Application.Repositories;
using BlogApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlogApi.Application.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IApplicationDbContext _context;

        public UserService(IUserRepository userRepository, IApplicationDbContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }

        public async Task<UserReadDto?> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            return new UserReadDto
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                SettingsJson = user.SettingsJson
            };
        }

        public async Task<IEnumerable<UserReadDto>> GetAllAsync(int pageNumber, int pageSize)
        {
            var users = await _userRepository.GetAllAsync(pageNumber, pageSize);

            var dtos = new List<UserReadDto>();
            foreach (var user in users)
            {
                dtos.Add(new UserReadDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateOfBirth = user.DateOfBirth,
                    SettingsJson = user.SettingsJson
                });
            }
            return dtos;
        }
        public async Task<ResponseDto> CreateAsync(UserCreateDto dto)
        {
            var exists = _context.Users.Where(x => x.Username == dto.Username).FirstOrDefault();
            if (exists!=null)
            {
                return new ResponseDto { Success = false, Message = "User with this username already exists" };
            }
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = dto.Username,
                FirstName = dto.FirstName,
                PasswordHash=dto.Password,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                SettingsJson = JsonSerializer.Serialize(dto.SettingsJson ?? new Dictionary<string, string>())
            };

            await _userRepository.AddAsync(user);
            await _context.SaveChangesAsync();

            return new ResponseDto { Success = true, Message = "User created successfully." };
        }

        public async Task<ResponseDto> UpdateAsync(Guid id, UserUpdateDto dto)
        {
            var existing = await _userRepository.GetByIdAsync(id);
            if (existing is null)
                return new ResponseDto { Success = false, Message = "User not found." };

            existing.FirstName = dto.FirstName;
            existing.LastName = dto.LastName;
            existing.DateOfBirth = dto.DateOfBirth;
            existing.SettingsJson = dto.SettingsJson;

            _userRepository.Update(existing);
            await _context.SaveChangesAsync();

            return new ResponseDto { Success = true, Message = "User updated successfully." };
        }

        public async Task<ResponseDto> DeleteAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user is null)
                return new ResponseDto { Success = false, Message = "User not found." };

            _userRepository.Remove(user);
            await _context.SaveChangesAsync();

            return new ResponseDto { Success = true, Message = "User deleted successfully." };
        }


    }
}
