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

            var boardingPasses = GetBoardingPasses();
            var highestSeatId = boardingPasses.OrderByDescending(p => p.SeatId).First().SeatId;

            Console.WriteLine($"Highest seat ID: {highestSeatId}");
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
