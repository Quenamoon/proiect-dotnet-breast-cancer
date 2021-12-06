using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppContext = Persistence.Context.AppContext;

namespace Persistence.v1
{
    public class PredictionRepository : Repository<Prediction>, IPredictionRepository
    { 
        public PredictionRepository(AppContext context) : base(context)
        {
            
        }
    }
}
