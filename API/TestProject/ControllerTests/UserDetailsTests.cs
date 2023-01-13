using CompanyRegistration.Controllers;
using CompanyRegistration.Data;
using CompanyRegistration.Manager;
using CompanyRegistration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TestProject.ControllerTests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    class UserDetailsTests

    {
        private readonly IConfiguration _config;
        public Mock<IRegister> IRegisterMock;
        List<UserDetails> userdetailsMock;
        [SetUp]
        public void Setup()
        {
            IRegisterMock = new Mock<IRegister>();
            userdetailsMock = new List<UserDetails>();
            userdetailsMock.Add(new UserDetails() { Id = 12345, Password = "sssss", UserName = "sachin", Email = "sachin.com" });
        }

        [Test, Category("RegisterAndLoginController")]
        public void Create_Success()
        {
            var UserDetailsManagerMock = new Mock<IRegister>();
            var Configuration = new Mock<ILogger<RegisterAndLoginController>>();
            UserDetailsRequest obj = new UserDetailsRequest();
            obj.Id = 1987;
            obj.Email = "satr.co";
            obj.Password = "llll";
            obj.UserName = "sachina";
            UserDetailsManagerMock.Setup(x => x.Create(obj)).Verifiable();
            var UserDetailsManager = new RegisterAndLoginController(UserDetailsManagerMock.Object, Configuration.Object, _config);

            var result = UserDetailsManager.Create(obj);
            var content = result as OkObjectResult;
            Assert.IsNotNull(content);
            Assert.AreEqual(200, content.StatusCode);
        }

        [Test, Category("RegisterAndLoginController")]
        public void Create_error()
        {
            var UserDetailsManagerMock = new Mock<IRegister>();
            var Configuration = new Mock<ILogger<RegisterAndLoginController>>();
            UserDetailsRequest obj = new UserDetailsRequest();
            obj.Id = 1987;
            obj.Email = "satr.co";
            obj.Password = "llll";
            obj.UserName = "sachina";
            UserDetailsManagerMock.Setup(x => x.Create(obj)).Throws(new Exception()).Verifiable();
            var UserDetailsManager = new RegisterAndLoginController(UserDetailsManagerMock.Object, Configuration.Object, _config);
            var result = UserDetailsManager.Create(obj);
            var content = result as ObjectResult;
            Assert.IsNotNull(content);
            Assert.AreEqual(500, content.StatusCode);
        }

        [Test, Category("RegisterAndLoginController")]
        public void GetLogin_Success()
        {
            var UserDetailsManagerMock = new Mock<IRegister>();
            var Configuration = new Mock<ILogger<RegisterAndLoginController>>();
            UserDetailsRequest obj = new UserDetailsRequest();
            obj.Email = "satr.co";
            obj.Password = "llll";
            UserDetailsManagerMock.Setup(x => x.Getlogin(obj.Email, obj.Password)).Verifiable();
            var UserDetailsManager = new RegisterAndLoginController(UserDetailsManagerMock.Object, Configuration.Object, _config);
            var result = UserDetailsManager.Create(obj);
            var content = result as OkObjectResult;
            Assert.IsNotNull(content);
            Assert.AreEqual(200, content.StatusCode);
        }

        [Test, Category("RegisterAndLoginController")]
        public void GetLogin_error()
        {
            var UserDetailsManagerMock = new Mock<IRegister>();
            var Configuration = new Mock<ILogger<RegisterAndLoginController>>();
            UserDetailsRequest obj = new UserDetailsRequest();
            obj.Email = "satr.co";
            obj.Password = "llll";
            UserDetailsManagerMock.Setup(x => x.Getlogin(obj.Email, obj.Password)).Throws(new Exception()).Verifiable();
            var UserDetailsManager = new RegisterAndLoginController(UserDetailsManagerMock.Object, Configuration.Object, _config);
            var result = UserDetailsManager.Create(obj);
            var content = result as ObjectResult;
            Assert.IsNotNull(content);
            Assert.AreEqual(200, content.StatusCode);
        }
    }
}
