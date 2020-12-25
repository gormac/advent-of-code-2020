using System;
using System.Linq;

namespace S11
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Let's get that seating sorted!");
            
            var nextSeatLayout = new SeatLayout(SeatLayoutData.Data);
            SeatLayout currentSeatLayout;
            var round = 0;
            do
            {
                currentSeatLayout = nextSeatLayout;
                nextSeatLayout = currentSeatLayout.OccupySeats();
                round++;
            } while (!nextSeatLayout.Layout.Cast<char>().SequenceEqual(currentSeatLayout.Layout.Cast<char>()));

            // Subtract one round because the last round doesn't change the seat layout
            Console.WriteLine($"Seat layout stabilized after {round - 1} rounds with {currentSeatLayout.NumberOfOccupiedSeats} occupied seats.");
        }
    }
}
