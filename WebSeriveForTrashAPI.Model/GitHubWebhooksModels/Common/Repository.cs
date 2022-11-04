﻿using System.Text.Json.Serialization;

namespace WebSeriveForTrashAPI.Model.GitHubWebhooksModels.Common
{
    public record Repository(
        [field: JsonPropertyName("id")] int Id,
        [field: JsonPropertyName("node_id")] string NodeId,
        [field: JsonPropertyName("name")] string Name,
        [field: JsonPropertyName("full_name")] string FullName,
        [field: JsonPropertyName("private")] bool Private,
        [field: JsonPropertyName("owner")] User Owner,
        [field: JsonPropertyName("html_url")] string HtmlUrl,
        [field: JsonPropertyName("description")] object Description,
        [field: JsonPropertyName("fork")] bool Fork,
        [field: JsonPropertyName("url")] string Url,
        [field: JsonPropertyName("forks_url")] string ForksUrl,
        [field: JsonPropertyName("keys_url")] string KeysUrl,
        [field: JsonPropertyName("collaborators_url")] string CollaboratorsUrl,
        [field: JsonPropertyName("teams_url")] string TeamsUrl,
        [field: JsonPropertyName("hooks_url")] string HooksUrl,
        [field: JsonPropertyName("issue_events_url")] string IssueEventsUrl,
        [field: JsonPropertyName("events_url")] string EventsUrl,
        [field: JsonPropertyName("assignees_url")] string AssigneesUrl,
        [field: JsonPropertyName("branches_url")] string BranchesUrl,
        [field: JsonPropertyName("tags_url")] string TagsUrl,
        [field: JsonPropertyName("blobs_url")] string BlobsUrl,
        [field: JsonPropertyName("git_tags_url")] string GitTagsUrl,
        [field: JsonPropertyName("git_refs_url")] string GitRefsUrl,
        [field: JsonPropertyName("trees_url")] string TreesUrl,
        [field: JsonPropertyName("statuses_url")] string StatusesUrl,
        [field: JsonPropertyName("languages_url")] string LanguagesUrl,
        [field: JsonPropertyName("stargazers_url")] string StargazersUrl,
        [field: JsonPropertyName("contributors_url")] string ContributorsUrl,
        [field: JsonPropertyName("subscribers_url")] string SubscribersUrl,
        [field: JsonPropertyName("subscription_url")] string SubscriptionUrl,
        [field: JsonPropertyName("commits_url")] string CommitsUrl,
        [field: JsonPropertyName("git_commits_url")] string GitCommitsUrl,
        [field: JsonPropertyName("comments_url")] string CommentsUrl,
        [field: JsonPropertyName("issue_comment_url")] string IssueCommentUrl,
        [field: JsonPropertyName("contents_url")] string ContentsUrl,
        [field: JsonPropertyName("compare_url")] string CompareUrl,
        [field: JsonPropertyName("merges_url")] string MergesUrl,
        [field: JsonPropertyName("archive_url")] string ArchiveUrl,
        [field: JsonPropertyName("downloads_url")] string DownloadsUrl,
        [field: JsonPropertyName("issues_url")] string IssuesUrl,
        [field: JsonPropertyName("pulls_url")] string PullsUrl,
        [field: JsonPropertyName("milestones_url")] string MilestonesUrl,
        [field: JsonPropertyName("notifications_url")] string NotificationsUrl,
        [field: JsonPropertyName("labels_url")] string LabelsUrl,
        [field: JsonPropertyName("releases_url")] string ReleasesUrl,
        [field: JsonPropertyName("deployments_url")] string DeploymentsUrl,
        [field: JsonPropertyName("created_at")] DateTime CreatedAt,
        [field: JsonPropertyName("updated_at")] DateTime UpdatedAt,
        [field: JsonPropertyName("pushed_at")] DateTime PushedAt,
        [field: JsonPropertyName("git_url")] string GitUrl,
        [field: JsonPropertyName("ssh_url")] string SshUrl,
        [field: JsonPropertyName("clone_url")] string CloneUrl,
        [field: JsonPropertyName("svn_url")] string SvnUrl,
        [field: JsonPropertyName("homepage")] object Homepage,
        [field: JsonPropertyName("size")] int Size,
        [field: JsonPropertyName("stargazers_count")] int StargazersCount,
        [field: JsonPropertyName("watchers_count")] int WatchersCount,
        [field: JsonPropertyName("language")] string Language,
        [field: JsonPropertyName("has_issues")] bool HasIssues,
        [field: JsonPropertyName("has_projects")] bool HasProjects,
        [field: JsonPropertyName("has_downloads")] bool HasDownloads,
        [field: JsonPropertyName("has_wiki")] bool HasWiki,
        [field: JsonPropertyName("has_pages")] bool HasPages,
        [field: JsonPropertyName("forks_count")] int ForksCount,
        [field: JsonPropertyName("mirror_url")] object MirrorUrl,
        [field: JsonPropertyName("archived")] bool Archived,
        [field: JsonPropertyName("disabled")] bool Disabled,
        [field: JsonPropertyName("open_issues_count")] int OpenIssuesCount,
        [field: JsonPropertyName("license")] object License,
        [field: JsonPropertyName("forks")] int Forks,
        [field: JsonPropertyName("open_issues")] int OpenIssues,
        [field: JsonPropertyName("watchers")] int Watchers,
        [field: JsonPropertyName("default_branch")] string DefaultBranch
    );
}