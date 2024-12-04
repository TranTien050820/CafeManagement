using Cafe_Management.Core.Interfaces;

namespace Cafe_Management.Infrastructure.Repositories
{
    public class SaveImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment _environment;

        // Inject IWebHostEnvironment thông qua Dependency Injection
        public SaveImageRepository(IWebHostEnvironment environment)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        public string SaveImage(string imgStr, string imgName, string _path)
        {
            try
            {
                // Đường dẫn vật lý
                string path = Path.Combine(_environment.WebRootPath, "Image", _path);

                // Kiểm tra và tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Định dạng tên ảnh
                string imageName = imgName + ".jpg";
                string imgPath = Path.Combine(path, imageName);

                // Chuyển đổi Base64 thành byte[]
                byte[] imageBytes = Convert.FromBase64String(imgStr);

                // Lưu tệp tin ảnh
                File.WriteAllBytes(imgPath, imageBytes);

                return $"/Image/{_path}/{imageName}";
            }
            catch (Exception ex)
            {
                return $"Error saving image: {ex.Message}";
            }
        }
    }
}
