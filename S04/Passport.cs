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

        internal Dictionary<string, string> PassportInfo { get; } = new Dictionary<string, string>();

        public Passport(string passportLine)
        {
            ParsePassportInfo(passportLine);
        }

        private void ParsePassportInfo(string passportLine)
        {
            foreach (string kv in passportLine.Split(' ').Where(kv => !string.IsNullOrWhiteSpace(kv)))
            {
                PassportInfo.Add(kv.Split(':')[0], kv.Split(':')[1]);
            }
        }

        public bool IsValid =>
            this.ContainsAllMandatoryKeys()
            && this.IsBirthYearCorrect()
            && this.IsExpirationYearCorrect()
            && this.IsIssueYearCorrect()
            && this.IsHeightCorrect()
            && this.IsHairColorCorrect()
            && this.IsEyeColorCorrect()
            && this.IsPassportIdCorrect();
    }
}