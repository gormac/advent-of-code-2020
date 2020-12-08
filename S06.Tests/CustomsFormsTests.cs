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
        public void TestCustomsForms_Sum_Of_Answer_Count_Should_Be_11()
        {
            Helpers.GetSumOfAnswerCounts(_customsFormsGroups).Should().Be(11);
        }
    }
}
