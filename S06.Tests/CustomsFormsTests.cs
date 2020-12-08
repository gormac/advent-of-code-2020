using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace S06.Tests
{
    public class CustomsFormsTests
    {
        private readonly IEnumerable<string> _customsFormsGroups;

        public CustomsFormsTests()
        {
            _customsFormsGroups = Helpers.GetCustomsFormsGroupsLines("testforms.txt");
        }

        [Fact]
        public void TestCustomsForms_Should_Have_5_Groups()
        {
            _customsFormsGroups.Count().Should().Be(5);
        }

        [Fact]
        public void TestCustomsForms_Sum_Of_Anyone_Answered_Count_Should_Be_11()
        {
            Helpers.GetSumOfAnyoneAnsweredCounts(_customsFormsGroups).Should().Be(11);
        }

        [Fact]
        public void TestCustomsForms_Sum_Of_All_Answered_Count_Should_Be_6()
        {
            Helpers.GetSumOfAllAnsweredCounts(_customsFormsGroups).Should().Be(6);
        }
    }
}
