using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Sdk;

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
            xmasDataValidator.InvalidNumber.Should().Be(127);
        }

        [Fact]
        public void XmasTestData_Encryption_Weakness_Should_Be_62()
        {
            var xmasDataValidator = new XmasDataValidator(_xmasData, 5);
            if (xmasDataValidator.Validate())
            {
                throw new XunitException("Xmas test data should not validate successfully.");
            }

            var (min, max) = xmasDataValidator.FindWeakness(xmasDataValidator.InvalidNumber);
            min.Should().Be(15);
            max.Should().Be(47);
            (min + max).Should().Be(62);
        }

        [Fact]
        public void XmasTestData_Encryption_Weakness_Based_On_Bad_Number_Should_Throw()
        {
            var xmasDataValidator = new XmasDataValidator(_xmasData, 5);
            Action action = () => xmasDataValidator.FindWeakness(1);
            action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*Encryption weakness not found based on number 1.*");
        }
    }
}
