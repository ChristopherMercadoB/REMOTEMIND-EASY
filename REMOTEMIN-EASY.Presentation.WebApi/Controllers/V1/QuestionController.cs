using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using REMOTEMIND_EASY.Core.Application.Features.Questions.Queries.GetAllQuery;

namespace REMOTEMIN_EASY.Presentation.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    //[Authorize]
    public class QuestionController : BaseApiController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllQuestionQuery()));
        }
    }
}
