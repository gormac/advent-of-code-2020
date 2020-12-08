using System;
using System.Linq;

namespace S06
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Show me those customs forms!");

            var formsGroups = Helpers.GetCustomsFormsGroupsLines("forms.txt").ToList();
            Console.WriteLine($"Sum of anyone answered counts: {Helpers.GetSumOfAnyoneAnsweredCounts(formsGroups)}");
            Console.WriteLine($"Sum of all answered counts: {Helpers.GetSumOfAllAnsweredCounts(formsGroups)}");
        }
    }
}
