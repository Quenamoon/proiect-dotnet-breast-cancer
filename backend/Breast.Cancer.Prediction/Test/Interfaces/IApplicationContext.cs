using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationContext
    {
        Task<int> SaveChangesAsync();
    }
}