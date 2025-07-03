using Bigon.İnfrastructure.Entities;
using Bigon.İnfrastructure.Repositories;
using Bigon.WebUI.Models.Persistences;
using Microsoft.AspNetCore.Mvc;

namespace Bigon.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorsController : Controller
    {
        private readonly DataContext db;
        private readonly IColorRepository colorRepository;
        public ColorsController(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }
        public IActionResult Index()
        {

            //var colors = db.Colors
            //    .Where(m => m.DeletedBy == null)
            //    .ToList();
            var colors = colorRepository.GetAll(m => m.DeletedBy == null);
            return View(colors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Color model)
        {
            colorRepository.Add(model);
            colorRepository.Save();
            //db.Colors.Add(model);
            //db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            //var model=db.Colors.FirstOrDefault(m => m.Id == id);

            var model = colorRepository.Get(m => m.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }


        //public IActionResult Edit(int id)
        //{
        //    var model = db.Colors.FirstOrDefault(m => m.Id == id);
        //    if (model == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(model);
        //}
        //[HttpPost]
        //public IActionResult Edit(Color model)
        //{
        //    model.LastModifiedAt = DateTime.Now;
        //    model.LastModifiedBy = 1;
        //    db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    db.Entry(model).Property(m => m.CreatedAt).IsModified = false;
        //    db.Entry(model).Property(m => m.CreatedBy).IsModified = false;
        //    db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}



        public IActionResult Edit(int id)
        {
            var model = colorRepository.Get(m => m.Id == id);

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Color model)
        {
            //var entityModel = db.Colors.FirstOrDefault(m => m.Id == model.Id);
            //if (entityModel == null)
            //{
            //    return NotFound();
            //}
            //entityModel.Name = model.Name;
            //entityModel.HexCode = model.HexCode;
            //db.SaveChanges();
            colorRepository.Edit(model);
            colorRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            //var model = colorRepository.Get(m => m.Id == id);

            //var model = db.Colors.FirstOrDefault(m => m.Id == id && m.DeletedBy==null);
            //if (model == null)
            //{
            //    return Json(
            //        new
            //        {
            //            error = true,
            //            message = "Qeyd movcud deyil"
            //        });
            //}
            //db.Colors.Remove(model);
            //db.SaveChanges();
            colorRepository.Remove(id);
            colorRepository.Save();
            return Json(
                    new
                    {
                        error = false,
                        message = "Qeyd silindi!"
                    });
        }

    }
}
 