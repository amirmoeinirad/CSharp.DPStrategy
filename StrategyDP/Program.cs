// Amir Moeini Rad
// December, 2025

// Main Concept: The Strategy Design Pattern

// In this pattern, we define a family of algorithms, encapsulate each one in a class,
// and make them interchangeable.

namespace DPStrategy
{
    // Strategy interface
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal price);
    }
    

    // Concrete strategies
    public class NoDiscount : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal price) => price;
    }

    public class PercentageDiscount : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal price) => price * 0.9m; // 10% off
    }
    

    // Context class
    public class ShoppingCart
    {
        private readonly IDiscountStrategy _strategy;

        public ShoppingCart(IDiscountStrategy strategy)
        {
            _strategy = strategy;
        }

        public decimal Checkout(decimal price) => _strategy.ApplyDiscount(price);
    }
    

    // Client
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("The Strategy Design Pattern in C#.NET.");
            Console.WriteLine("--------------------------------------\n");

            decimal price = 100;
            Console.WriteLine($"Original Price: {price}");

            IDiscountStrategy discountStrategy = new NoDiscount();            
            var cart = new ShoppingCart(discountStrategy);
            decimal finalPrice = cart.Checkout(price);
            Console.WriteLine($"Final Price: {finalPrice}");

            discountStrategy = new PercentageDiscount();
            cart = new ShoppingCart(discountStrategy);
            finalPrice = cart.Checkout(price);
            Console.WriteLine($"Final Price: {finalPrice}");

            Console.WriteLine("\nDone.");
        }
    }
}
