using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPredictionRepository : IRepository<Prediction>
    {
        Task<IEnumerable<Prediction>> GetPredictionsAsync(User user);
    }
}
