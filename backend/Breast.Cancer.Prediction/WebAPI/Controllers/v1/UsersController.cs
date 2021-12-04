using Application.Features.Commands;
using Application.Features.Queries;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Controllers.v1.Filters;
using WebAPI.Utils.RegexUtils;

namespace WebAPI.Controllers.v1
{

    [Route("api/users")]
    [ApiController]
    public class UsersController : BaseController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost][JwtAuthentication]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            /* var accessToken = Request.Headers[HeaderNames.Authorization];
             var handler = new JwtSecurityTokenHandler();
             var jwtToken = handler.ReadJwtToken(accessToken.ToString());
             var jti = jwtToken.Claims.First(claim => claim.Type == "email").Value;*/

            var accessToken = Request.Headers[HeaderNames.Authorization];
            var claims = JwtManager.GetPrincipal(accessToken);
            string userType = claims.FindFirst("UserType").Value;
            if(userType == "patient")
            {
                return Forbid("You don't have permission to create a new user!");
            }

            command.SetUserType(userType);

            if (!StringValidator.isValidEmail(command.Email))
            {
                return BadRequest("Invalid email!");
            }

            if (command.Password.Length < 8)
            {
                return BadRequest("Invalid password format!");
            }

            try
            {
                return Ok(await mediator.Send(command));
            }
            catch (EntityAlreadyExistsException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await mediator.Send(new GetUsersQuery()));
        }

        [HttpPost("login")][AllowAnonymous]
        public async Task<IActionResult> GetJwt([FromBody] LoginUserQuery command)
        {
            try
            {
                var user = await mediator.Send(command);
                return Ok(JwtManager.GenerateToken(user.Id, user.Email, user.UserType));
            }
            catch (Exception ex)
            {
                if(ex is InvalidCredentialsException || ex is EntityNotFoundException)
                {
                    return Unauthorized("Username or password is incorrect!");
                }
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            try
            {
                return Ok(await mediator.Send(command));
            }
            catch (EntityNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
