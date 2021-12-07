using Domain.Entities;
using FakeItEasy;
using Xunit;

namespace Infrastructure.Tests.Service
{
    public class GetUsersQueryHandlerTests
    {
        private readonly Application.Features.Queries.GetUsersQueryHandler handler;
        private readonly Application.Interfaces.IUserRepository repository;

        public GetUsersQueryHandlerTests()
        {
            this.repository = A.Fake<Application.Interfaces.IUserRepository>();
            this.handler = new Application.Features.Queries.GetUsersQueryHandler(this.repository);
        }

        [Fact]
        public async void Given_GetUsersQueryHandler_When_HandleIsCalled_Then_GetAllAsyncIsCalled()
        {
            await handler.Handle(new Application.Features.Queries.GetUsersQuery(),default);
            A.CallTo(() => repository.GetAllAsync()).MustHaveHappenedOnceExactly();
        }
    }
}
