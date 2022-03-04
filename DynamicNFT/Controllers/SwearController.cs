using DynamicNFT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicNFT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwearController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(string? language = "Australian")
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if(language == "Australian")
            {
                var imageFilePath = baseDirectory + $"NFT/swear/australia.png";
                ISwear swear = new AustralianSwear();
                return File(await SwearwordImageGenerator.Generate(imageFilePath, swear.GetRandomSwear()), "image/png");
            }
            else
            {
                var exceptionImageFilePath = baseDirectory + "NFT/oops.png";
                return File(await WeatherImageGenerator.Generate(exceptionImageFilePath), "image/png");
            }
        }
    }
}
