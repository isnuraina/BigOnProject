using Bigon.İnfrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bigon.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostsController : Controller
    {
        private readonly DbContext db;
        private readonly IWebHostEnvironment environment;

        public BlogPostsController(DbContext db,IWebHostEnvironment environment)
        {
            this.db = db;
            this.environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BlogPost model,IFormFile file)
        {
            string contentPath = environment.ContentRootPath;
            string extension = Path.GetExtension(file.FileName);
            string randomText = Guid.NewGuid().ToString();
            string fileName = $"{randomText}{extension}";
            string physicalPath = Path.Combine(contentPath, "wwwroot","uploads","img",fileName);
            using(FileStream fs=new FileStream(physicalPath, FileMode.CreateNew, FileAccess.Write))
            {
                file.CopyTo(fs);
            }
            model.ImagePath = fileName;
            model.Slug = model.Title;
            db.Add(model);
            db.SaveChanges();
            return View();
        }
    }
}
