using Microsoft.AspNetCore.Http;
using System.IO;


namespace Common.Services.MediaService
{
    public class MediaService : IMediaService
    {
        public async Task<string> UploadImage(IFormFile file)
        {
            var dateTimeNow = DateTime.Now.ToString("dd_MM_yyyy");

            var mediaFolder = Path.Combine($"Uploads\\Images\\{dateTimeNow}");
            if (!Directory.Exists(mediaFolder))
            {
                Directory.CreateDirectory(mediaFolder);
            }

            // Lấy ngày hiện tại và định dạng thành chuỗi
            // Tạo tên file duy nhất với ngày tháng năm
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";

            var filePath = Path.Combine(mediaFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath.ToString();
        }
        public async Task<List<string>> UploadImages(List<IFormFile> files)
        {
            var dateTimeNow = DateTime.Now.ToString("dd_MM_yyyy");
            var mediaFolder = Path.Combine($"Uploads\\Images\\{dateTimeNow}");
            if (!Directory.Exists(mediaFolder))
            {
                Directory.CreateDirectory(mediaFolder);
            }
            var filePaths = new List<string>();

            foreach (var file in files)
            {
                var fileName = $"{Guid.NewGuid()}";
                var filePath = Path.Combine(mediaFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                filePaths.Add(filePath.ToString());
            }

            return filePaths;
        }
    }

}
