using Bigon.Business.Modules.BlogPostModule.Commands.BlogPostAddCommand;
using Bigon.Business.Modules.BlogPostModule.Commands.BlogPostRemoveCommand;
using Bigon.Business.Modules.BlogPostModule.Queries.BlogPostGetAllQuery;
using Bigon.Business.Modules.ColorsModule.Commands.ColorRemoveCommand;
using Bigon.İnfrastructure.Entities;
using Bigon.İnfrastructure.Services.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Bigon.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostsController : Controller
    {
        private readonly IMediator mediator;

        public BlogPostsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(BlogPostGetAllRequest request)
        {
            var response = await mediator.Send(request);
            return View(response);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BlogPostAddRequest request)
        {
            var response = await mediator.Send(request);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(BlogPostRemoveRequest request)
        {
            await mediator.Send(request);
            return Json(
                    new
                    {
                        error = false,
                        message = "Qeyd silindi!"
                    });
        }
    }
}
