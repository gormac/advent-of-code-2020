using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace S10
{
    public class Chain
    {
        private readonly IEnumerable<int> _adapters;

        public Chain(IEnumerable<int> adapters)
        {
            _adapters = adapters.ToImmutableSortedSet();
        }

        public (int jolt1Count, int jolt3Count) GetJoltCount()
        {
            var jolt1Count = 0;
            var jolt3Count = 0;
            var lastAdapter = 0;
            foreach (var adapter in _adapters)
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
