using WebAPI.Controllers.v1;
using MediatR;
using FakeItEasy;
using Xunit;
using Application.Features.Queries;

namespace Infrastructure.Tests.API.v1
{
    public class UsersControllerTests
    {
        private readonly UsersController controller;
        private readonly IMediator mediator;

        public UsersControllerTests()
        {
            mediator = A.Fake<IMediator>();
            controller = new UsersController(mediator);
        }

        [Fact]
        public async void Given_UsersController_When_GetIsCalled_Then_ShouldReturnAProductCollection()
        {
            await controller.Get();
            A.CallTo(() => mediator.Send(A<GetUsersQuery>._, default)).MustHaveHappenedOnceExactly();
        }
    }
}
