using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WebSeriveForTrashAPI.Model.GitHubWebhooksModels;
using WebSeriveForTrashAPI.Model.Telegram.PayloadsForApi;
using WebSeriveForTrashAPI.Service.Telegram;
using WebSeriveForTrashAPI.Service.Utils;

namespace WebSeriveForTrashAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        private readonly List<string> _jsons;
        private readonly Messager _messager;

        public WebhookController(List<string> jsons, Messager messager)
        {
            _jsons = jsons;
            _messager = messager;
        }

        [HttpPost]
        public async Task<IActionResult> PostSavePage()
        {
            var json = await Request.Body.ReadFullyAsync();

            _jsons.Add(Request.Headers["X-Hub-Signature-256"]);

            StringBuilder builder = new(32);
            for (int i = 0; i < json.Length; i++)
                builder.Append(json[i].ToString("x2"));
            _jsons.Add(builder.ToString());


            using HMACSHA256 hmac = new(Encoding.UTF8.GetBytes(
                Environment.GetEnvironmentVariable("SecretForGithub") ?? throw new Exception("Secret for github signature check not found")
            ));
            var hashOfJson = hmac.ComputeHash(json);

            builder = new(32);
            for (int i = 0; i < hashOfJson.Length; i++)
                builder.Append(hashOfJson[i].ToString("x2"));
            string sha256string = builder.ToString();

            if (Request.Headers["X-Hub-Signature-256"] == $"sha256={sha256string}")
            {
                await _messager.SendMessage(new("210583358", "dsa"));
                return Ok();
            }

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
