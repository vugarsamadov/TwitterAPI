using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.Abstractions;
using Twitter.Business.Dtos.Media;
using Twitter.Business.Dtos.Post;
using Twitter.Core.Entities;
using Twitter.DataAccess.Abstractions.Repositories;

namespace Twitter.Business.Concreate
{
    public class PostService : IPostsService
    {
        private readonly IGenericRepository<Post> genericRepository;

        public PostService(IGenericRepository<Post> genericRepository,IMapper mapper)
        {
            this.genericRepository = genericRepository;
            Mapper = mapper;
        }

        public IMapper Mapper { get; }

        public Task AddMediaAsync(int postId, MediaCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(int userId, PostCreateDto dto)
        {
            var post = Mapper.Map<Post>(dto);
            post.OwnerId = userId;
            await genericRepository.CreateAsync(post);
            await genericRepository.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMediaAsync(int id, int mediaId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PostDto> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<MediaDto> GetMediaByIdAsync(int id, int mediaId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MediaDto>> GetMediasAsync(int postId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMediaAsync(int id, int mediaId, MediaUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
