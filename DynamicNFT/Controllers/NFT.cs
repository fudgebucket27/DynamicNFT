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
    public class NFT : ControllerBase
    {


        [HttpGet("Weather")]
        public async Task<IActionResult> GetWeather(string? city = "townsville")
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var apiKey = "6f703f67300847b2ac5222311222702";
            var apiUrl = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&aqi=no";
            var client = new RestClient(apiUrl);
            var request = new RestRequest();
            try
            {
                var response = await client.GetAsync(request);
                var weather = JsonConvert.DeserializeObject<Weather>(response.Content!);

                if(
                    weather!.current.is_day == 1 &&
                    ((weather.current.condition.code == 1003) ||
                    (weather.current.condition.code == 1006) ||
                    (weather.current.condition.code == 1009)
                    )
                  )
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/{city}/cloudyDay.png";
                    var image = System.IO.File.OpenRead(imageFilePath);
                    return File(image, "image/png");
                }
                if (
                    weather!.current.is_day == 0 &&
                    ((weather.current.condition.code == 1003) ||
                    (weather.current.condition.code == 1006) ||
                    (weather.current.condition.code == 1009)
                    )
                  )
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/{city}/cloudyNight.png";
                    var image = System.IO.File.OpenRead(imageFilePath);
                    return File(image, "image/png");
                }
                else if (weather!.current.is_day == 1 && weather.current.condition.code == 1000)
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/{city}/sunny.png";
                    var image = System.IO.File.OpenRead(imageFilePath);
                    return File(image, "image/png");
                }
                else if(weather!.current.is_day == 0 && weather.current.condition.code == 1000)
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/{city}/clear.png";
                    var image = System.IO.File.OpenRead(imageFilePath);
                    return File(image, "image/png");
                }
                else
                {
                    var conditionNotFoundFilePath = baseDirectory + "oops.png";
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
            var oopsFilePath = baseDirectory + "oops.png";
            var oopsImage = System.IO.File.OpenRead(oopsFilePath);
            return File(oopsImage, "image/png");
        }
    }
}
