using System;
using System.Collections.Generic;
using System.Linq;

namespace S09
{
    // 35 20 15 25 47
    public class XmasDataValidator
    {
        private readonly int _preamble;
        private readonly IReadOnlyList<long> _xmasData;

        public long InvalidNumber { get; private set; }

        public XmasDataValidator(IEnumerable<long> xmasData, int preamble)
        {
            _xmasData = xmasData.ToList();
            _preamble = preamble;
        }

        public bool Validate()
        {
            for (var i = 0; i < _xmasData.Count - _preamble; i++)
            {
                var previousNumbers = _xmasData.Skip(i).Take(_preamble).ToArray();
                var suspectedInvalidNumber = _xmasData[i + _preamble];
                if (CheckCurrentNumber(previousNumbers, suspectedInvalidNumber)) continue;
                InvalidNumber = suspectedInvalidNumber;
                return false;
            }

            return true;
        }

        private static bool CheckCurrentNumber(IReadOnlyList<long> previousNumbers, long suspectedInvalidNumber)
        {
            for (var i = 0; i < previousNumbers.Count; i++)
            {
                for (var j = 0; j < previousNumbers.Count; j++)
                {
                    if (j == i) continue;
                    if (previousNumbers[i] + previousNumbers[j] == suspectedInvalidNumber) return true;
                }
            }
            
            return false;
        }

        public (long min, long max) FindWeakness(long invalidNumber)
        {
            long sum = 0;
            var queue = new Queue<long>();
            for (var i = 0; i < _xmasData.Count - _preamble; i++)
            {
                queue.Enqueue(_xmasData[i]);
                sum += _xmasData[i];
                
                while (sum > invalidNumber)
                {
                    sum -= queue.Dequeue();
                }

                if (sum != invalidNumber) continue;
                
                // Bingo!
                return (queue.Min(), queue.Max());
            }

            throw new ArgumentOutOfRangeException($"Encryption weakness not found based on number {invalidNumber}.");
        }
    }
}
