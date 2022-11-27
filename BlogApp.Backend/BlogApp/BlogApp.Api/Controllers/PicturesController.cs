using BlogApp.Logic;
using BlogApp.Logic.Models.Pictures;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private readonly ILogicLayer _logic;
        public PicturesController(ILogicLayer logic)
        {
            _logic = logic;
        }

        [HttpPost]
        public async Task<IActionResult> UploadPictureAsync([FromForm] PictureModel newPicture) =>
            await _logic.UploadPictureAsync(newPicture);

        [HttpGet]
        public async Task<IActionResult> GetPictureAsync()
        {
            //var data = await _logic.GetPictureAsync();
            //return new OkObjectResult(data);
            var file = File(await _logic.GetPictureAsync(), "image/*");
            FileContentResult formFile = file;
            return new OkObjectResult(formFile);
            //return new OkObjectResult(File(await _logic.GetPictureAsync(), "image/svg"));
        }
    }
}
