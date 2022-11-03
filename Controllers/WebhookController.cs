using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace WebSeriveForTrashAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WebhookController : ControllerBase
    {
        private readonly List<string> _jsons;

        public WebhookController(List<string> jsons)
        {
            _jsons = jsons;
        }

        [HttpPost]
        public IActionResult PostSavePage([FromBody] dynamic testObject)
        {
            _jsons.Add(JsonConvert.SerializeObject(testObject));

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jsons);
        }
    }
}
