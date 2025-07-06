using Bigon.Business.Modules.BrandsModule.Queries.BrandGetByIdQuery;
using Bigon.Business.Modules.ColorsModule.Commands.ColorAddCommand;
using Bigon.Business.Modules.ColorsModule.Commands.ColorEditCommand;
using Bigon.Business.Modules.ColorsModule.Commands.ColorRemoveCommand;
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

        public async Task<IActionResult> Details(BrandGetByIdRequest request)
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



        public async Task<IActionResult> Edit(BrandGetByIdRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ColorEditRequest request)
        {
            var response = await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task< IActionResult> Delete(ColorRemoveRequest request)
        {
            await mediator.Send(request);
            return Json(
                    new
                    {
                        error = false,
                        message = "Qeyd silindi!"
                    });
        }

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


    }
}
 