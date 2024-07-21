using MediatR;
using Microsoft.AspNetCore.Mvc;
using REMOTEMIND_EASY.Core.Application.DTO_S.Authentication;

namespace REMOTEMIN_EASY.Presentation.WebApi.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost("Authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await Mediator.Send(new AuthenticateUserCommand()
            {
                Email = request.Email,
                Password = request.Password
            }));
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            return Ok(await Mediator.Send(new RegisterUserCommand()
            {
                Email = request.Email,
                Password = request.Password,
                Name = request.Name,
                Identification = request.Identification,
                ConfirmPassword = request.ConfirmPassword,
                UserName = request.UserName
            }));
        }
    }
}
