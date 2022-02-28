using DynamicNFT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;

namespace DynamicNFT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class NFT : ControllerBase
    {

        [HttpGet("Weather")]
        public async Task<IActionResult> GetWeather(string? city = "townsville")
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var apiKey = ApiKeyHelper._apiKey;
            var apiUrl = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&aqi=no";
            var client = new RestClient(apiUrl);
            var request = new RestRequest();
            try
            {
                var response = await client.GetAsync(request);
                var weather = JsonConvert.DeserializeObject<Weather>(response.Content!);

                if(weather!.current.is_day == 1 && weather.current.condition.text.ToUpper().Contains("CLOUDY"))  
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/{city}/cloudyDay.png";
                    var image = System.IO.File.OpenRead(imageFilePath);
                    return File(image, "image/png");
                }
                if (weather!.current.is_day == 0 && weather.current.condition.text.ToUpper().Contains("CLOUDY"))
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/{city}/cloudyNight.png";
                    var image = System.IO.File.OpenRead(imageFilePath);
                    return File(image, "image/png");
                }
                else if (weather!.current.is_day == 1 && ( (weather.current.condition.text.ToUpper().Contains("RAIN")) || (weather.current.condition.text.ToUpper().Contains("DRIZZLE")) || (weather.current.condition.text.ToUpper().Contains("SHOWER"))))
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/{city}/rainyDay.png";
                    var image = System.IO.File.OpenRead(imageFilePath);
                    return File(image, "image/png");
                }
                else if (weather!.current.is_day == 0 && ( (weather.current.condition.text.ToUpper().Contains("RAIN")) || (weather.current.condition.text.ToUpper().Contains("DRIZZLE")) || (weather.current.condition.text.ToUpper().Contains("SHOWER"))))
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/{city}/rainyNight.png";
                    var image = System.IO.File.OpenRead(imageFilePath);
                    return File(image, "image/png");
                }
                else if (weather!.current.is_day == 1 && weather.current.condition.text.ToUpper().Contains("SUNNY"))
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/{city}/sunnyDay.png";
                    var image = System.IO.File.OpenRead(imageFilePath);
                    return File(image, "image/png");
                }
                else if (weather!.current.is_day == 0 && weather.current.condition.text.ToUpper().Contains("CLEAR"))
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/{city}/clearNight.png";
                    var image = System.IO.File.OpenRead(imageFilePath);
                    return File(image, "image/png");
                }
                else if (weather!.current.is_day == 1 && weather.current.condition.text.ToUpper().Contains("THUNDER"))
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/{city}/thunderDay.png";
                    var image = System.IO.File.OpenRead(imageFilePath);
                    return File(image, "image/png");
                }
                else if (weather!.current.is_day == 0 && weather.current.condition.text.ToUpper().Contains("THUNDER"))
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/{city}/thunderNight.png";
                    var image = System.IO.File.OpenRead(imageFilePath);
                    return File(image, "image/png");
                }
                else
                {
                    var conditionNotFoundFilePath = baseDirectory + "NFT/rainbow.png";
                    var conditionNotFoundImage = System.IO.File.OpenRead(conditionNotFoundFilePath);
                    return File(conditionNotFoundImage, "image/png");
                }
            }
            catch(HttpRequestException he)
            {
                
            }
            catch(IOException ioe)
            {

            }
            catch(Exception ex)
            {

            }
            var oopsFilePath = baseDirectory + "NFT/oops.png";
            var oopsImage = System.IO.File.OpenRead(oopsFilePath);
            return File(oopsImage, "image/png");
        }
    }
}
