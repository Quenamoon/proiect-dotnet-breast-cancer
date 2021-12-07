using Domain.Entities;
using FakeItEasy;
using Xunit;

namespace Infrastructure.Tests.Service
{
    public class GetUserByIdQueryHandlerTests
    {
        private readonly Application.Features.Queries.GetUserByIdQueryHandler handler;
        private readonly Application.Interfaces.IUserRepository repository;

        public GetUserByIdQueryHandlerTests()
        {
            this.repository = A.Fake<Application.Interfaces.IUserRepository>();
            this.handler = new Application.Features.Queries.GetUserByIdQueryHandler(this.repository);
        }

        [Fact]
        public async void Given_GetUserByIdQueryHandler_When_HandleIsCalled_Then_GetByIdAsyncIsCalled()
        {
            await handler.Handle(new Application.Features.Queries.GetUserByIdQuery(), default);
            A.CallTo(() => repository.GetByIdAsync(A<System.Guid>._)).MustHaveHappenedOnceExactly();
        }
    }
}
