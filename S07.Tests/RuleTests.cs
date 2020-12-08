using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace S07.Tests
{
    public class RuleTests
    {
        private readonly IEnumerable<Rule> _rules;

        public RuleTests()
        {
            _rules = Helpers.GetRules().ToList();
        }

        [Fact]
        public void TestRules_Should_Contain_9_Rules()
        {
            _rules.Count().Should().Be(9);
        }

        [Fact]
        public void TestRule_Checks()
        {
            // light red bags contain 1 bright white bag, 2 muted yellow bags.
            _rules.Single(r => r.BagName == "light red").CanHoldOtherBags.Should().BeTrue();
            _rules.Single(r => r.BagName == "light red").CanHold.Count.Should().Be(2);
            _rules.Single(r => r.BagName == "light red").CanHold.ContainsKey("bright white").Should().BeTrue();
            _rules.Single(r => r.BagName == "light red").CanHold["muted yellow"].Should().Be(2);

            // bright white bags contain 1 shiny gold bag.
            _rules.Single(r => r.BagName == "bright white").CanHoldOtherBags.Should().BeTrue();
            _rules.Single(r => r.BagName == "bright white").CanHold.Count.Should().Be(1);
            _rules.Single(r => r.BagName == "bright white").CanHold.ContainsKey("shiny gold").Should().BeTrue();
            _rules.Single(r => r.BagName == "bright white").CanHold["shiny gold"].Should().Be(1);

            // faded blue bags contain no other bags.
            _rules.Single(r => r.BagName == "faded blue").CanHoldOtherBags.Should().BeFalse();
            _rules.Single(r => r.BagName == "faded blue").CanHold.Count.Should().Be(0);
        }
    }
}
