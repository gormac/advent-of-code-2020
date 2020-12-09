using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace S07
{
    public static class Helpers
    {
        public static IEnumerable<Rule> Rules => GetRules();

        public static IEnumerable<Rule> GetRules()
        {
            return File.ReadAllLines("Rules.txt").Select(line => new Rule(line)).ToList();
        }

        public static bool CanHoldShinyGold(this Bag bag, IEnumerable<Bag> bags)
        {
            if (!bag.CanHoldOtherBags) return false;
            return !bag.IsShinyGold 
                   && bag.Rule.CanHold.Any(holding => bags.Any(b => b.BagName == holding.Key && (b.IsShinyGold || CanHoldShinyGold(b, bags))));
        }

        public static int ShinyGoldTotalBagCount()
        {
            var shinyGoldBag = new Bag(Rules.Single(rule => rule.BagName == "shiny gold"));

            return shinyGoldBag.SumOfBags(Rules);
        }
    }
}
