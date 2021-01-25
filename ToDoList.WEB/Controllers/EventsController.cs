using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoList.Bussiness.Abstract;
using ToDoList.Entities.Concrete;

namespace ToDoList.WEB.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly IEventsService eventsService;
        private readonly UserManager<AppUser> userManager;

        public EventsController(IEventsService eventsService,UserManager<AppUser> userManager)
        {
            this.eventsService = eventsService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> AddEvent(Event model)
        {
            var userName=User.Identity.Name;
            var user =await userManager.FindByNameAsync(userName);
            model.AppUserId = user.Id;

            eventsService.Add(model);
            return Json("200");
        }

        [HttpPost]
        public  JsonResult UpdateEvent(Event model)
        {
            eventsService.Update(model);
            return Json("200");
        }

        [HttpPost]
        public JsonResult DeleteEvent(Event model)
        {
            eventsService.Delete(model);
            return Json("200");
        }

        public async Task<JsonResult> GetEvents()
        {
            var userName = User.Identity.Name;
            var user = await userManager.FindByNameAsync(userName);

            var model = eventsService.GetList(i=>i.AppUserId==user.Id);
            return Json(model);
        }
    }
}
