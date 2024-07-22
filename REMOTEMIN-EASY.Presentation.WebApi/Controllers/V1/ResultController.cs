using Microsoft.AspNetCore.Mvc;
using REMOTEMIND_EASY.Core.Application.Features.Results.Command.CreateCommand;
using REMOTEMIND_EASY.Core.Application.Features.Results.Queries.GetAll;
using REMOTEMIND_EASY.Core.Application.Features.Results.Queries.GetByUserId;

namespace REMOTEMIN_EASY.Presentation.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    //[Authorize]
    public class ResultController : BaseApiController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllResultQuery()));
        }

        [HttpGet("{id}")]
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await Mediator.Send(new GetResultByUserIdQuery { UserId = id }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateResultCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
