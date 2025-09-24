
// Amir Moeini Rad
// September 2025

// Main Concept: Strategy Design Pattern
// In this pattern, we define a family of algorithms, encapsulate each one, and make them interchangeable.
// Strategy lets the algorithm vary independently from clients that use it.


namespace StrategyDP
{
    // Strategy interface
    interface IStrategy
    {
        void Execute();
    }


    // Concrete Strategies
    class StrategyA : IStrategy
    {
        public void Execute() => Console.WriteLine("Executing Strategy A.");
    }


    class StrategyB : IStrategy
    {
        public void Execute() => Console.WriteLine("Executing Strategy B.");
    }


    ////////////////////////////////////////////////////


    // Context
    class Context
    {
        private IStrategy? _strategy;

        // Set strategy at runtime
        public void SetStrategy(IStrategy strategy) => _strategy = strategy;

        public void DoWork()
        {
            if (_strategy != null)
                _strategy.Execute();
            else
                Console.WriteLine("No strategy set.");
        }
    }

    
    ////////////////////////////////////////////////////
    

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("The Strategy Design Pattern in C#.NET.");
            Console.WriteLine("--------------------------------------\n");


            Context context = new Context();

            // Use Strategy A
            context.SetStrategy(new StrategyA());
            context.DoWork();

            // Switch to Strategy B at runtime
            context.SetStrategy(new StrategyB());
            context.DoWork();


            Console.WriteLine("\nDone.");
        }
    }
}
