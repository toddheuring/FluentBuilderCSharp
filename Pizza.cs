using System.Collections.Generic;

namespace FluentBuilder
{
    public class Pizza
    {
        public string Crust { get; set; }
        public string Sauce { get; set; }
        public List<string> Toppings { get; set; }
    }

    public class PizzaBuilder
    {
        private string Crust;
        private string Sauce;
        private List<string> Toppings = new List<string>();

        public PizzaBuilder GetPizzaBuilder()
        {
            return this;
        }

        public PizzaBuilder WithCrust(string crust)
        {
            this.Crust = crust;
            return this;
        }

        public PizzaBuilder WithSauce(string sauce)
        {
            this.Sauce = sauce;
            return this;
        }

        public PizzaBuilder WithTopping(string topping)
        {
            this.Toppings.Add(topping);
            return this;
        }

        public Pizza Build()
        {
            return new Pizza()
            {
                Crust = this.Crust,
                Sauce = this.Sauce,
                Toppings = this.Toppings
            };
        }
    }
}
