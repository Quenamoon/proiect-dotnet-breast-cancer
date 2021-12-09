﻿using MediatR;
using System;


namespace Application.Features.Commands
{
    public class UpdateUserCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
       
        public string Email { get; set; }

        public string Password { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string UserType { get; set; }

        public Guid CreatedBy { get; set; }
    }
}
