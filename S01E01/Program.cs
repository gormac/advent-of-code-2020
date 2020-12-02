using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace S01E01
{
    public class Program
    {
        private static void Main()
        {
            IReadOnlyList<int> numbers = GetExpenses();
            var numberTriplets = new List<Tuple<int, int, int>>();
            foreach ((int number, int number2, int number3) in numbers.SelectMany(number => numbers.SelectMany(number2 => numbers.Select(number3 => (number, number2, number3)))))
            {
                if (number == number2 || number == number3 || number2 == number3) continue;
                numberTriplets.Add(new Tuple<int, int, int>(number, number2, number3));
            }

            Tuple<int, int, int> firstMagicTuple = numberTriplets.Find(t => t.Item1 + t.Item2 + t.Item3 == 2020);
            Console.WriteLine("Number triplets:");
            Console.WriteLine($"{firstMagicTuple.Item1} + {firstMagicTuple.Item2} + {firstMagicTuple.Item3} = {firstMagicTuple.Item1 + firstMagicTuple.Item2 + firstMagicTuple.Item3}");
            Console.WriteLine($"{firstMagicTuple.Item1} * {firstMagicTuple.Item2} * {firstMagicTuple.Item3} = {firstMagicTuple.Item1 * firstMagicTuple.Item2 * firstMagicTuple.Item3}");
        }

        private static List<int> GetExpenses()
        {
            string[] lines = File.ReadAllLines("expense-report.txt");

            return lines.Select(int.Parse).ToList();
        }
    }
}
