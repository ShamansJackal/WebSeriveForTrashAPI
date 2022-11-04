using System.Text.Json.Serialization;

namespace WebSeriveForTrashAPI.Model.GitHubWebhooksModels.Common
{
    public record Release(
        [field: JsonPropertyName("url")] string Url,
        [field: JsonPropertyName("assets_url")] string AssetsUrl,
        [field: JsonPropertyName("upload_url")] string UploadUrl,
        [field: JsonPropertyName("html_url")] string HtmlUrl,
        [field: JsonPropertyName("id")] int Id,
        [field: JsonPropertyName("node_id")] string NodeId,
        [field: JsonPropertyName("tag_name")] string TagName,
        [field: JsonPropertyName("target_commitish")] string TargetCommitish,
        [field: JsonPropertyName("name")] object Name,
        [field: JsonPropertyName("draft")] bool Draft,
        [field: JsonPropertyName("author")] User Author,
        [field: JsonPropertyName("prerelease")] bool Prerelease,
        [field: JsonPropertyName("created_at")] DateTime CreatedAt,
        [field: JsonPropertyName("published_at")] DateTime PublishedAt,
        [field: JsonPropertyName("assets")] IReadOnlyList<object> Assets,
        [field: JsonPropertyName("tarball_url")] string TarballUrl,
        [field: JsonPropertyName("zipball_url")] string ZipballUrl,
        [field: JsonPropertyName("body")] object Body
    );
}
