using AdventOfCode.SecretEntrance.Helpers;
using AdventOfCode.SecretEntrance.UnitTests.Fixtures;

namespace AdventOfCode.SecretEntrance.UnitTests
{
    public class PasswordHelperTests : IClassFixture<PuzzleInputFixture>
    {
        private readonly PuzzleInputFixture _fixture;

        public PasswordHelperTests(PuzzleInputFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [InlineData("X10")]
        [InlineData("U5")]
        public void Calculate_GivenInvalidDirection_ThrowsArgumentException(string content)
        {
            Assert.Throws<ArgumentException>(() => PasswordHelper.Calculate(content));
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("R50", 1)]
        [InlineData("L50", 1)]
        [InlineData("L51", 0)]
        [InlineData("R100", 0)]
        [InlineData("R50\nL50", 1)]
        [InlineData("R10\nR40", 1)]
        [InlineData("L51\nR1", 1)]
        public void Calculate_GivenRotations_ReturnsExpectedPassword(string content, int expected)
        {
            int password = PasswordHelper.Calculate(content);

            Assert.Equal(expected, password);
        }

        [Fact]
        public void Calculate_GivenSampleInput_ReturnsPassword()
        {
            int password = PasswordHelper.Calculate(_fixture.SampleContent);

            Assert.Equal(3, password);
        }

        [Theory]
        [InlineData("\r\n", 0)]
        [InlineData("R50\r\nL50\r\n", 1)]
        public void Calculate_GivenWindowsLineEndings_IgnoresEmptyEntries(string content, int expected)
        {
            int password = PasswordHelper.Calculate(content);

            Assert.Equal(expected, password);
        }
    }
}
