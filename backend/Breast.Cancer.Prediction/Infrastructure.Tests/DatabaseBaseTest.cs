using System;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;


namespace Infrastructure.Tests
{
    public class DatabaseBaseTest : IDisposable
    {
        protected readonly UserContext context;

        public DatabaseBaseTest()
        {
            var options = new DbContextOptionsBuilder<UserContext>().UseInMemoryDatabase("TestDatabase").Options;
            context = new UserContext(options);
            context.Database.EnsureCreated();
            DatabaseInitializer.Initialize(context);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}