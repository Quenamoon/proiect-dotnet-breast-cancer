using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<PredictionData> Predictions { get; set; }
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync();
    }
}