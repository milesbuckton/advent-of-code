using System.Reflection;
using AdventOfCode.Common.Helpers;

namespace AdventOfCode.SecretEntrance.UnitTests.Fixtures
{
    public class PuzzleInputFixture
    {
        private const string Filename = "PuzzleInputTest.txt";

        public string SampleContent { get; }

        public PuzzleInputFixture()
        {
            SampleContent = PuzzleHelper.ReadEmbedded(Assembly.GetExecutingAssembly(), Filename);
        }
    }
}
