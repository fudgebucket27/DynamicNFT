namespace DynamicNFT.Models
{
    public interface IWeatherClient
    {
        Task<Weather> GetWeather(string city, string apiKey);
    }
}
