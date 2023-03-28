using NUnit.Framework;
using System;
using System.Data.Entity;

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
       


    }
}
