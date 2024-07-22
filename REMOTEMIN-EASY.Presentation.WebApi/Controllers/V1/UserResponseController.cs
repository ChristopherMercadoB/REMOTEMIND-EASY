using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using REMOTEMIND_EASY.Core.Application.Features.Questions.Queries.GetAllQuery;
using REMOTEMIND_EASY.Core.Application.Features.UserResponses.Command;
using REMOTEMIND_EASY.Core.Application.Features.UserResponses.Queries.GetAllQuery;
using REMOTEMIND_EASY.Core.Application.Features.UserResponses.Queries.GetByUserIdQuery;
using System.Net.Mime;

namespace REMOTEMIN_EASY.Presentation.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    //[Authorize]
    public class UserResponseController : BaseApiController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllUserResponseQuery()));
        }

        [HttpGet("{id}")]
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await Mediator.Send(new GetUserResponseByUserIdQuery { UserId = id }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateUserResponseCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
