using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using REMOTEMIND_EASY.Core.Application.Helpers;
using REMOTEMIND_EASY.Core.Application.Interfaces.Services;
using REMOTEMIND_EASY.Core.Application.ViewModels.User;
using REMOTEMIND_EASY.Core.Application.ViewModels.UserResponse;

namespace REMOTEMIND_EASY.Presentation.WebApp.Controllers
{
    public class UserResponseController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserResponseService _service;
        private readonly IQuestionService _questionService;
        private readonly IResponseService _responseService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IResultService _resultService;
        private readonly UserViewModel _vm;

        public UserResponseController(IHttpContextAccessor accessor, IMapper mapper, IUserResponseService service, IQuestionService questionService, IResponseService userService, IHttpContextAccessor contextAccessor, IResultService resultService)
        {
            _mapper = mapper;
            _service = service;
            _questionService = questionService;
            _responseService = userService;
            _contextAccessor = contextAccessor;
            _resultService = resultService;
            _vm = accessor.HttpContext.Session.GetSession<UserViewModel>("user");
        }

        public IActionResult Index()
        {
            if (_vm == null)
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            return View();
        }

        public async Task<IActionResult> Questions()
        {
            if (_vm == null)
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            var questions = await _questionService.GetAll();

            var userResponses = new List<UserResponseSaveViewModel>();

            foreach (var question in questions)
            {
                userResponses.Add(new UserResponseSaveViewModel
                {
                    QuestionId = question.Id,
                    Responses = await _responseService.GetAll() 
                });
            }

            ViewBag.Questions = questions; 
            return View(userResponses); 
        }

        [HttpPost]
        public async Task<IActionResult> Questions(List<UserResponseSaveViewModel> vm)
        {
            if (!ModelState.IsValid)
            {
                var questions = await _questionService.GetAll();

               vm = new List<UserResponseSaveViewModel>();

                foreach (var question in questions)
                {
                    vm.Add(new UserResponseSaveViewModel
                    {
                        QuestionId = question.Id,
                        Responses = await _responseService.GetAll()
                    });
                }
                ViewBag.Questions = questions;

                return View(vm);
            }
            var user = HttpContext.Session.GetSession<UserViewModel>("user");
            foreach (var item in vm)
            {
                item.UserId = user.Id;
            }
            await _service.CreateMany(vm);
            await _resultService.CreateResult(user.Id);
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

    }
}
