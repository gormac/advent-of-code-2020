using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace S03
{
    public class Program
    {
        private static void Main()
        {
            var position = 0;
            var treeEncounters = 0;
            var treeLines = GetTreeLines();
            foreach (string treeLine in treeLines)
            {
                if (position > treeLine.Length - 1)
                {
                    position -= treeLine.Length;
                }

                if (treeLine[position] == '#')
                {
                    treeEncounters++;
                }

                position += 3;
            }

            Console.WriteLine($"Number of trees encountered: {treeEncounters}");
        }

        private static IEnumerable<string> GetTreeLines()
        {
            var lines = File.ReadAllLines("trees.txt");
            return lines.ToList();
        }
    }
}
