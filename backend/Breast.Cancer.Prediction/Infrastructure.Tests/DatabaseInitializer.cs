using System;
using System.Linq;
using Domain.Entities;
using AppContext = Persistence.Context.AppContext;

namespace Infrastructure.Tests
{
    public class DatabaseInitializer
    {
        public static void Initialize(AppContext context)
        {
            if (context.Users.Any())
                return;
            Seed(context);
        }

        private static void Seed(AppContext context)
        {
            var users = new[]
            {
                new User
                {
                    Id=Guid.Parse("c20efcc7-a038-4934-a567-a62843b580af"),
                    Email ="string1@adm.in",
                    UserType = UserType.Admin,
                    Password="stringadmin"
                },
                new User
                {
                    Id=Guid.Parse("d27d5896-a737-43ff-a09d-ba6d471bbd27"),
                    Email ="stringm@doc.tor",
                    UserType = UserType.Doctor,
                    Password="stringdoctor"
                },
                new User
                {
                    Id=Guid.Parse("d615d85b-d65d-409c-b0f3-5c9cf7ae3d6e"),
                    Email ="stringp@patie.nt",
                    UserType = UserType.Patient,
                    Password="stringpatient"
                }
            };
            context.Users.AddRange(users);
            context.SaveChangesAsync();
        }
    }

}