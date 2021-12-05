using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class PredictionDataContext : DbContext, IApplicationContext
    {
        public PredictionDataContext()
        {

        }
        public PredictionDataContext(DbContextOptions<PredictionDataContext> options) : base(options)
        {

        }

        public DbSet<PredictionData> Predictions { get; set; }
        public DbSet<User> Users { get ; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
