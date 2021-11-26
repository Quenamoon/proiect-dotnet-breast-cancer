﻿using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
                throw new EntityNotFoundException("User doesn't exist!");
            }

            if (user.Password != request.Password)
            {
                throw new InvalidCredentialsException("Password missmatch!");
            }
            return user;
        }
    }
}
