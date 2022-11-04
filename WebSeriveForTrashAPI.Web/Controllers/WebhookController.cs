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
        public async Task<IActionResult> PostSavePage()
        {
            string json = await new StreamReader(Request.Body).ReadToEndAsync();

            _jsons.Add(json);
            _jsons.Add(Request.Headers["X-Hub-Signature-256"]);

            using HMACSHA256 hmac = new(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SecretForGithub")));
            var hashOfJson = hmac.ComputeHash(Encoding.UTF8.GetBytes(json));

            StringBuilder builder = new(32);
            for (int i = 0; i < hashOfJson.Length; i++)
                builder.Append(hashOfJson[i].ToString("x2"));
            string sha256string = builder.ToString();

            if (Request.Headers["X-Hub-Signature-256"] == $"sha256={sha256string}")
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
