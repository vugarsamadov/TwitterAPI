using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.Abstractions;
using Twitter.Business.Dtos.Post;
using Twitter.Business.Dtos.User;
using Twitter.Core.Entities;

namespace Twitter.Business.Concreate
{
    public class UserService : IUserService
    {
        public IPostsService _postsService { get; }
        private UserManager<User> _userManager { get; }
        private IMapper _mapper { get; }

        public UserService(IPostsService postsService,UserManager<User> userManager,IMapper mapper )
        {
            _postsService = postsService;
            _userManager = userManager;
            _mapper = mapper;
        }


        public async Task<string> Create(UserRegisterDto dto)
        {
            var user = _mapper.Map<User>(dto);

            var result = await _userManager.CreateAsync(user,dto.Password);

            return user.Id.ToString();
        }

        public async Task<string> Login(UserLoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                throw new Exception("User not found");
            var result = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (result)
                return user.Id.ToString();
            return null;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = _mapper.Map<IEnumerable<UserDto>>(await _userManager.Users.ToListAsync());
            return users;
        }

        public async Task<UserDto> GetByIdAsync(int Id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == Id);
            if (user == null)
                throw new Exception("User not found");
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> UpdateAsync(UserUpdateDto dto)
        {
            if (await UserEmailExists(dto.Email) || await UserUserNameExists(dto.UserName))
            {
                throw new Exception("Entered mail or username already registered!");
            }

            var user = _mapper.Map<User>(dto);
            await _userManager.UpdateAsync(user);
            return _mapper.Map<UserDto>(user);
        }

        
        public async Task DeleteAsync(int id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                throw new Exception("User not found");
            await _userManager.DeleteAsync(user);
        }

        public async Task<bool> UserEmailExists(string email)
        {
            return await _userManager.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> UserUserNameExists(string username)
        {
            return await _userManager.Users.AnyAsync(u => u.UserName == username);
        }

        public async Task CreatePostAsync(int userId, PostCreateDto dto)
        {
            var user = await _userManager.Users.Include(u=>u.Posts).FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
                throw new Exception("User not found");

            await _postsService.CreateAsync(userId,dto);

        }
    }
}
