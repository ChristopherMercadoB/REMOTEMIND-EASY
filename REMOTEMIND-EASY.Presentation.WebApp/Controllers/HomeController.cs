using Microsoft.AspNetCore.Mvc;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Presentation.WebApp.Models;
using System.Diagnostics;

namespace REMOTEMIND_EASY.Presentation.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _repo;

        public HomeController(ILogger<HomeController> logger, IUserRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var employee = await _repo.GetAllNotAdmin();
            ViewBag.Employees = employee.Count();
            return View();
        }
        
        public IActionResult EmployeeHome()
        {
            return View();
        }
    }
}
