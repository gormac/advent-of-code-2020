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
            List<Tuple<int, int>> numberPairs = new List<Tuple<int, int>>();
            foreach (var (number, number2) in numbers.SelectMany(number => numbers.Select(number2 => (number, number2))))
            {
                if (number == number2) continue;
                numberPairs.Add(new Tuple<int, int>(number, number2));
            }

            List<Tuple<int, int>> magicTupleList = numberPairs.FindAll(t => t.Item1 + t.Item2 == 2020);
            Console.WriteLine("Number pairs:");
            foreach (Tuple<int, int> magicTuple in magicTupleList)
            {
                Console.WriteLine($"{magicTuple.Item1} + {magicTuple.Item2} = {magicTuple.Item1 + magicTuple.Item2}");
                Console.WriteLine($"{magicTuple.Item1} * {magicTuple.Item2} = {magicTuple.Item1 * magicTuple.Item2}");
            }
        }

        private static List<int> GetExpenses()
        {
            List<int> numbers = new List<int>();
            string[] lines = File.ReadAllLines("expense-report.txt");
            foreach (string line in lines)
            {
                if (int.TryParse(line, out int number))
                {
                    numbers.Add(number);
                }
            }

            return numbers;
        }
    }
}
