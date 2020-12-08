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

        public static int GetSumOfAnswerCounts(IEnumerable<string> formsGroups)
        {
            return formsGroups.Sum(g => g.ToCharArray().Where(c => c != ';').Distinct().Count());
        }
    }
}