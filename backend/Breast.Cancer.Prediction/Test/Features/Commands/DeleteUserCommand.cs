using MediatR;
using System;

namespace Application.Features.Commands
{
    public class DeleteUserCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
