using Application.Features.Commands;
using Application.Features.Queries;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Net.Http.Headers;
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

        [HttpPost]
        [JwtAuthentication]//todo [JwtAuthentication] should not allow access
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var authorization = Request.Headers[HeaderNames.Authorization];
            var token = authorization.ToString();
            if (token == "")
                return Forbid("You don't have permission to create a new user!");
            if (token.StartsWith("Bearer "))
                token = token.Substring("Bearer ".Length);
            var claims = JwtManager.GetPrincipal(token);
            UserType loggedType = claims.FindFirst("userType").Value.ParseEnum<UserType>();
            if (loggedType == UserType.Patient)
            {
                return Forbid("You don't have permission to create a new user!");
            }
            command.UserType = ((loggedType == UserType.Admin) ? UserType.Doctor : UserType.Patient).ToString();

            if (!StringValidator.isValidEmail(command.Email))
            {
                return BadRequest("Invalid email!");
            }

            if (command.Password.Length < 8)
            {
                return BadRequest("Invalid password format!");
            }

            command.CreatedBy = Guid.Parse(claims.FindFirst("id").Value);

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

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> GetJwt([FromBody] LoginUserQuery command)
        {
            try
            {
                var user = await mediator.Send(command);
                return Ok(JwtManager.GenerateToken(user.Id, user.Email, user.UserTypeString));
            }
            catch (Exception ex)
            {
                if (ex is InvalidCredentialsException || ex is EntityNotFoundException)
                {
                    return Unauthorized("Username or password is incorrect!");
                }
                throw;
            }
        }

        [HttpGet("patients")]
        [JwtAuthentication]
        public async Task<IActionResult> GetPatients()
        {
            var authorization = Request.Headers[HeaderNames.Authorization];
            var token = authorization.ToString();
            if (token == "")
                return Forbid("You don't have permission!");
            if (token.StartsWith("Bearer "))
                token = token.Substring("Bearer ".Length);
            var claims = JwtManager.GetPrincipal(token);
            Guid userId = Guid.Parse(claims.FindFirst("id").Value);
            GetPatientsByDoctorIdQuery query = new GetPatientsByDoctorIdQuery();
            query.Id=userId;
            try
            {
                var patients= await mediator.Send(query);
                return Ok(patients);
            }
            catch(Exception e) when (
            e is ArgumentException
            || e is EntityNotFoundException)
            {
                return BadRequest("Medic not found.");
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

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteUserCommand command)
        {
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
