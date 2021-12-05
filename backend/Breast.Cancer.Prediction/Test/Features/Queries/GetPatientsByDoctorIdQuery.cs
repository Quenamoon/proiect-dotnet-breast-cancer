using System;
using System.Collections.Generic;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries
{
    public class GetPatientsByDoctorIdQuery : IRequest<IEnumerable<User>>
    {
       public Guid Id { get; set; }
    }
}
