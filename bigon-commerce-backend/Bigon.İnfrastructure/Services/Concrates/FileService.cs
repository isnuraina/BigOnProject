using Bigon.İnfrastructure.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Bigon.İnfrastructure.Services.Concrates
{
    public class FileService : IFileService
    {
        private readonly IHostEnvironment environment;

        public FileService(IHostEnvironment environment)
        {
            this.environment = environment;
        }
        public string Upload(IFormFile file)
        {
            string contentPath = environment.ContentRootPath;
            string extension = Path.GetExtension(file.FileName);
            string randomText = Guid.NewGuid().ToString();
            string fileName = $"{randomText}{extension}";
            string physicalPath = Path.Combine(contentPath, "wwwroot", "uploads", "img", fileName);
            using (FileStream fs = new FileStream(physicalPath, FileMode.CreateNew, FileAccess.Write))
            {
                file.CopyTo(fs);
            }
            return fileName;
        }
    }
}
