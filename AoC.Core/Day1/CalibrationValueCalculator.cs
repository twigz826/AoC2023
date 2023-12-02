using System.Text.RegularExpressions;

namespace AoC.Core.Day1
{
    public static class CalibrationValueCalculator
    {
        public static int Calculate(string calibrationValue)
        {
            var digitMatchingPattern = @"\d+";
            var matches = Regex.Matches(calibrationValue, digitMatchingPattern)
                               .Cast<Match>()
                               .Select(m => m.Value)
                               .ToList();

            if (!matches.Any())
            {
                throw new InvalidOperationException("No numbers found in the string.");
            }

            var firstDigit = matches.First().First();
            var secondDigit = matches.Last().Last();

            var combinedString = $"{firstDigit}{secondDigit}";
            var calculateCalibrationValue = int.Parse(combinedString);
            return calculateCalibrationValue;
        }
    }
}