using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<UserDto> UpdateAsync(int id,UserUpdateDto dto)
        {


            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                throw new Exception("User not found");
            _mapper.Map(dto, user);
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

        public async Task<PostDto> CreatePostAsync(int userId, PostCreateDto dto)
        {
            var user = await _userManager.Users.Include(u=>u.Posts).FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
                throw new Exception("User not found");

            var post = await _postsService.CreateAsync(userId,dto);
            return _mapper.Map<PostDto>(post);
        }

        public async Task<IEnumerable<PostDto>> GetAllPostsAsync(int userId)
        {
            var user = await _userManager.Users.Include(u => u.Posts).FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
                throw new Exception("User not found");
        }
    }
}
