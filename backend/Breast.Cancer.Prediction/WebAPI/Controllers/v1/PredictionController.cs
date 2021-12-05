using Application.Features.Commands;
using Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Create([FromBody] CreatePredictionCommand command)
        {
            try
            {
                return Ok(await mediator.Send(command));
            }
            catch (ArgumentException e)
            {
                return Conflict("Email already in use!");
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
