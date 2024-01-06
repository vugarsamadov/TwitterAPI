using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.Dtos.Media;
using Twitter.Business.Dtos.Post;
using Twitter.Business.Dtos.User;
using Twitter.Core.Entities;

namespace Twitter.Business.Abstractions
{
    public interface IPostsService
    {
        public Task<PostDto> GetByIdAsync(int Id);
        public Task<IEnumerable<PostDto>> GetAllAsync();
        public Task DeleteAsync(int id);
        public Task CreateAsync(int userId,PostCreateDto dto);


        public Task<IEnumerable<MediaDto>> GetMediasAsync(int postId);
        public Task AddMediaAsync(int postId,MediaCreateDto dto);
        public Task<MediaDto> GetMediaByIdAsync(int id, int mediaId);
        public Task DeleteMediaAsync(int id, int mediaId);
        public Task UpdateMediaAsync(int id, int mediaId,MediaUpdateDto dto);

    }
}
