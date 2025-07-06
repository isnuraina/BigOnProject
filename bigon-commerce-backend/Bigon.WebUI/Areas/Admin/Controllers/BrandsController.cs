using Bigon.Business.Modules.BrandsModule.Commands.BrandAddCommand;
using Bigon.Business.Modules.BrandsModule.Commands.BrandEditCommand;
using Bigon.Business.Modules.BrandsModule.Commands.BrandRemoveCommand;
using Bigon.Business.Modules.BrandsModule.Queries.BrandGetAllQuery;
using Bigon.Business.Modules.BrandsModule.Queries.BrandGetByIdQuery;
using Bigon.Business.Modules.ColorsModule.Queries.ColorGetByIdQuery;
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

        public async Task<IActionResult> Details(BrandGetByIdRequest request)
        {
            var response = await mediator.Send(request);

            return View(response);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BrandAddRequest model)
        {
            await mediator.Send(model);
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Edit(BrandGetByIdRequest request)
        {
            var response = await mediator.Send(request);

            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BrandEditRequest request)
        {
            await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }





        [HttpPost]
        public async Task<IActionResult> Delete(BrandRemoveRequest request)
        {
            //var model = db.Brands.FirstOrDefault(m => m.Id == id && m.DeletedBy == null);

            //if (model == null)
            //{
            //    Response.Headers.Add("error", "true");
            //    Response.Headers.Add("message", "Qeyd mövcud deyil");
            //    return Content("");
            //}

            //model.DeletedBy = 1;
            //model.DeletedAt = DateTime.Now;

            //db.SaveChanges();


            await mediator.Send(request);
            //var brands = db.Brands
            //   .Where(m => m.DeletedBy == null)
            //   .ToList();

            var response = await mediator.Send(new BrandGetAllRequest());

            return PartialView("_Body", response);
        }

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
