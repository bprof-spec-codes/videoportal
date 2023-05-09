using IdentityServer3.Core.Services;
using Microsoft.AspNetCore.Authentication;
using Moq;
using NUnit.Framework;
using System;
using System.Data.Entity;
using videoPortal;
using videoPortal.Controllers;
using Xunit;

namespace videoPortalTest
{
    [TestFixture]
    public class Tester
    {
        

        [Test]
        public void FirstTest()
        {
            var v1 = "Hello World";
            Assert.That(v1, Is.EqualTo("Hello World"));
        }


        [Fact]
        public void ShouldAuthenticateValidUser()
        {
            var mockService = new Mock<IConfig>();
            UserDto u = new UserDto() { UserName = "Username", Password = "Password" };
            mockService.Setup(x=> x.Logom())  
        }
    }
}
