// Amir Moeini Rad
// December, 2025

// The Strategy Design Pattern

// In this pattern, we define a family of algorithms, encapsulate each one in a class,
// and make them interchangeable.

namespace DPStrategy
{
    // Strategy interface
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal price, decimal discountPercent);
    }
    


    // Concrete strategies
    public class NoDiscount : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal price, decimal discountPercent = 0) => price;
    }

    public class PercentageDiscount : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal price, decimal discountPercent) => (price - price * discountPercent);
    }
    


    // Context class
    public class ShoppingCart
    {
        private readonly IDiscountStrategy _strategy;

        public ShoppingCart(IDiscountStrategy strategy)
        {
            _strategy = strategy;
        }

        public decimal Checkout(decimal price, decimal discountPercent = 0) => _strategy.ApplyDiscount(price, discountPercent);
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
            Console.WriteLine($"Final Price w/o discount: {finalPrice}");

            discountStrategy = new PercentageDiscount();
            cart = new ShoppingCart(discountStrategy);
            finalPrice = cart.Checkout(price, 0.10m);
            Console.WriteLine($"Final Price w discount: {finalPrice}");

            Console.WriteLine("\nDone.");
        }
    }
}
