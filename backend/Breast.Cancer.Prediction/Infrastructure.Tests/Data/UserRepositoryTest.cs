using System;
using Domain.Entities;
using FluentAssertions;
using Persistence.v1;
using Xunit;

namespace Infrastructure.Tests.Data
{
    public class UserRepositoryTest : DatabaseBaseTest
    {
        private readonly Repository<User> repository;
        private readonly User newUser;

        public UserRepositoryTest()
        {
            repository = new Repository<User>(context);
            newUser = new User
            {
                Id = Guid.Parse("1c9915fc-4320-45e4-beef-50801fc99a66"),
                Email = "string@adm.in",
                UserType = UserType.Admin,
                Password = "stringadmin"
            };
        }

        [Fact]
        public async void Given_NewUser_WhenUserIsNotNull_Then_AddAsyncShouldReturnNewUser()
        {
            var result = await repository.AddAsync(newUser);
            result.Should().BeOfType<User>();
        }
    }
}