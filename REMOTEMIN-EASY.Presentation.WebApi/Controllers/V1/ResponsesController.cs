using Microsoft.AspNetCore.Mvc;
using REMOTEMIND_EASY.Core.Application.Features.Responses.Queries.GetAllQuery;

namespace REMOTEMIN_EASY.Presentation.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    public class ResponsesController : BaseApiController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllResponsesQuery()));
        }
    }
}
