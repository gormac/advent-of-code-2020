using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace S10.Tests
{
    public class AdapterDataTests
    {
        private readonly IEnumerable<int> _adapters;

        public AdapterDataTests()
        {
            _adapters = AdapterData.Adapters;
        }

        [Fact]
        public void AdapterTestData_Should_Contain_31_Numbers()
        {
            _adapters.Count().Should().Be(31);
        }

        [Fact]
        public void TestChain_Jolt_Count_Should_Be_22_10()
        {
            var chain = new Chain(_adapters);
            chain.GetJoltCount().Should().Be((22, 10));
        }
    }
}
