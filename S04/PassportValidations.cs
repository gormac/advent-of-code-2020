using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace S04
{
    internal static class PassportValidations
    {
        private static readonly List<string> MandatoryKeys = new List<string> { "byr", "ecl", "eyr", "hcl", "hgt", "iyr", "pid" };

        public static bool ContainsAllMandatoryKeys(this Passport passport)
        {
            return MandatoryKeys.TrueForAll(key => passport.PassportInfo.ContainsKey(key));
        }

        public static bool IsBirthYearCorrect(this Passport passport)
        {
            if (int.TryParse(passport.PassportInfo["byr"], out int birthYear))
            {
                return birthYear >= 1920 && birthYear <= 2002;
            }

            return false;
        }

        public static bool IsExpirationYearCorrect(this Passport passport)
        {
            if (int.TryParse(passport.PassportInfo["eyr"], out int expirationYear))
            {
                return expirationYear >= 2020 && expirationYear <= 2030;
            }

            return false;
        }

        public static bool IsEyeColorCorrect(this Passport passport)
        {
            string eyeColor = passport.PassportInfo["ecl"];

            return "amb blu brn gry grn hzl oth".Contains(eyeColor);
        }

        public static bool IsHairColorCorrect(this Passport passport)
        {
            string hairColor = passport.PassportInfo["hcl"];

            return Regex.IsMatch(hairColor, "^#[0-9a-f]{6}$");
        }

        public static bool IsHeightCorrect(this Passport passport)
        {
            string height = passport.PassportInfo["hgt"];
            if (height.EndsWith("cm"))
            {
                if (int.TryParse(height.Remove(height.IndexOf('c'), 2), out int hgt) && hgt >= 150 && hgt <= 193) return true;
            }
            else if (height.EndsWith("in")
                     && int.TryParse(height.Remove(height.IndexOf('i'), 2), out int hgt) && hgt >= 59 && hgt <= 76) return true;

            return false;
        }

        public static bool IsIssueYearCorrect(this Passport passport)
        {
            if (int.TryParse(passport.PassportInfo["iyr"], out int issueYear))
            {
                return issueYear >= 2010 && issueYear <= 2020;
            }

            return false;
        }

        public static bool IsPassportIdCorrect(this Passport passport)
        {
            string passportId = passport.PassportInfo["pid"];

            return Regex.IsMatch(passportId, "^[0-9]{9}$");
        }
    }
}