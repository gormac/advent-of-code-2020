using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace S07
{
    public class Rule
    {
        public Rule(string ruleDescription)
        {
            RuleDescription = ruleDescription;
            BagName = GetBagName(ruleDescription);
            CanHold = GetContents(ruleDescription);
        }

        public string BagName { get; }

        public IReadOnlyDictionary<string, int> CanHold { get; }

        public bool CanHoldOtherBags => CanHold.Count > 0;

        public string RuleDescription { get; }

        private static string GetBagName(string ruleDescription)
        {
            return ruleDescription.Split("bags contain", StringSplitOptions.TrimEntries)[0];
        }

        private static IReadOnlyDictionary<string, int> GetContents(string ruleDescription)
        {
            string contentRuleDescription = ruleDescription.Split("bags contain", StringSplitOptions.TrimEntries)[1];
            if (contentRuleDescription.Contains("no other"))
            {
                return new Dictionary<string, int>();
            }

            var contentRules = contentRuleDescription.Split(',', StringSplitOptions.TrimEntries);
            var contents = new Dictionary<string, int>();
            foreach (string contentRule in contentRules)
            {
                string bagInfo = contentRule.Split("bag", StringSplitOptions.TrimEntries)[0];
                string bagAmount = Regex.Match(bagInfo, @"\d+").Value;
                contents.Add(bagInfo.Split(bagAmount, StringSplitOptions.TrimEntries)[1], int.Parse(bagAmount));
            }

            return contents;
        }
    }
}
