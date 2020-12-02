using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace S02E01
{
    public class Program
    {
        private static void Main()
        {
            var invalid = 0;
            var valid = 0;
            var passwords = GetPasswords();
            foreach (var password in passwords)
            {
                if (password.IsValid())
                {
                    valid++;
                }
                else
                {
                    invalid++;
                }
            }

            Console.WriteLine($"Valid passwords: {valid}");
            Console.WriteLine($"Invalid passwords: {invalid}");
            Console.WriteLine($"Total passwords: {valid + invalid}");
        }

        private static IEnumerable<Password> GetPasswords()
        {
            var lines = File.ReadAllLines("passwords.txt");
            return lines.Select(line => new Password(line)).ToList();
        }
    }
}
