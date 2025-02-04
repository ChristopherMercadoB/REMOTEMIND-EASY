using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Tls;
using REMOTEMIND_EASY.Core.Application.Helpers;
using REMOTEMIND_EASY.Core.Application.Interfaces.Services;
using REMOTEMIND_EASY.Core.Application.ViewModels.Comment;
using REMOTEMIND_EASY.Core.Application.ViewModels.User;

namespace REMOTEMIND_EASY.Presentation.WebApp.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserViewModel _vm;
        private readonly IUserService _userService;

        public CommentController(IHttpContextAccessor accessor, IUserService userService, ICommentService commentService)
        {
            _vm = accessor.HttpContext.Session.GetSession<UserViewModel>("user");
            _userService = userService;
            _commentService = commentService;
        }

        //public async Task<IActionResult> List(int? id)
        //{
        //    if (_vm.RoleId == 2)
        //    {
        //        var usert = await resultService.GetResultByUser(_vm.Id);
        //        ViewBag.Name = _vm.Name;

        //        return View(usert.Where(e => e.UserId == _vm.Id).ToList());
        //    }


        //    return View();
        //}

        public IActionResult Create()
        {
            if (_vm == null)
            {
                return RedirectToRoute(new {controller="User", action="Login"});
            }

            return View(new CommentSaveViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentSaveViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            string path = Path.Combine(Environment.CurrentDirectory, "Data", "comentarios_empleados.txt");
            vm.EmployeeId = _vm.Id;
            vm.EnterpriseId = _vm.EnterpriseId;
            await _commentService.CreateComment(vm, path);
            return RedirectToRoute(new { controller="Comment", action="Aceptar"});
        }

        public async Task<IActionResult> Index()
        {
            if (_vm == null)
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }else if (_vm.RoleId == 2)
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            return View(await _commentService.GetAllCommentsByEnterprise(_vm.Id));
        }

        public IActionResult Aceptar()
        {
            if (_vm == null)
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            return View();
        }


    }
}
