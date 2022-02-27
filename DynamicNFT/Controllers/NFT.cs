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

        [HttpGet("Weather")]
        public IActionResult GetWeather()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var currentDirectory = baseDirectory + "NFT/weather/";
            var files = Directory.GetFiles(currentDirectory, "*.png");
            
            var rand = new Random();
            var image = System.IO.File.OpenRead(files[rand.Next(files.Length)]);
            return File(image, "image/png");
        }
    }
}
