using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace S04
{
    public class Program
    {
        private static void Main()
        {
            Console.WriteLine("Check those passports!");

            var passports = GetPassports();
            var validPassportsCount = passports.Where(passport => passport.IsValid).Count();

            Console.WriteLine($"# of valid passports: {validPassportsCount}");
        }

        private static IEnumerable<Passport> GetPassports()
        {
            return (GetPassportLines().Select(passportLine => new Passport(passportLine))).ToList();
        }

        private static IEnumerable<string> GetPassportLines()
        {
            var lines = new List<string>();

            using (StreamReader sr = new StreamReader("passports.txt"))
            {
                string line;
                string passport = string.Empty;

                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        // Next passport
                        lines.Add(passport);
                        passport = string.Empty;
                    }
                    else
                    {
                        // Next passport line
                        passport += line + " ";
                    }
                }

                if (!string.IsNullOrWhiteSpace(passport))
                {
                    // Add the last passport
                    lines.Add(passport);
                }
            }

            return lines;
        }
    }
}
