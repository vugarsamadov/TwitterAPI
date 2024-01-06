using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twitter.Business.Abstractions;
using Twitter.Business.Dtos.Media;
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
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _userService.GetByIdAsync(id));
        }
        [HttpDelete("{userId:int}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut("{userId:int}")]
        public async Task<IActionResult> UpdateUser(UserUpdateDto dto)
        {
            return Ok(await _userService.UpdateAsync(dto));
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
