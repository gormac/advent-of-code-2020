using System.Collections.Generic;
using System.Linq;

namespace S09
{
    // 35 20 15 25 47
    public class XmasDataValidator
    {
        private readonly int _preamble;
        private readonly IReadOnlyList<long> _xmasData;

        public long FailingNumber { get; private set; }

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
                var numberToValidate = _xmasData[i + _preamble];
                if (CheckCurrentNumber(previousNumbers, numberToValidate)) continue;
                FailingNumber = numberToValidate;
                return false;
            }

            return true;
        }

        private static bool CheckCurrentNumber(IReadOnlyList<long> previousNumbers, long numberToValidate)
        {
            for (var i = 0; i < previousNumbers.Count; i++)
            {
                for (var j = 0; j < previousNumbers.Count; j++)
                {
                    if (j == i) continue;
                    if (previousNumbers[i] + previousNumbers[j] == numberToValidate) return true;
                }
            }
            
            return false;
        }
    }
}
