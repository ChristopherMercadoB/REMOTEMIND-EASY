using Microsoft.AspNetCore.Mvc;

namespace REMOTEMIND_EASY.Presentation.WebApp.Controllers
{
    public class LandingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
