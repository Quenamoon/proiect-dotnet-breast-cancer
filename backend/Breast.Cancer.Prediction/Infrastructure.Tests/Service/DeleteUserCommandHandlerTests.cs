using Domain.Entities;
using FakeItEasy;
using Xunit;

namespace Infrastructure.Tests.Service
{
    public class DeleteUserCommandHandlerTests
    {
        private readonly Application.Features.Commands.DeleteUserCommandHandler handler;
        private readonly Application.Interfaces.IUserRepository repository;

        public DeleteUserCommandHandlerTests()
        {
            this.repository = A.Fake<Application.Interfaces.IUserRepository>();
            this.handler = new Application.Features.Commands.DeleteUserCommandHandler(this.repository);
        }

        [Fact]
        public async void Given_DeleteUserCommandHandler_When_HandleIsCalled_Then_DeleteAsyncUserIsCalled()
        {
            await handler.Handle(new Application.Features.Commands.DeleteUserCommand(),default);
            A.CallTo(() => repository.DeleteAsync(A<User>._)).MustHaveHappenedOnceExactly();
        }
    }
}
