using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace S07.Tests
{
    public class BagTests
    {
        private readonly IEnumerable<Rule> _rules;

        public BagTests()
        {
            _rules = Helpers.GetRules().ToList();
        }

        [Fact]
        public void Four_TestBags_Should_Be_Able_To_Hold_Shiny_Gold_Bags()
        {
            var bags = _rules.Select(rule => new Bag(rule)).ToList();
            bags.Count(b => b.CanHoldShinyGold(bags)).Should().Be(4);
        }
    }
}