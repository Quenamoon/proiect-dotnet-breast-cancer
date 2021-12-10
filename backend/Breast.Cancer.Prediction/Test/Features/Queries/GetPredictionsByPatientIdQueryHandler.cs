using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries
{
    public class GetPredictionsByPatientIdQueryHandler : IRequestHandler<GetPredictionsByPatientIdQuery, IEnumerable<Prediction>>
    {
        private readonly IPredictionRepository predictionRepository;
        private readonly IUserRepository userRepository;

        public GetPredictionsByPatientIdQueryHandler(IPredictionRepository predictionRepository, IUserRepository userRepository)
        {
            this.predictionRepository = predictionRepository;
            this.userRepository = userRepository;
        }
        public async Task<IEnumerable<Prediction>> Handle(GetPredictionsByPatientIdQuery request, CancellationToken cancellationToken)
        {
            User user = await userRepository.GetByIdAsync(request.Id);
            if (user == null || user.UserType != UserType.Patient)
            {
                throw new EntityNotFoundException("Patient not found.");
            }
            return await predictionRepository.GetPredictionsAsync(user);
        }
    }
}
