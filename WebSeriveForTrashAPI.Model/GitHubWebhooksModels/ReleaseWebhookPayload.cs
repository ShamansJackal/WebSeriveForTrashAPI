using System.Text.Json.Serialization;
using WebSeriveForTrashAPI.Model.GitHubWebhooksModels.Common;

namespace WebSeriveForTrashAPI.Model.GitHubWebhooksModels
{
    public record ReleaseWebhookPayload(
        [field: JsonPropertyName("action")] string Action,
        [field: JsonPropertyName("release")] Release Release,
        [field: JsonPropertyName("repository")] Repository Repository,
        [field: JsonPropertyName("sender")] User Sender
    );
}
