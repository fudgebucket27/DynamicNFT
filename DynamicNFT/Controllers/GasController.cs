using DynamicNFT.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicNFT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GasController : ControllerBase
    {
        private IGasClient _gasClient;
        public GasController(IGasClient gasClient)
        {
            _gasClient = gasClient;
        }
        public async Task<IActionResult> Get()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                var imageFilePath = baseDirectory + $"NFT/gas/background.png";
                var gasData = await _gasClient.GetGas(ApiKeyHelper.EthGasApiKey);
                return File(await GasImageGenerator.Generate(imageFilePath, gasData), "image/png");
            }
            catch (HttpRequestException he)
            {

            }
            catch (IOException ioe)
            {

            }
            catch (Exception ex)
            {

            }
            var exceptionImageFilePath = baseDirectory + "NFT/oops.png";
            return File(await WeatherImageGenerator.Generate(exceptionImageFilePath), "image/png");
        }
    }
}
