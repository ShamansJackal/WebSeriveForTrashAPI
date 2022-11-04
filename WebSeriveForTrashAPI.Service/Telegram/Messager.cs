using RestSharp;
using WebSeriveForTrashAPI.Model.Telegram.PayloadsForApi;

namespace WebSeriveForTrashAPI.Service.Telegram
{
    public class Messager
    {
        private readonly string _token;
        private readonly RestClient _client;

        public Messager(RestClient client)
        {
            _token = Environment.GetEnvironmentVariable("TelegramBotToken") ?? throw new Exception("Telegram bot token not found");
            _client = client;
        }

        public async Task<bool> SendMessage(Message message)
        {
            RestRequest request = new($"bot{_token}/sendMessage", Method.Post);
            request.AddBody(message);

            var result = await _client.ExecuteAsync(request);
            return result.IsSuccessStatusCode;
        }
    }
}
