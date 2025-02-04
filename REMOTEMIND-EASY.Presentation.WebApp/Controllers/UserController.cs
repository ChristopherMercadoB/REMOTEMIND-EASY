using Microsoft.AspNetCore.Mvc;
using REMOTEMIND_EASY.Core.Application.Helpers;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Application.Interfaces.Services;
using REMOTEMIND_EASY.Core.Application.ViewModels.User;

namespace REMOTEMIND_EASY.Presentation.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserViewModel _vm;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserController(IHttpContextAccessor accessor, IUserService userService, IRoleService roleRepo)
        {
            _vm = accessor.HttpContext.Session.GetSession<UserViewModel>("user");
            _userService = userService;
            _roleService = roleRepo;
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (_vm != null)
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var user = await _userService.Login(vm);
            if (user != null)
            {
                 HttpContext.Session.SetSession<UserViewModel>("user", user);
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
            {
                vm.HasError = true;
                vm.Error = "Usuario o contrase;a incorrectos";
                return View(vm);
            }
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
            if (!ModelState.IsValid)
            {
                vm.Roles = await _roleService.GetAll();
                return View(vm);
            }
            if (_vm != null)
            {
                if (_vm.RoleId == 1)
                {
                    vm.EnterpriseId = _vm.Id;
                }
            }
            
            var result = await _userService.Rgister(vm);
            if (result.HasError)
            {
                vm.Roles = await _roleService.GetAll();
                return View(vm);
            }
            if (_vm == null)
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            else
            {
                return RedirectToRoute(new { controller = "User", action = "List" });
            }
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
            if (_vm == null)
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }else if (_vm.RoleId == 2)
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            var employee = await _userService.GetAll();
            ViewBag.Employees = employee.Where(e=>e.RoleId != _vm.RoleId).Count();
            return View(await _userService.GetAllByEnterprise(_vm.Id));
        }
    }
}
