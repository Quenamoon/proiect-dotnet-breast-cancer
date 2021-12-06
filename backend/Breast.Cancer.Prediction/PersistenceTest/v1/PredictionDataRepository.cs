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
    public class PredictionDataRepository : Repository<PredictionData>, IPredictionDataRepository
    { 
        public PredictionDataRepository(AppContext context) : base(context)
        {
            
        }
    }
}
