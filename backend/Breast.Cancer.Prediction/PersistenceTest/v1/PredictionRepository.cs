using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppContext = Persistence.Context.AppContext;

namespace Persistence.v1
{
    public class PredictionRepository : Repository<Prediction>, IPredictionRepository
    { 
        public PredictionRepository(AppContext context) : base(context)
        {
            
        }
        public async Task<IEnumerable<Prediction>> GetPredictionsAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentException($"{nameof(GetPredictionsAsync)} user should not be null");
            }

            return await context.Predictions.Where(prediction => prediction.patientID == user.Id).ToListAsync();
        }
    }
}
