using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicNFT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwearController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(string language = "Australian")
        {

        }
    }
}
