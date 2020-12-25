using System.Linq;
using FluentAssertions;
using Xunit;

namespace S11.Tests
{
    public class SeatLayoutDataTests
    {
        [Fact]
        public void TestSeatLayoutData_Should_Contain_100_Characters()
        {
            SeatLayoutData.Data.Length.Should().Be(100);
        }

        [Fact]
        public void TestSeatLayoutData_Row_1_Position_1_Should_Be_An_Unoccupied_Seat()
        {
            var seatLayout = new SeatLayout(SeatLayoutData.Data);
            seatLayout.IsSeat(0, 0).Should().BeTrue();
            seatLayout.IsOccupied(0, 0).Should().BeFalse();
        }

        [Fact]
        public void TestSeatLayoutData_Should_Not_Contain_Empty_Seats_After_1_Round()
        {
            var initialSeatLayout = new SeatLayout(SeatLayoutData.Data);
            var newSeatLayout = initialSeatLayout.OccupySeats();
            newSeatLayout.Layout.Should().NotContain('L');
            newSeatLayout.Layout.Cast<char>().SequenceEqual(initialSeatLayout.Layout.Cast<char>()).Should().BeFalse();
        }

        [Fact]
        public void TestSeatLayoutData_Should_Stabilize_After_5_Rounds_With_37_Occupied_Seats()
        {
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
            (round - 1).Should().Be(5);
            currentSeatLayout.NumberOfOccupiedSeats.Should().Be(37);
        }
    }
}
