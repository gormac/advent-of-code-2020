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
            Console.WriteLine("Tree collision counter...");

            var treeLines = GetTreeLines();
            var moves = new int[5][];
            moves[0] = new[] { 1, 1 };
            moves[1] = new[] { 3, 1 };
            moves[2] = new[] { 5, 1 };
            moves[3] = new[] { 7, 1 };
            moves[4] = new[] { 1, 2 };
            long product = 1;
            var sum = 0;
            foreach (int[] move in moves)
            {
                var numberOfTrees = GetNumberOfTreesEncountered(treeLines, move);
                product = checked(product * numberOfTrees);
                sum += numberOfTrees;
            }

            Console.WriteLine($"Product of trees encountered: {product}");
            Console.WriteLine($"Sum of trees encountered: {sum}");
        }

        private static IEnumerable<string> GetTreeLines()
        {
            var lines = File.ReadAllLines("trees.txt");
            return lines.ToList();
        }

        private static int GetNumberOfTreesEncountered(IEnumerable<string> treeLines, int[] move)
        {
            int moveRight = move[0];
            int moveDown = move[1];
            var lineNumber = 0;
            var position = 0;
            var treeEncounters = 0;
            foreach (string treeLine in treeLines)
            {
                if (lineNumber++ % moveDown > 0) continue;

                if (position > treeLine.Length - 1)
                {
                    position -= treeLine.Length;
                }

                if (treeLine[position] == '#')
                {
                    treeEncounters++;
                }

                position += moveRight;
            }

            Console.WriteLine($"Number of trees encountered [{moveRight}/{moveDown}]: {treeEncounters}");

            return treeEncounters;
        }
    }
}
