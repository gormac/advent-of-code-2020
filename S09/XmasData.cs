using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace S09
{
    public static class XmasData
    {
        public static IEnumerable<long> Data => GetXmasData();

        private static IEnumerable<long> GetXmasData()
        {
            return File.ReadAllLines("XmasData.txt").Select(long.Parse);
        }
    }
}
