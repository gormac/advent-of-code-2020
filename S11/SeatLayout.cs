using System.Linq;

namespace S11
{
    public class SeatLayout
    {
        public char[,] Layout { get; }

        public SeatLayout(char[,] seatLayout)
        {
            Layout = seatLayout;
        }

        public bool IsOccupied(int row, int position) => Layout[row, position] == '#';

        public bool IsSeat(int row, int position) => Layout[row, position] == 'L' || IsOccupied(row, position);

        public int NumberOfOccupiedSeats => Layout.Cast<char>().Count(c => c == '#');

        public SeatLayout OccupySeats()
        {
            var newSeatLayout = Layout.Clone() as char[,];
            for (var i = 0; i < Layout.GetLength(0); i++)
            {
                for (var j = 0; j < Layout.GetLength(1); j++)
                {
                    if (IsSeat(i, j) && !IsOccupied(i, j) && SurroundingNumberOfOccupiedSeats(i, j) == 0)
                    {
                        newSeatLayout[i, j] = '#';
                    }

                    if (IsOccupied(i, j) && SurroundingNumberOfOccupiedSeats(i, j) >= 4)
                    {
                        newSeatLayout[i, j] = 'L';
                    }
                }
            }
            
            return new SeatLayout(newSeatLayout);
        }

        private int SurroundingNumberOfOccupiedSeats(int row, int position)
        {
            var rows = new[] {row - 1, row, row + 1};
            var positions = new[] {position - 1, position, position + 1};
            var numberOfOccupiedSeats = 0;
            foreach (var r in rows)
            {
                if (r < 0 || r >= Layout.GetLength(0)) continue;
                foreach (var p in positions)
                {
                    if (p < 0 || p >= Layout.GetLength(1)) continue;
                    if (r == row && p == position) continue;
                    if (IsFloor(r, p)) continue;
                    if (IsOccupied(r, p)) numberOfOccupiedSeats++;
                }
            }

            return numberOfOccupiedSeats;
        }

        private bool IsFloor(int row, int position) => Layout[row, position] == '.';
    }
}
