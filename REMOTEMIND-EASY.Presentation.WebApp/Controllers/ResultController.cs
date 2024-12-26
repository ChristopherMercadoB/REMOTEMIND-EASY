using Microsoft.AspNetCore.Mvc;
using REMOTEMIND_EASY.Core.Application.Interfaces.Services;

namespace REMOTEMIND_EASY.Presentation.WebApp.Controllers
{
    public class ResultController : Controller
    {
        private readonly IResultService resultService;

        public ResultController(IResultService resultService)
        {
            this.resultService = resultService;
        }

        public IActionResult List()
        {
            return View();
        }


    }
}
