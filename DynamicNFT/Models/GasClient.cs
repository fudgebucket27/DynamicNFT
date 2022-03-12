using Newtonsoft.Json;
using RestSharp;

namespace DynamicNFT.Models
{
    public class GasClient : IGasClient, IDisposable
    {
        readonly RestClient _client;

        public GasClient()
        {
            var options = new RestClientOptions("http://ethgas.watch/api");
            _client = new RestClient(options);
        }


        public async Task<Gas> GetGas()
        {
            var request = new RestRequest("/gas");
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
