using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace S08
{
    public static class Helpers
    {
        public static int Accumulator { get; set; }

        public static IEnumerable<Instruction> Instructions => GetInstructions();

        private static IEnumerable<Instruction> GetInstructions()
        {
            return File.ReadAllLines("Program.txt").Select(line => new Instruction(line));
        }

        public static int RunProgram()
        {
            var instructions = Instructions.ToImmutableList();
            var position = 0;
            while (true)
            {
                if (position < 0 || position > instructions.Count - 1)
                {
                    Console.WriteLine($"Position out of bounds. Position: {position}.");
                    break;
                }

                var instruction = instructions[position];
                if (instruction.HitCount == 1)
                {
                    Console.WriteLine($"Instruction '{instruction.Operation}' hit twice at position {position}.");
                    break;
                }

                position += instruction.Execute();
            }

            return Accumulator;
        }
    }
}
