using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace FluentBuilder
{
    public class PizzaTest
    {
        [Test]
        public void ShoulBuildPizza()
        {
            var result = new PizzaBuilder()
                .WithCrust("Thin")
                .WithSauce("Red")
                .WithTopping("Sausage")
                .WithTopping("Pepperoni")
                .Build();

            Assert.AreEqual(result.Crust, "Thin");
            Assert.AreEqual(result.Sauce, "Red");
            Assert.IsTrue(result.Toppings.SequenceEqual(new List<string>() { "Sausage", "Pepperoni" }));
        }

        [Test]
        [TestCase("Thin")]
        [TestCase("Thick")]
        public void ShouldSetCrust(string crust)
        {
            var result = new PizzaBuilder().WithCrust(crust).Build();
            Assert.AreEqual(result.Crust, crust);
        }

        [Test]
        [TestCase("Pesto")]
        [TestCase("Red")]
        public void ShouldSetSauce(string sauce)
        {
            var result = new PizzaBuilder().WithSauce(sauce).Build();
            Assert.AreEqual(result.Sauce, sauce);
        }

        [Test]
        [TestCase("Pepperoni")]
        [TestCase("Sausage")]
        public void ShouldAddTopping(string topping)
        {
            var result = new PizzaBuilder().WithTopping(topping).Build();
            Assert.IsTrue(result.Toppings.SequenceEqual(new List<string>() { topping }));
        }

        [Test]
        [TestCase("Pepperoni", "Sausage", "Bacon")]
        [TestCase("Sausage", "Bacon", "Pepperoni")]
        public void ShouldAddMultipleToppings(string topping1, string topping2, string topping3)
        {
            var result = new PizzaBuilder()
                .WithTopping(topping1)
                .WithTopping(topping2)
                .WithTopping(topping3)
                .Build();

            Assert.IsTrue(result.Toppings.SequenceEqual(new List<string>() { topping1, topping2, topping3 }));
        }
    }
}