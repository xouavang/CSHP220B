using NUnit.Framework;
using HelloWorld.Models;
using HelloWorld.Controllers;
using Microsoft.Extensions.Options;
using System.Linq;

namespace HelloWorld.Test
{
    public class ProductTests
    {
        [Test]
        public void TestMethodWithFakeClass()
        {
            // Arrange - setting up the environment
            var optionsMyJsonSettings = Options.Create(new MyJsonSettings()); // creates an option to satisfy HomeController need.

            var controller = new HomeController(new FakeProductRepository(), optionsMyJsonSettings);

            // Act - do an action on that environment
            var result = controller.Products();

            // Assert - validate the results
            var products = (Product[])((Microsoft.AspNetCore.Mvc.ViewResult)(result)).Model;
            Assert.AreEqual(5, products.Length, "Length is invalid");

            // Every assert should fail the first time, before succeeding, to ensure you're testing the right thing
            // To debug Test, right click in the test method and click "Debug Test(s)"
        }

        [Test]
        public void Test2Method()
        {
            // Arrange - setting up the environment
            var optionsMyJsonSettings = Options.Create(new MyJsonSettings()); // creates an option to satisfy HomeController need.

            var controller = new HomeController(new FakeProductRepository(), optionsMyJsonSettings);

            // Act - do an action on that environment
            var result = controller.Products();

            // Assert - validate the results
            var products = (Product[])((Microsoft.AspNetCore.Mvc.ViewResult)(result)).Model;
            Assert.AreEqual(5, products.Length, "Length is invalid");
            Assert.GreaterOrEqual(products.Count(t => t.Price > 10), 3, "Less than 3 were found");
            Assert.GreaterOrEqual(products.Count(t => t.Price < 10), 2, "More than expected were found");

            // Message is used to trace back to where the Assert is failing.
        }
    }
}