using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Application.Services;
using Template.Domain.Interfaces;
using Xunit;

namespace Template.Application.Tests.Services
{
    public class UserServiceTests
    {
        private UserService userService;

        public UserServiceTests()
        {
            userService = new UserService(new Mock<IUserRepository>().Object, new Mock<IMapper>().Object);
        }

        [Fact]
        public void Post_SendingValidID()
        {
            var exception = Assert.Throws<Exception>(() => userService.Post(new ViewModels.UserViewModel { Id = Guid.NewGuid() }));
            Assert.Equal("User ID must be empty", exception.Message);
        }
    }
}
