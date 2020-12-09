using FluentAssertions;
using Xunit;

namespace S08.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void TestProgram_Accumulator_Should_Return_5()
        {
            int accumulator = Helpers.RunProgram();
            accumulator.Should().Be(5);
        }
    }
}
