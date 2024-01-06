//using Microsoft.AspNetCore.Mvc;
//using Twitter.Business.Abstractions;
//using Twitter.Business.Dtos.Media;

//namespace Twitter.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PostsController : ControllerBase
//    {
//        public IPostsService _postsService { get; }

//        public PostsController(IPostsService postsService)
//        {
//            _postsService = postsService;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            return Ok(await _postsService.GetAllAsync());
//        }
        
//        [HttpGet("{id:int}")]
//        public async Task<IActionResult> GetById(int id)
//        {
//            return Ok(await _postsService.GetByIdAsync(id));
//        }
        
//        [HttpGet("{id:int}/medias")]
//        public async Task<IActionResult> GetMedias(int id)
//        {
//            return Ok(await _postsService.GetMediasAsync(id));
//        }
        
//        [HttpPost("{id:int}/medias")]
//        public async Task<IActionResult> AddMedia(int id,MediaCreateDto dto)
//        {
//            await _postsService.AddMediaAsync(id, dto);
//            return Ok();
//        }

//        [HttpGet("{id:int}/medias/{mediaId:int}")]
//        public async Task<IActionResult> GetMediaById(int id, int mediaId)
//        {
//            var media = await _postsService.GetMediaByIdAsync(id, mediaId);

//            if (media == null)
//                return NotFound();

//            return Ok(media);
//        }

//        [HttpDelete("{id:int}/medias/{mediaId:int}")]
//        public async Task<IActionResult> DeleteMedia(int id, int mediaId)
//        {
//            await _postsService.DeleteMediaAsync(id, mediaId);

//            return Ok();
//        }
        
//        [HttpPut("{id:int}/medias/{mediaId:int}")]
//        public async Task<IActionResult> UpdateMedia(int id, int mediaId, MediaUpdateDto dto)
//        {
//            await _postsService.UpdateMediaAsync(id, mediaId,dto);

//            return Ok();
//        }

//    }
//}
