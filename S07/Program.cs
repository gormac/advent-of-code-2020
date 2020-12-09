using System;
using System.Linq;

namespace S07
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Get me my shiny gold bags!");

            var bags = Helpers.Rules.Select(rule => new Bag(rule)).ToList();
            Console.WriteLine($"Number of bags able to hold Shiny Gold bag: {bags.Count(b => b.CanHoldShinyGold(bags))}");
            Console.WriteLine($"Total number of bags needed for Shiny Gold bag: {Helpers.ShinyGoldTotalBagCount()}");
        }
    }
}
