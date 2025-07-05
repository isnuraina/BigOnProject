using Bigon.Business.Modules.ColorsModule.Commands.ColorAddCommand;
using Bigon.Business.Modules.ColorsModule.Queries.ColorGetAllQuery;
using Bigon.Business.Modules.ColorsModule.Queries.ColorGetByIdQuery;
using Bigon.İnfrastructure.Entities;
using Bigon.İnfrastructure.Repositories;
using Bigon.WebUI.Models.Persistences;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bigon.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorsController : Controller
    {
        private readonly IMediator mediator;

        public ColorsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(ColorGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }

        public async Task<IActionResult> Details(ColorGetByIdRequest request)
        {
            var response= await mediator.Send(request);
            return View(response);
        }







        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task < IActionResult> Create(ColorAddRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }



        ////public IActionResult Edit(int id)
        ////{
        ////    var model = db.Colors.FirstOrDefault(m => m.Id == id);
        ////    if (model == null)
        ////    {
        ////        return NotFound();
        ////    }
        ////    return View(model);
        ////}
        ////[HttpPost]
        ////public IActionResult Edit(Color model)
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
        //    var model = colorRepository.Get(m => m.Id == id);

        //    if (model == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(model);
        //}
        //[HttpPost]
        //public IActionResult Edit(Color model)
        //{
        //    //var entityModel = db.Colors.FirstOrDefault(m => m.Id == model.Id);
        //    //if (entityModel == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    //entityModel.Name = model.Name;
        //    //entityModel.HexCode = model.HexCode;
        //    //db.SaveChanges();
        //    colorRepository.Edit(model);
        //    colorRepository.Save();
        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    //var model = colorRepository.Get(m => m.Id == id);

        //    //var model = db.Colors.FirstOrDefault(m => m.Id == id && m.DeletedBy==null);
        //    //if (model == null)
        //    //{
        //    //    return Json(
        //    //        new
        //    //        {
        //    //            error = true,
        //    //            message = "Qeyd movcud deyil"
        //    //        });
        //    //}
        //    //db.Colors.Remove(model);
        //    //db.SaveChanges();
        //    colorRepository.Remove(id);
        //    colorRepository.Save();
        //    return Json(
        //            new
        //            {
        //                error = false,
        //                message = "Qeyd silindi!"
        //            });
        //}

    }
}
 