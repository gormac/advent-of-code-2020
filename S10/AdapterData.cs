using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace S10
{
    public static class AdapterData
    {
        public static IEnumerable<int> Adapters => GetAdaptersFromFile();

        private static IEnumerable<int> GetAdaptersFromFile()
        {
            return File.ReadAllLines("Adapters.txt").Select(int.Parse);
        }
    }
}
