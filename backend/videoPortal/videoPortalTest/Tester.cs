using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Data.Entity;
using videoPortal;
using videoPortal.Controllers;

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
        [Test]
        public void Login()
        {
            AuthController c = new AuthController();
            User u = new User() { Username = "Test" };
            Assert.That(() => c.Login(new UserDto() { UserName = "Test" }), Throws.Nothing);
        }
        [Test]

        public void Register()
        {
            AuthController c = new AuthController();
            UserDto d = new UserDto();



            Assert.That(() => c.Register(d), Throws.Nothing);
        }


    }
}
