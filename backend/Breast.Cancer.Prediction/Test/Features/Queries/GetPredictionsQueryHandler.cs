using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries
{
    public class GetPredictionsQueryHandler : IRequestHandler<GetPredictionsQuery, IEnumerable<Prediction>>
    {
        private readonly IPredictionRepository repository;

        public GetPredictionsQueryHandler(IPredictionRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<Prediction>> Handle(GetPredictionsQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetAllAsync();
        }
    }
}
