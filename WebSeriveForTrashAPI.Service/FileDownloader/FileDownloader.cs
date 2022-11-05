using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebSeriveForTrashAPI.Model.Telegram.PayloadsForApi;
using WebSeriveForTrashAPI.Service.Telegram;

namespace WebSeriveForTrashAPI.Service.FileDownloader
{
    public class FileDownloader
    {
        private readonly string _folder = Path.Combine(".", "files");
        private readonly Messager _messager;

        public FileDownloader(Messager messager)
        {
            _messager = messager;
        }

        public async Task SendFileToUser(string url, string userId)
        {
            Directory.CreateDirectory(_folder);

            string fileName = url.Split("/").Last();
            string savePath = Path.Combine(_folder, fileName);

            await Download(url, savePath);
            await _messager.SendFile(userId, savePath);
        }

        private async Task Download(string url, string savePath)
        {
            using (var client = new WebClient())
            client.DownloadFile(new Uri(url), savePath);

            Console.WriteLine(url);
        }
    }
}
