using System.Text.Json.Serialization;
using WebSeriveForTrashAPI.Model.GitHubWebhooksModels.Common;

namespace WebSeriveForTrashAPI.Model.GitHubWebhooksModels
{
    public class ReleaseWebhookPayload
    {
        [JsonPropertyName("action")]
        public string Action { get; set; }

        [JsonPropertyName("release")]
        public Release Release { get; set; }
    }
}
