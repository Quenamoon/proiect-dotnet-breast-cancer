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
    public class GetPredictionsQueryHandler : IRequestHandler<GetPredictionsQuery, IEnumerable<PredictionData>>
    {
        private readonly IPredictionDataRepository repository;

        public GetPredictionsQueryHandler(IPredictionDataRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<PredictionData>> Handle(GetPredictionsQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetAllAsync();
        }
    }
}
