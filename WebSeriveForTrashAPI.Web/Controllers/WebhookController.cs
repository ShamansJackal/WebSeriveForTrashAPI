using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using WebSeriveForTrashAPI.Model.GitHubWebhooksModels;
using WebSeriveForTrashAPI.Service.FileDownloader;
using WebSeriveForTrashAPI.Service.Telegram;
using WebSeriveForTrashAPI.Service.Utils;

namespace WebSeriveForTrashAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        private readonly Messager _messager;
        private readonly FileDownloader _downloader;
        private readonly IConfiguration _configuration;

        public WebhookController(Messager messager, FileDownloader fileDownloader, IConfiguration configuration)
        {
            _messager = messager;
            _downloader = fileDownloader;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> PostSavePage()
        {
            var json = await Request.Body.ReadFullyAsync();

            using HMACSHA256 hmac = new(Encoding.UTF8.GetBytes(
                Environment.GetEnvironmentVariable("SecretForGithub") ?? throw new Exception("Secret for github signature check not found")
            ));
            var hashOfJson = hmac.ComputeHash(json);

            StringBuilder builder = new(32);
            for (int i = 0; i < hashOfJson.Length; i++)
                builder.Append(hashOfJson[i].ToString("x2"));
            string sha256string = builder.ToString();

            if (Request.Headers["X-Hub-Signature-256"] != $"sha256={sha256string}")
            {
                ReleaseWebhookPayload release = JsonSerializer.Deserialize<ReleaseWebhookPayload>(json);

                if (release.Action != "released") return Ok();

                await _messager.SendMessage(new(_configuration["UserId"], release.Release.HtmlUrl));
                foreach (var asset in release.Release.Assets)
                    _downloader.SendFileToUser(asset.BrowserDownloadUrl, _configuration["UserId"]);

                return Ok();
            }
            else
            {
                return BadRequest("Incorrect signature");
            }
        }
    }
}
