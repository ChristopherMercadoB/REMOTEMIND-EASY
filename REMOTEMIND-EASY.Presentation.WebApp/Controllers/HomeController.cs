using Microsoft.AspNetCore.Mvc;
using REMOTEMIND_EASY.Core.Application.Helpers;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Application.Interfaces.Services;
using REMOTEMIND_EASY.Core.Application.ViewModels.User;
using REMOTEMIND_EASY.Presentation.WebApp.Models;
using System.Diagnostics;

namespace REMOTEMIND_EASY.Presentation.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _repo;
        private readonly IResultService _rservice;
        private readonly UserViewModel _vm;

        public HomeController(ILogger<HomeController> logger, IUserRepository repo, IHttpContextAccessor accessor, IResultService rservice)
        {
            _logger = logger;
            _repo = repo;
            _vm = accessor.HttpContext.Session.GetSession<UserViewModel>("user");
            _rservice = rservice;
        }

        public async Task<IActionResult> Index()
        {
            if (_vm == null)
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            if (_vm.RoleId == 1)
            {
                var etest = await _rservice.GetAll();
                ViewBag.ET = etest.Where(e => e.EnterpriseId == _vm.Id).Count();
                var employee = await _repo.GetAllNotAdmin();
                ViewBag.Employees = employee.Where(e => e.EnterpriseId == _vm.Id).Count();
                return View();
            }           
            var tests = await _rservice.GetAll();
            ViewBag.Tests = tests.Where(e => e.UserId == _vm.Id).Count();
            var user = _vm;
            return View();
        }
        
    }
}
