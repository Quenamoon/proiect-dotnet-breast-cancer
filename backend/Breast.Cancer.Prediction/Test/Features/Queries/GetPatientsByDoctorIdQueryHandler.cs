using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;

namespace Application.Features.Queries
{
    public class GetPatientsByDoctorIdQueryHandler : IRequestHandler<GetPatientsByDoctorIdQuery, IEnumerable<User>>
    {
        private readonly IUserRepository repository;

        public GetPatientsByDoctorIdQueryHandler(IUserRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<User>> Handle(GetPatientsByDoctorIdQuery query, CancellationToken cancellationToken)
        {
            var user = await repository.GetByIdAsync(query.Id);
            if (user == null)
            {
                throw new EntityNotFoundException("User does not exist");
            }
            if (user.UserType != UserType.Doctor)
                throw new ArgumentException("User is not a medical professional");
            return await repository.GetPatientsAsync(user);
        }
    }
}