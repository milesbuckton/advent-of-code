namespace AdventOfCode.SecretEntrance.Helpers
{
    internal static class PasswordHelper
    {
        private const int DialSize = 100;
        private const int StartingPoint = 50;
        private const int TargetPoint = 0;

        internal static int Calculate(string content)
        {
            int currentPoint = StartingPoint;
            int password = 0;

            foreach (string rotation in content.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries))
            {
                int clicks = int.Parse(rotation.AsSpan(1));

                currentPoint = ApplyRotation(clicks, currentPoint, rotation[0]);
                if (currentPoint == TargetPoint)
                    password += 1;
            }

            return password;
        }

        private static int ApplyRotation(int clicks, int currentPoint, char direction) => direction switch
        {
            'L' => ((currentPoint - clicks) % DialSize + DialSize) % DialSize,
            'R' => (currentPoint + clicks) % DialSize,
            _ => throw new ArgumentException($"Invalid direction: {direction}", nameof(direction))
        };
    }
}
