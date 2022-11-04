using System.Text.Json.Serialization;
using WebSeriveForTrashAPI.Model.Telegram.Models;

namespace WebSeriveForTrashAPI.Model.Telegram.PayloadsForApi
{
    public record Message(
        [field: JsonPropertyName("chat_id")] string ChatId,
        [field: JsonPropertyName("text")] string Text
    )
    {
        [JsonPropertyName("parse_mode")] public string? ParseMode { get; init; }
        [JsonPropertyName("entities")] public IReadOnlyList<MessageEntity>? Entities { get; init; }
        [JsonPropertyName("disable_web_page_preview")] public bool? DisablePreview { get; init; }
        [JsonPropertyName("disable_notification")] public bool? DisableNotification { get; init; }
        [JsonPropertyName("protect_content")] public bool? ProtectContent { get; init; }
        [JsonPropertyName("reply_to_message_id")] public int? ReplyToMessageId { get; init; }
        [JsonPropertyName("allow_sending_without_reply")] public bool? AllowSendingWithoutReply { get; init; }
    //[field: JsonPropertyName("reply_markup")] ReplyMarkup? DisablePreview,
    };
}
