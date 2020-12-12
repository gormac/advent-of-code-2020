using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace S09.Tests
{
    public class XmasDataTests
    {
        private readonly IEnumerable<long> _xmasData;

        public XmasDataTests()
        {
            _xmasData = XmasData.Data.ToList();
        }

        [Fact]
        public void XmasTestData_Should_Contain_20_Numbers()
        {
            _xmasData.Count().Should().Be(20);
        }

        [Fact]
        public void XmasTestData_Should_Not_Validate_Successfully()
        {
            var xmasDataValidator = new XmasDataValidator(_xmasData, 5);
            xmasDataValidator.Validate().Should().BeFalse();
            xmasDataValidator.FailingNumber.Should().Be(127);
        }
    }
}
