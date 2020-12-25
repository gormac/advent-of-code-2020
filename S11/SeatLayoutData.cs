using System.IO;
using System.Linq;

namespace S11
{
    public static class SeatLayoutData
    {
        public static char[,] Data => GetSeatLayoutFromFile();

        private static char[,] GetSeatLayoutFromFile()
        {
            var lines = File.ReadLines("SeatLayoutData.txt").ToArray();
            var layout = new char[lines.Length, lines.First().Length];
            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i].ToCharArray();
                for (var j = 0; j < line.Length; j++)
                {
                    layout[i, j] = line[j];
                }
            }

            return layout;
        }
    }
}
