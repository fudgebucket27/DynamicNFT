using Newtonsoft.Json;
using RestSharp;

namespace DynamicNFT.Models
{
    public class WeatherClient : IWeatherClient, IDisposable
    {
        readonly RestClient _client;

        private string _apiKey;

        public WeatherClient(string apiKey)
        {
            _apiKey = apiKey;
            var options = new RestClientOptions("http://api.weatherapi.com/v1/current.json");
            _client = new RestClient(options);
        }

        public async Task<Weather> GetWeather(string city)
        {
            var request = new RestRequest();
            request.AddParameter("key", _apiKey);
            request.AddParameter("q", city);
            request.AddParameter("aqi", "no");
            var response = await _client.GetAsync(request);
            var weather = JsonConvert.DeserializeObject<Weather>(response.Content!);
            return weather;
        }

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
