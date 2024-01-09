using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.Dtos.Post;
using Twitter.Business.Dtos.User;

namespace Twitter.Business.Abstractions
{
    public interface IUserService
    {

        public Task<PostDto> CreatePostAsync(int userId,PostCreateDto dto);
        public Task<IEnumerable<PostDto>> GetAllPostsAsync(int userId);

        public Task<IEnumerable<UserDto>> GetAllAsync();
        public Task<UserDto> GetByIdAsync(int Id);
        public Task<UserDto> UpdateAsync(int id,UserUpdateDto dto);
        public Task DeleteAsync(int id);

        public Task<bool> UserEmailExists(string email);
        public Task<bool> UserUserNameExists(string username);


        public Task<string> Create(UserRegisterDto dto);
        public Task<string> Login(UserLoginDto dto);

    }
}
