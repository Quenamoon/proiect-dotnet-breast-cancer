using Domain.Entities;
using FakeItEasy;
using Xunit;

namespace Infrastructure.Tests.Service
{
    public class UpdateUserCommandHandlerTests
    {
        private readonly Application.Features.Commands.UpdateUserCommandHandler handler;
        private readonly Application.Interfaces.IUserRepository repository;

        public UpdateUserCommandHandlerTests()
        {
            this.repository = A.Fake<Application.Interfaces.IUserRepository>();
            this.handler = new Application.Features.Commands.UpdateUserCommandHandler(this.repository);
        }

        [Fact]
        public async void Given_UpdateUserCommandHandler_When_HandleIsCalled_Then_UpdateAsyncUserIsCalled()
        {
            await handler.Handle(new Application.Features.Commands.UpdateUserCommand(),default);
            A.CallTo(() => repository.UpdateAsync(A<User>._)).MustHaveHappenedOnceExactly();
        }
    }
}
