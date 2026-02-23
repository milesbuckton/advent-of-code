using System.Reflection;
using AdventOfCode.Common.Helpers;
using AdventOfCode.SecretEntrance.Helpers;
using Microsoft.Extensions.Configuration;

namespace AdventOfCode.SecretEntrance
{
    internal static class Program
    {
        private const int Day = 1;
        private const string Filename = "PuzzleInput.txt";
        private const int Year = 2025;

        internal static async Task Main()
        {
            IConfiguration configuration = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true).Build();
            string session = configuration["AdventOfCode:Session"] ?? string.Empty;

            string content = await GetContentAsync(session);
            int password = PasswordHelper.Calculate(content);

            Console.WriteLine($"The final password is: {password}");
        }

        private static async Task<string> GetContentAsync(string session) => session.Length > 0
            ? await PuzzleHelper.FetchAsync(Year, Day, session)
            : PuzzleHelper.ReadEmbedded(Assembly.GetExecutingAssembly(), Filename);
    }
}
