using System.Reflection;

namespace AdventOfCode.Common.Helpers
{
    public static class PuzzleHelper
    {
        public static async Task<string> FetchAsync(int year, int day, string session, CancellationToken cancellationToken = default)
        {
            using HttpClient client = new();
            client.DefaultRequestHeaders.Add("User-Agent", "github.com/advent-of-code");
            client.DefaultRequestHeaders.Add("Cookie", $"session={session}");

            string url = $"https://adventofcode.com/{year}/day/{day}/input";

            return await client.GetStringAsync(url, cancellationToken);
        }

        public static string ReadEmbedded(Assembly assembly, string filename)
        {
            using Stream stream = assembly.GetManifestResourceStream(filename) ?? throw new FileNotFoundException($"Embedded resource '{filename}' not found.");
            using StreamReader reader = new(stream);

            return reader.ReadToEnd();
        }
    }
}
