using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicNFT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NFT : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var imageLocation = currentDirectory + "NFT/0.jpg";
            var image = System.IO.File.OpenRead(imageLocation);
            return File(image, "image/jpeg");
        }
    }
}
