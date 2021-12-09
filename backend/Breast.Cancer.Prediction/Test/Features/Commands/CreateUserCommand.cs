using Domain.Entities;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace Application.Features.Commands
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string UserType { get; set; }

        public Guid CreatedBy { get; set; }
    }
}
