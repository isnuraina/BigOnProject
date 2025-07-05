using Bigon.Business.Modules.BrandsModule.Queries.BrandGetAllQuery;
using Bigon.İnfrastructure.Entities;
using Bigon.İnfrastructure.Repositories;
using Bigon.WebUI.Models.Persistences;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bigon.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsController : Controller
    {
        private readonly IMediator mediator;

        public BrandsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        
        public async Task<IActionResult> Index(BrandGetAllRequest request)
        {
            var response = await mediator.Send(request);
           
            return View(response);
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Brand model)
        //{
        //    brandRepository.Add(model);
        //    brandRepository.Save();
        //    //db.Brands.Add(model);
        //    //db.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}
        //public IActionResult Details(int id)
        //{
        //    //var model = db.Brands.FirstOrDefault(m => m.Id == id);
        //    var model = brandRepository.Get(m => m.Id == id);
        //    if (model == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(model);
        //}
        ////public IActionResult Edit(int id)
        ////{
        ////    var model = db.Brands.FirstOrDefault(m => m.Id == id);
        ////    if (model == null)
        ////    {
        ////        return NotFound();
        ////    }
        ////    return View(model);
        ////}
        ////[HttpPost]
        ////public IActionResult Edit(Brand model)
        ////{
        ////    model.LastModifiedAt = DateTime.Now;
        ////    model.LastModifiedBy = 1;
        ////    db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        ////    db.Entry(model).Property(m => m.CreatedAt).IsModified = false;
        ////    db.Entry(model).Property(m => m.CreatedBy).IsModified = false;
        ////    db.SaveChanges();
        ////    return RedirectToAction(nameof(Index));
        ////}



        //public IActionResult Edit(int id)
        //{
        //    //var model = db.Brands.FirstOrDefault(m => m.Id == id);
        //    var model = brandRepository.Get(m => m.Id == id);
        //    if (model == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(model);
        //}
        //[HttpPost]
        //public IActionResult Edit(Brand model)
        //{
        //    //var entityModel = db.Brands.FirstOrDefault(m => m.Id == model.Id);
        //    //if (entityModel == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    //entityModel.Name = model.Name;
        //    //db.SaveChanges();
        //    brandRepository.Edit(model);
        //    brandRepository.Save();
        //    return RedirectToAction(nameof(Index));
        //}

        ////[HttpPost]
        ////public IActionResult Delete(int id)
        ////{
        ////    var model = db.Brands.FirstOrDefault(m => m.Id == id && m.DeletedBy == null);

        ////    if (model == null)
        ////    {
        ////        Response.Headers.Add("error", "true");
        ////        Response.Headers.Add("message", "Qeyd mövcud deyil");
        ////        return Content(""); 
        ////    }

        ////    model.DeletedBy = 1; 
        ////    model.DeletedAt = DateTime.Now;

        ////    db.SaveChanges();

        ////    var brands = db.Brands
        ////       .Where(m => m.DeletedBy == null)
        ////       .ToList();

        ////    return PartialView("_Body", brands);
        ////}
        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    var model = brandRepository.Get(m => m.Id == id && m.DeletedBy == null);

        //    if (model == null)
        //    {
        //        Response.Headers.Add("error", "true");
        //        Response.Headers.Add("message", "Qeyd mövcud deyil");
        //        return Content("");
        //    }

        //    // Soft delete
        //    model.DeletedBy = 1;
        //    model.DeletedAt = DateTime.Now;

        //    brandRepository.Edit(model);
        //    brandRepository.Save();

        //    // Yenidən brands siyahısını götürüb partial view qaytarırıq
        //    var brands = brandRepository.GetAll(m => m.DeletedBy == null);

        //    return PartialView("_Body", brands);
        //}


    }
}
