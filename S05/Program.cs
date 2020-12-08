using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace S05
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Let's get that boarding pass!");

            var boardingPasses = GetBoardingPasses().OrderBy(p => p.SeatId).ToList();
            boardingPasses.ForEach(p => Console.WriteLine($"Boarding pass {p.SeatCode}, seat ID {p.SeatId}"));

            int highestSeatId = boardingPasses.Last().SeatId;
            Console.WriteLine($"Highest seat ID: {highestSeatId}");

            int lowestId = boardingPasses.First().SeatId;
            int mySeatId = boardingPasses.Select(p => p.SeatId).Where((id, previousId) => id - previousId == lowestId + 1).First() - 1;
            Console.WriteLine($"My Seat ID: {mySeatId}");
        }

        private static IEnumerable<BoardingPass> GetBoardingPasses()
        {
            return GetSeatCodes().Select(seatCode => new BoardingPass(seatCode));
        }

        private static IEnumerable<string> GetSeatCodes()
        {
            return File.ReadAllLines("BoardingPasses.txt");
        }
    }
}
