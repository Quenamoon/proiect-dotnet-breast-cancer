using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class AppContext : DbContext, IApplicationContext
    {
        public AppContext()
        {

        }
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Prediction> Predictions { get; set; }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
