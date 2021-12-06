using Application.Features.Commands;
using Application.Features.Queries;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Threading.Tasks;
using WebAPI.Controllers.v1.Filters;

namespace WebAPI.Controllers.v1
{
    [Route("api/predictions")]
    [ApiController]
    public class PredictionController : BaseController
    {
        public PredictionController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [JwtAuthentication]
        public async Task<IActionResult> Create([FromBody] CreatePredictionCommand command)
        {
            var authorization = Request.Headers[HeaderNames.Authorization];
            var token = authorization.ToString();
            if (token == "")
                return Unauthorized("You don't have access to this feature");
            try
            {
                return Ok(await mediator.Send(command));
            }
            catch (EntityNotFoundException e)
            {
                return BadRequest("Invalid id!");
            }
            catch(InvalidPermissionException e)
            {
                return Forbid(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await mediator.Send(new GetPredictionsQuery()));
        }

        /*
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePredictionCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await mediator.Send(command));
        }
        */
    }
}
