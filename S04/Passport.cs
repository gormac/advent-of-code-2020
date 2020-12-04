using System.Collections.Generic;
using System.Linq;

namespace S04
{
    internal class Passport
    {
        // byr (Birth Year)
        // cid (Country ID)
        // ecl (Eye Color)
        // eyr (Expiration Year)
        // hcl (Hair Color)
        // hgt (Height)
        // iyr (Issue Year)
        // pid (Passport ID)

        private readonly List<string> _keys = new List<string>();
        private readonly List<string> _mandatoryKeys = new List<string> { "byr", "ecl", "eyr", "hcl", "hgt", "iyr", "pid" };
        private readonly Dictionary<string, string> _passportInfo = new Dictionary<string, string>();

        public Passport(string passportLine)
        {
            ParsePassportInfo(passportLine);
            _keys = new List<string>(_passportInfo.Keys);
        }

        private void ParsePassportInfo(string passportLine)
        {
            foreach (var keyvalue in passportLine.Split(' ').Where(keyvalue => !string.IsNullOrWhiteSpace(keyvalue)))
            {
                _passportInfo.Add(keyvalue.Split(':')[0], keyvalue.Split(':')[1]);
            }
        }

        public bool IsValid => _mandatoryKeys.TrueForAll(key => _keys.Contains(key));
    }
}