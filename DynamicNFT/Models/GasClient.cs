using Newtonsoft.Json;
using RestSharp;

namespace DynamicNFT.Models
{
    public class GasClient : IGasClient, IDisposable
    {
        readonly RestClient _client;

        public GasClient()
        {
            var options = new RestClientOptions("https://ethgasstation.info/api");
            _client = new RestClient(options);
        }


        public async Task<Gas> GetGas(string apiKey)
        {
            var request = new RestRequest("ethgasAPI.json");
            request.AddParameter("api-key", apiKey);
            var response = await _client.GetAsync(request);
            var gas = JsonConvert.DeserializeObject<Gas>(response.Content!);
            return gas;
        }

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
