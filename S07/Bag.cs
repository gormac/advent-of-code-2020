using System.Collections.Generic;
using System.Linq;

namespace S07
{
    public class Bag
    {
        public Bag(Rule rule)
        {
            Rule = rule;
        }
        
        public string BagName => Rule.BagName;

        public bool CanHoldOtherBags => Rule.CanHoldOtherBags;

        public bool IsShinyGold => Rule.BagName == "shiny gold";

        public Rule Rule { get; }

        public int SumOfBags(IEnumerable<Rule> rules)
        {
            return Rule.CanHold.Sum(holding =>
                holding.Value * (1 + new Bag(rules.Single(rule => rule.BagName == holding.Key)).SumOfBags(rules)));
        }
    }
}
