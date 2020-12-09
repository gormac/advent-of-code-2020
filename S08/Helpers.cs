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
            var instructionHistory = new List<Instruction>();
            var position = 0;
            while (true)
            {
                var instruction = instructions[position];
                instructionHistory.Add(instruction);
                if (instruction.HitCount == 1)
                {
                    Console.WriteLine($"Instruction '{instruction.Operation}' about to hit twice at position {position}.");
                    PrintInstructionHistory(instructionHistory, 20);
                    break;
                }

                position += instruction.Execute();
                if (position == instructions.Count)
                {
                    Console.WriteLine($"Normal program termination at position {position}. Woohoo!");
                    PrintInstructionHistory(instructionHistory, 10);
                    break;
                }

                if (position >= 0 && position <= instructions.Count - 1) continue;
                Console.WriteLine($"Position out of bounds. Position: {position}.");
                PrintInstructionHistory(instructionHistory, 10);
                break;
            }

            return Accumulator;
        }

        private static void PrintInstructionHistory(IEnumerable<Instruction> instructionHistory, int amount)
        {
            Console.WriteLine($"Last {amount} instruction(s):");
            foreach (var historicInstruction in instructionHistory.TakeLast(amount))
            {
                string sign = historicInstruction.Argument >= 0 ? "+" : string.Empty;
                Console.WriteLine($"{historicInstruction.Operation} {sign}{historicInstruction.Argument}");
            }
        }
    }
}
