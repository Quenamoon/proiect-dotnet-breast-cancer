using System;
using Microsoft.EntityFrameworkCore;
using AppContext = Persistence.Context.AppContext;

namespace Infrastructure.Tests
{
    public class DatabaseBaseTest : IDisposable
    {
        protected readonly AppContext context;

        public DatabaseBaseTest()
        {
            var options = new DbContextOptionsBuilder<AppContext>().UseInMemoryDatabase("TestDatabase").Options;
            context = new AppContext(options);
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