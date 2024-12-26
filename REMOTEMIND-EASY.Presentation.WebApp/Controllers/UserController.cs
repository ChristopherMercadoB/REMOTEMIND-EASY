using Microsoft.AspNetCore.Mvc;
using REMOTEMIND_EASY.Core.Application.Helpers;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Application.Interfaces.Services;
using REMOTEMIND_EASY.Core.Application.ViewModels.User;

namespace REMOTEMIND_EASY.Presentation.WebApp.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService _userService;
        private readonly IUserRepository _repo;
        private readonly IRoleService _roleService;

        public UserController(IUserService userService, IUserRepository repo, IRoleService roleRepo)
        {
            _userService = userService;
            _repo = repo;
            _roleService = roleRepo;
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            var user = await _userService.Login(vm);
            if (user != null)
            {
                 HttpContext.Session.SetSession<UserViewModel>("user", user);
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View();
        }

        public async Task<IActionResult> Register()
        {
            UserSaveViewModel vm = new();
            vm.Roles = await _roleService.GetAll();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserSaveViewModel vm)
        {

            await _userService.Rgister(vm);
            return RedirectToRoute(new {controller="User", action="Login"});
        }


        public IActionResult Logout()
        {
            var active = HttpContext.Session.GetSession<UserViewModel>("user");
            if (active != null)
            {
                HttpContext.Session.Remove("user");
            }
            return RedirectToRoute(new { controller = "User", action = "Login" });
        }


        public async Task<IActionResult> List()
        {
            var employee = await _repo.GetAllNotAdmin();
            ViewBag.Employees = employee.Count();
            return View(await _userService.GetAll());
        }
    }
}
