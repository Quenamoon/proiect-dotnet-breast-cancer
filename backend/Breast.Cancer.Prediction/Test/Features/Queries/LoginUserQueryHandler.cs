using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace Application.Features.Queries
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, User>
    {
        private readonly IUserRepository repository;

        public LoginUserQueryHandler(IUserRepository repository)
        {
            this.repository = repository;
        }
        public async Task<User> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            User user = await repository.GetByEmailAsync(request.Email);
            if (user == null || user.Id == Guid.Empty)
            {
                throw new EntityNotFoundException("Username is incorrect");
            }

            if(!BC.Verify(request.Password, user.Password))
            {
                throw new InvalidCredentialsException("Password mismatch!");
            }

            return user;
        }
    }
}
