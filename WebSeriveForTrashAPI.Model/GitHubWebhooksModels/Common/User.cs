using System.Text.Json.Serialization;

namespace WebSeriveForTrashAPI.Model.GitHubWebhooksModels.Common
{
    public record User(
        [field: JsonPropertyName("login")] string Login,
        [field: JsonPropertyName("id")] int Id,
        [field: JsonPropertyName("node_id")] string NodeId,
        [field: JsonPropertyName("avatar_url")] string AvatarUrl,
        [field: JsonPropertyName("gravatar_id")] string GravatarId,
        [field: JsonPropertyName("url")] string Url,
        [field: JsonPropertyName("html_url")] string HtmlUrl,
        [field: JsonPropertyName("followers_url")] string FollowersUrl,
        [field: JsonPropertyName("following_url")] string FollowingUrl,
        [field: JsonPropertyName("gists_url")] string GistsUrl,
        [field: JsonPropertyName("starred_url")] string StarredUrl,
        [field: JsonPropertyName("subscriptions_url")] string SubscriptionsUrl,
        [field: JsonPropertyName("organizations_url")] string OrganizationsUrl,
        [field: JsonPropertyName("repos_url")] string ReposUrl,
        [field: JsonPropertyName("events_url")] string EventsUrl,
        [field: JsonPropertyName("received_events_url")] string ReceivedEventsUrl,
        [field: JsonPropertyName("type")] string Type,
        [field: JsonPropertyName("site_admin")] bool SiteAdmin
    );
}
