using DynamicNFT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;
using System.Drawing;

namespace DynamicNFT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class NFT : ControllerBase
    {
        private IWeatherClient _weatherClient;

        public NFT(IWeatherClient weatherClient)
        {
            _weatherClient = weatherClient;
        }
        [HttpGet("Weather")]
        public async Task<IActionResult> GetWeather(string? city = "townsville")
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var apiKey = ApiKeyHelper.WeatherApiKey;
            try
            {
                var weather = await _weatherClient.GetWeather(city, apiKey);
                if(weather!.current.is_day == 1 && ((weather.current.condition.text.ToUpper().Contains("CLOUDY")) || (weather.current.condition.text.ToUpper().Contains("OVERCAST"))) )
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/partly_cloudy.png";
                    return File(await WeatherImageGenerator.Generate(imageFilePath, weather.current.temp_c.ToString(), weather.location.localtime, weather.current.condition.text, city), "image/png");
                }
                if (weather!.current.is_day == 0 && ((weather.current.condition.text.ToUpper().Contains("CLOUDY")) || (weather.current.condition.text.ToUpper().Contains("OVERCAST"))))
                {
                    var imageFilePath = baseDirectory + $"NFT/weather//partly_cloudy_night.png";
                    return File(await WeatherImageGenerator.Generate(imageFilePath, weather.current.temp_c.ToString(), weather.location.localtime, weather.current.condition.text, city), "image/png");

                }
                else if (weather!.current.is_day == 1 && ( (weather.current.condition.text.ToUpper().Contains("RAIN")) || (weather.current.condition.text.ToUpper().Contains("DRIZZLE")) || (weather.current.condition.text.ToUpper().Contains("SHOWER"))))
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/rain.png";
                    return File(await WeatherImageGenerator.Generate(imageFilePath, weather.current.temp_c.ToString(), weather.location.localtime, weather.current.condition.text, city), "image/png");

                }
                else if (weather!.current.is_day == 0 && ( (weather.current.condition.text.ToUpper().Contains("RAIN")) || (weather.current.condition.text.ToUpper().Contains("DRIZZLE")) || (weather.current.condition.text.ToUpper().Contains("SHOWER"))))
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/rain_night.png";
                    return File(await WeatherImageGenerator.Generate(imageFilePath, weather.current.temp_c.ToString(), weather.location.localtime, weather.current.condition.text, city), "image/png");

                }
                else if (weather!.current.is_day == 1 && weather.current.condition.text.ToUpper().Contains("SUNNY"))
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/sunny.png";
                    return File(await WeatherImageGenerator.Generate(imageFilePath, weather.current.temp_c.ToString(), weather.location.localtime, weather.current.condition.text, city), "image/png");

                }
                else if (weather!.current.is_day == 0 && weather.current.condition.text.ToUpper().Contains("CLEAR"))
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/clear.png";
                    return File(await WeatherImageGenerator.Generate(imageFilePath, weather.current.temp_c.ToString(), weather.location.localtime, weather.current.condition.text, city), "image/png");

                }
                else if (weather!.current.is_day == 1 && ((weather.current.condition.text.ToUpper().Contains("SNOW")) || (weather.current.condition.text.ToUpper().Contains("SLEET")) || (weather.current.condition.text.ToUpper().Contains("ICE")) || (weather.current.condition.text.ToUpper().Contains("BLIZZARD"))))
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/heavy_snow.png";
                    return File(await WeatherImageGenerator.Generate(imageFilePath, weather.current.temp_c.ToString(), weather.location.localtime, weather.current.condition.text, city), "image/png");

                }
                else if (weather!.current.is_day == 0 && ((weather.current.condition.text.ToUpper().Contains("SNOW")) || (weather.current.condition.text.ToUpper().Contains("SLEET")) || (weather.current.condition.text.ToUpper().Contains("ICE")) || (weather.current.condition.text.ToUpper().Contains("BLIZZARD"))))
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/heavy_snow_night.png";
                    return File(await WeatherImageGenerator.Generate(imageFilePath, weather.current.temp_c.ToString(), weather.location.localtime, weather.current.condition.text, city), "image/png");

                }
                else if (weather!.current.is_day == 1 && weather.current.condition.text.ToUpper().Contains("THUNDER"))
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/thunderstorm.png";
                    return File(await WeatherImageGenerator.Generate(imageFilePath, weather.current.temp_c.ToString(), weather.location.localtime, weather.current.condition.text, city), "image/png");

                }
                else if (weather!.current.is_day == 0 && weather.current.condition.text.ToUpper().Contains("THUNDER"))
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/thunderstorm_night.png";
                    return File(await WeatherImageGenerator.Generate(imageFilePath, weather.current.temp_c.ToString(), weather.location.localtime, weather.current.condition.text, city), "image/png");

                }
                else if (weather!.current.is_day == 1 && ((weather.current.condition.text.ToUpper().Contains("MIST")) || (weather.current.condition.text.ToUpper().Contains("FOG")) ))
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/fog.png";
                    return File(await WeatherImageGenerator.Generate(imageFilePath, weather.current.temp_c.ToString(), weather.location.localtime, weather.current.condition.text, city), "image/png");

                }
                else if (weather!.current.is_day == 0 && ((weather.current.condition.text.ToUpper().Contains("MIST")) || (weather.current.condition.text.ToUpper().Contains("FOG")) ))
                {
                    var imageFilePath = baseDirectory + $"NFT/weather/fog_night.png";
                    return File(await WeatherImageGenerator.Generate(imageFilePath, weather.current.temp_c.ToString(), weather.location.localtime, weather.current.condition.text, city), "image/png");

                }
                else
                {
                    var conditionNotFoundFilePath = baseDirectory + "NFT/rainbow.png";
                    return File(await WeatherImageGenerator.Generate(conditionNotFoundFilePath), "image/png");
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
            var exceptionImageFilePath = baseDirectory + "NFT/oops.png";
            return File(await WeatherImageGenerator.Generate(exceptionImageFilePath), "image/png");
        }
    }
}
