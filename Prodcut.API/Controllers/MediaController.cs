using Common.Services.MediaService;
using Microsoft.AspNetCore.Mvc;

namespace Prodcut.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private IMediaService _mediaService;
        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }
        [HttpPost("Image")]
        public virtual IActionResult UploadImage(IFormFile file)
        {
            try
            {
                return Ok(_mediaService.UploadImage(file));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
        [HttpPost("Images")]
        public virtual IActionResult UploadImages(List<IFormFile> files)
        {
            try
            {
                return Ok(_mediaService.UploadImages(files));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
