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
    }
}
