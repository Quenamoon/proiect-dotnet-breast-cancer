using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.v1
{
    public class PredictionDataRepository : IPredictionDataRepository
    {
        protected readonly PredictionDataContext context;

        public PredictionDataRepository(PredictionDataContext context)
        {
            this.context = context;
        }

        public async Task<PredictionData> AddAsync(PredictionData entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<PredictionData> DeleteAsync(PredictionData entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }
            context.Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<PredictionData>> GetAllAsync()
        {
            return await context.Set<PredictionData>().ToListAsync();
        }

        public async Task<PredictionData> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException($"{nameof(GetByIdAsync)} id must not be empty");
            }

            return await context.FindAsync<PredictionData>(id);
        }

        public async Task<PredictionData> UpdateAsync(PredictionData entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            context.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
