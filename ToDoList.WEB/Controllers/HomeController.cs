using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoList.Bussiness.Abstract;
using ToDoList.Entities.Concrete;
using ToDoList.Entities.DTO.AppUserDTO;

namespace ToDoList.WEB.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapperService mapperService;
        private readonly SignInManager<AppUser> signInManager;

        public HomeController(UserManager<AppUser> userManager, IMapperService mapperService, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.mapperService = mapperService;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(UserSignInDto model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);
                return RedirectToAction("Index","Events");
            }
            else
            {
                ModelState.AddModelError("", " Kullanıcı adı veya şifre bulunumadı.");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserAddDto model)
        {
            var user = mapperService.Mapper.Map<AppUser>(model);
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("LogIn");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("LogIn");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}

