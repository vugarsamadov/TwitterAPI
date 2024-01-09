using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twitter.Business.Abstractions;
using Twitter.Business.Dtos.Media;
using Twitter.Business.Dtos.Post;
using Twitter.Business.Dtos.User;

namespace Twitter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService { get; }
        private IPostsService _postsService { get; }

        public UsersController(IUserService userService,IPostsService postsService)
        {
            _userService = userService;
            _postsService = postsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAllAsync());
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetById(int userId)
        {
            return Ok(await _userService.GetByIdAsync(userId));
        }
        [HttpDelete("{userId:int}")]
        public async Task<IActionResult> DeleteById(int userId)
        {
            await _userService.DeleteAsync(userId);
            return Ok();
        }

        [HttpPut("{userId:int}")]
        public async Task<IActionResult> UpdateUser(int userId,UserUpdateDto dto)
        {
            return Ok(await _userService.UpdateAsync(userId,dto));
        }

        //posts

        [HttpGet("{userId:int}/posts/{postId:int}")]
        public async Task<IActionResult> GetPostById(int userId, int postId)
        {
            return Ok();
        }

        [HttpPut("{userId:int}/posts/{postId:int}")]
        public async Task<IActionResult> UpdatePost(int userId, int postId,PostUpdateDto dto)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("{userId:int}/posts/{postId:int}")]
        public async Task<IActionResult> DeletePost(int userId, int postId)
        {
            throw new NotImplementedException();
        }
        [HttpPost("{userId:int}/posts")]
        public async Task<IActionResult> CreatePost(int userId, PostCreateDto dto)
        {
            var newpost = await _userService.CreatePostAsync(userId, dto);
            var p = new RouteValueDictionary()
            {
                {"userId",userId },
                {"postId",newpost.Id }
            };
            
            return CreatedAtAction(nameof(GetPostById), p);
        }

        [HttpGet("{userId:int}/posts")]
        public async Task<IActionResult> GetPosts(int userId)
        {
            return await _userService.GetAllPosts();
        }




        [HttpGet("{userId:int}/posts/{postId:int}/medias")]
        public async Task<IActionResult> GetMedias(int userId,int postId)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{userId:int}/posts/{postid:int}/medias/{mediaId:int}")]
        public async Task<IActionResult> GetMediaById(int userId, int postid, int mediaId)
        {
            throw new NotImplementedException();
        }
        [HttpPost("{userId:int}/posts/{postId:int}/medias")]
        public async Task<IActionResult> AddMedia(int userId, int postId, MediaCreateDto dto)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{userId:int}/posts/{postId:int}/medias/{mediaId:int}")]
        public async Task<IActionResult> DeleteMedia(int userId, int postId, int mediaId)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{userId:int}/posts/{postId:int}/medias/{mediaId:int}")]
        public async Task<IActionResult> UpdateMedia(int userId, int postId,int mediaId, MediaUpdateDto dto)
        {
            throw new NotImplementedException();
        }


    }
}
