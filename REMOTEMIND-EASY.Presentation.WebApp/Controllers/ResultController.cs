using Microsoft.AspNetCore.Mvc;
using REMOTEMIND_EASY.Core.Application.Helpers;
using REMOTEMIND_EASY.Core.Application.Interfaces.Services;
using REMOTEMIND_EASY.Core.Application.ViewModels.User;

namespace REMOTEMIND_EASY.Presentation.WebApp.Controllers
{
    public class ResultController : Controller
    {
        private readonly IResultService resultService;
        private readonly UserViewModel _vm;
        private readonly IUserService _userService;

        public ResultController(IResultService resultService, IHttpContextAccessor accessor, IUserService userService)
        {
            this.resultService = resultService;
            _vm = accessor.HttpContext.Session.GetSession<UserViewModel>("user");
            _userService = userService;
        }

        public async Task<IActionResult> List(int id)
        {
            if (_vm == null)
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            if (id == null)
            {
                id = _vm.Id;
            }
            if (_vm.RoleId == 2)
            {
                var usert = await resultService.GetResultByUser(_vm.Id);
                ViewBag.Name = _vm.Name;

                return View(usert.Where(e => e.UserId == _vm.Id).ToList());
            }
            else 
            {
               var usert = await resultService.GetResultByUser(id);
               var user = await _userService.GetById(id);
               ViewBag.Name = user.Name;
               return View(usert.Where(e=>e.UserId == id).ToList());

            }


        }


    }
}
