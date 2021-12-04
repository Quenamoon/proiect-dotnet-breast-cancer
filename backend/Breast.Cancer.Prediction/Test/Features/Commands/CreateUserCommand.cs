using MediatR;
using System;

namespace Application.Features.Commands
{
    public class CreateUserCommand : IRequest<Guid>
    {
        private string user_type;
        public string Email { get; set; }

        public string Password { get; set; }

        public void SetUserType(string userType)
        {
            this.user_type = userType;
        }

        public string GetUserType()
        {
            return user_type;
        }
    }
}
