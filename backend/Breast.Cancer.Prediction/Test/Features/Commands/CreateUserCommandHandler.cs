using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User databaseUser = await repository.GetByEmailAsync(request.Email);
            if (!(databaseUser == null || databaseUser.Id == Guid.Empty))
            {
                throw new EntityAlreadyExistsException("Email already in use!");
            }

            string RequestedUserType = (request.GetUserType() == "admin") ? "medic" : "patient";
            var user = new User
            {
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                UserType = RequestedUserType
            };
            await repository.AddAsync(user);
            return user.Id;
        }
    }
}
