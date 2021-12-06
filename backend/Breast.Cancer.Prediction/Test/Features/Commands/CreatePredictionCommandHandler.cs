using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class CreatePredictionCommandHandler : IRequestHandler<CreatePredictionCommand, PredictionData>
    {
        private readonly IPredictionDataRepository repository;

        public CreatePredictionCommandHandler(IPredictionDataRepository repository)
        {
            this.repository = repository;
        }
        public async Task<PredictionData> Handle(CreatePredictionCommand request, CancellationToken cancellationToken)
        {
            var prediction = new PredictionData
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

            /* TODO Apelez modul ML pe datele de mai sus */
            prediction.Diagnosis = false;
            prediction.PredictionDate = DateTime.Now;

            await repository.AddAsync(prediction);
            return prediction;
        }
    }
}
