using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace S06
{
    public static class Helpers
    {
        public static IEnumerable<string> GetCustomsFormsGroupsLines(string fileName)
        {
            var lines = new List<string>();
            var forms = string.Empty;
            string line;

            using var sr = new StreamReader(fileName);
            while ((line = sr.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    // Next customs form
                    lines.Add(forms);
                    forms = string.Empty;
                }
                else
                {
                    // Next customs form formsGroup
                    forms += $"{line};";
                }
            }

            if (forms.Length > 0)
            {
                // Add the last customs form
                lines.Add(forms);
            }

            return lines;
        }

        public static int GetSumOfAnyoneAnsweredCounts(IEnumerable<string> formsGroups)
        {
            return formsGroups.Sum(g => g.ToCharArray().Where(c => c != ';').Distinct().Count());
        }

        public static int GetSumOfAllAnsweredCounts(IEnumerable<string> formsGroups)
        {
            var count = 0;
            foreach (string formsGroup in formsGroups)
            {
                var distinctCharacters = formsGroup.ToCharArray().Where(c => c != ';').Distinct();
                count += distinctCharacters.Count(c => formsGroup.Split(';', StringSplitOptions.RemoveEmptyEntries).All(form => form.Contains(c)));
            }

            return count;
        }
    }
}