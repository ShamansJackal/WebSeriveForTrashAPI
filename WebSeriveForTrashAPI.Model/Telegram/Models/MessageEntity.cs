using System.Text.Json.Serialization;

namespace WebSeriveForTrashAPI.Model.Telegram.Models
{
    public record MessageEntity(
         [property: JsonPropertyName("type")] string Type,
         [property: JsonPropertyName("offset")] int Offset,
         [property: JsonPropertyName("length")] int Length
    )
    {
        [JsonPropertyName("url")] public string? Url { get; init; }
        [JsonPropertyName("language")] public string? Language { get; init; }
        [JsonPropertyName("custom_emoji_id")] public string? CustomEmojiId { get; init; }
        //[field: JsonPropertyName("user")] User? User,
    };
}
