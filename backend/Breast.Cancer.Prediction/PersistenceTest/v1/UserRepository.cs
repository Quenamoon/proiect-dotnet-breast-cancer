using Application.Interfaces;
using Domain.Entities;
using Persistence.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Persistence.v1
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(UserContext context): base(context)
        {
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            if (email == null)
            {
                throw new ArgumentException($"{nameof(GetByEmailAsync)} email should not be null");
            }

            return await context.Users
                    .Where(u => u.Email == email)
                    .FirstOrDefaultAsync();

           //TODO validation for user?
        }

        public async Task<IEnumerable<User>> GetPatientsAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentException($"{nameof(GetPatientsAsync)} user should not be null");
            }

            return await context.Users.Where(p => p.CreatedBy == user.Id).ToListAsync();
        }
    }
}
