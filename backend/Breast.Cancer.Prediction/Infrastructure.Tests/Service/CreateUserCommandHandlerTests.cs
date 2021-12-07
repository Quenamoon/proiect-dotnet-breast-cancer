using Domain.Entities;
using FakeItEasy;
using Xunit;

namespace Infrastructure.Tests.Service
{
    public class CreateUserCommandHandlerTests
    {
        private readonly Application.Features.Commands.CreateUserCommandHandler handler;
        private readonly Application.Interfaces.IUserRepository repository;

        public CreateUserCommandHandlerTests()
        {
            this.repository = A.Fake<Application.Interfaces.IUserRepository>();
            this.handler = new Application.Features.Commands.CreateUserCommandHandler(this.repository);
        }

        [Fact]
        public async void Given_CreateUserCommandHandler_When_HandleIsCalled_Then_AddAsyncUserIsCalled()
        {
            await handler.Handle(new Application.Features.Commands.CreateUserCommand(),default);
            A.CallTo(() => repository.AddAsync(A<User>._)).MustHaveHappenedOnceExactly();
        }
    }
}
