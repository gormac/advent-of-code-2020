using System;

namespace S06
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Show me those customs forms!");

            var formsGroups = Helpers.GetCustomsFormsGroupsLines("forms.txt");
            Console.WriteLine($"Sum of answer counts: {Helpers.GetSumOfAnswerCounts(formsGroups)}");
        }
    }
}
