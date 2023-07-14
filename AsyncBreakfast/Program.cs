using System;
using System.Threading.Tasks;

namespace BreakfastAsync
{
    // These classes are intentionally empty for the purpose of this example. They are simply marker classes for the purpose of demonstration, contain no properties, and serve no other purpose.
    internal class Bacon { }
    internal class Coffee { }
    internal class Egg { }
    internal class Juice { }
    internal class Toast { }
    class Plate { }

    class Program
    {
        public static async Task Main(string[] args)
        {

            Task<Egg> eggTask = FryEggsAsync();
            Task<Bacon> baconTask = FryBaconAsync();
            Task<Coffee> coffeeTask = PourCoffee();
            Task<Toast> toastTask = MakeToast();

            Console.WriteLine("Async methods are running.");

            // this is going to be a composite task<t>
            Task<Plate> plateTask = PlatingTheFood(baconTask);
            await plateTask;

        }

        public static async Task<Egg> FryEggsAsync()
        {
            // await needs to be in the method
            Console.WriteLine("Begin frying eggs");
            await Task.Delay(3000);
            Console.WriteLine("Eggs are ready");
            return new Egg();
        }

        public static async Task<Coffee> PourCoffee()
        {
            Console.WriteLine("Pouring Coffee");
            await Task.Delay(1000);
            return new Coffee();
        }

        public static async Task<Toast> MakeToast()
        {
            Console.WriteLine("Bread is toasting");
            await Task.Delay(3000);
            return new Toast();
        }

        public static async Task<Bacon> FryBaconAsync()
        {
            await Task.Delay(3000);
            Console.WriteLine("Frying bacon");
            return new Bacon();
        }

        public static async Task<Plate> PlatingTheFood(Task<Bacon> baconTask)
        {
            await Task.WhenAll(baconTask);
            Console.WriteLine("Bacon has been plated");


            return new Plate();
        }
    }
}