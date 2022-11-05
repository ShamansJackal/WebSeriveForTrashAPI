using RestSharp;
using System.Text.Json;
using System.Text.Json.Serialization;
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
            Uri uri = new($"./bot{_token}/sendMessage", UriKind.Relative);
            RestRequest request = new(uri, Method.Post){ RequestFormat = DataFormat.Json };

            string json = JsonSerializer.Serialize(message, new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull});
            request.AddJsonBody(json);
            try
            {
                var response = await _client.ExecuteAsync(request);
                return response.IsSuccessStatusCode;
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

        }

        public async Task<bool> SendFile(string userId, string filePath)
        {
            Uri uri = new($"./bot{_token}/sendDocument", UriKind.Relative);
            RestRequest request = new(uri, Method.Post);
            request.AddFile("document", filePath);
            request.AddParameter("chat_id", userId);

            try
            {
                var response = await _client.ExecuteAsync(request);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
