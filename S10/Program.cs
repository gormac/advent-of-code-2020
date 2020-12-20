using System;

namespace S10
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Let's Joltify this!");
            
            Console.WriteLine("Getting Jolt count from adapter data...");
            var chain = new Chain(AdapterData.Adapters);
            var (jolt1Count, jolt3Count) = chain.GetJoltCount();
            Console.WriteLine($"1-Jolt / 3-Jolt differences: {jolt1Count} / {jolt3Count}");
            Console.WriteLine($"Jolt differences multiplied: {jolt1Count * jolt3Count}");
        }
    }
}
