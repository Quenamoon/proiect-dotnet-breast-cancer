using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using ML;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class CreatePredictionCommandHandler : IRequestHandler<CreatePredictionCommand, Prediction>
    {
        private readonly IPredictionRepository repository;
        private readonly IUserRepository userRepository;

        public CreatePredictionCommandHandler(IPredictionRepository repository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
        }

        public async Task<Prediction> Handle(CreatePredictionCommand request, CancellationToken cancellationToken)
        {
            User user = await userRepository.GetByIdAsync(request.patientID);
            if(user == null)
            {
                throw new EntityNotFoundException();
            }

            if(user.UserType != UserType.Patient)
            {
                throw new InvalidPermissionException("You cannot access this feature!");
            }

            var prediction = new Prediction
            {
                Radius1 = request.Radius,
                Texture1 = request.Texture,
                Perimeter1 = request.Perimeter,
                Area1 = request.Area,
                Smoothness1 = request.Smoothness,
                Compactness1 = request.Compactness,
                Concavity1 = request.Concavity,
                ConcavePoints1 = request.ConcavePoints,
                Symmetry1 = request.Symmetry,
                FractalDimension1 = request.FractalDimension,
                Radius2 = request.Radius,
                Texture2 = request.Texture,
                Perimeter2 = request.Perimeter,
                Area2 = request.Area,
                Smoothness2 = request.Smoothness,
                Compactness2 = request.Compactness,
                Concavity2 = request.Concavity,
                ConcavePoints2 = request.ConcavePoints,
                Symmetry2 = request.Symmetry,
                FractalDimension2 = request.FractalDimension,
                Radius3 = request.Radius,
                Texture3 = request.Texture,
                Perimeter3 = request.Perimeter,
                Area3 = request.Area,
                Smoothness3 = request.Smoothness,
                Compactness3 = request.Compactness,
                Concavity3 = request.Concavity,
                ConcavePoints3 = request.ConcavePoints,
                Symmetry3 = request.Symmetry,
                FractalDimension3 = request.FractalDimension
            };

            var diagnosisPredictor = DiagnosisPredictor.GetInstance();

            prediction.Diagnosis = diagnosisPredictor.Predict(prediction);
            prediction.PredictionDate = DateTime.Now;
            prediction.patientID = request.patientID;

            await repository.AddAsync(prediction);

            return prediction;
        }
    }
}
