using System;

namespace WebSeriveForTrashAPI.Service.Utils
{
    public static class BytesExtentsions
    {
        public static async Task<byte[]> ReadFullyAsync(this Stream input)
        {
            byte[] buffer = new byte[4 * 1024];
            using MemoryStream ms = new();
            int read;
            while ((read = await input.ReadAsync(buffer)) > 0)
                ms.Write(buffer, 0, read);
            return ms.ToArray();
        }
    }
}
