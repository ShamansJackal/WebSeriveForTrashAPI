using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WebSeriveForTrashAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

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
            _jsons.Add(Request.Headers["X-Hub-Signature-256"]);
            if (Request.Headers["X-Hub-Signature-256"] ==
                Encoding.UTF8.GetString(SHA256.HashData(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SecretForGithub")))))
                return Ok();
            else
                return Accepted();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jsons);
        }
    }
}
