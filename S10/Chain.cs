using System;
using System.Collections.Generic;
using System.Linq;

namespace S10
{
    public class Chain
    {
        private readonly IEnumerable<int> _adapters;

        public Chain(IEnumerable<int> adapters)
        {
            _adapters = adapters;
        }

        public long GetAdapterArrangementCount()
        {
            var arrangementCounts = new Dictionary<int, long> { { 0, 1L } };
            foreach (int adapter in _adapters.OrderBy(a => a).ToArray())
            {
                long count = arrangementCounts.Where(ac => ac.Key >= adapter - 3 && ac.Key <= adapter - 1).Sum(ac => ac.Value);
                Console.WriteLine($"Adapter #{adapter} / Arrangement count {count}");
                arrangementCounts.Add(adapter, count);
            }
            
            return arrangementCounts.Last().Value;
        }

        public (int jolt1Count, int jolt3Count) GetJoltCount()
        {
            var jolt1Count = 0;
            var jolt3Count = 0;
            var lastAdapter = 0;
            foreach (var adapter in _adapters.OrderBy(a => a).ToArray())
            {
                switch (adapter - lastAdapter)
                {
                    case 1:
                        jolt1Count++;
                        break;
                    case 3:
                        jolt3Count++;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Unknown Jolt step detected -> {adapter - lastAdapter} Jolts!");
                }

                lastAdapter = adapter;
            }

            // Add built-in adapter
            jolt3Count++;
            
            return (jolt1Count, jolt3Count);
        }
    }
}
