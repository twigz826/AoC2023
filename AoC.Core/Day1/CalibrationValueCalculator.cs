using System.Text.RegularExpressions;

namespace AoC.Core.Day1
{
    public static class CalibrationValueCalculator
    {
        private const string CalibrationNumberMatchingPattern = @"\d+";
        private static readonly Dictionary<string, string> StringToNumConvertor = new()
        {
            {"one", "1"}, {"two", "2"}, {"three", "3"}, {"four", "4"}, {"five", "5"},
            {"six", "6"}, {"seven", "7"}, {"eight", "8"}, {"nine", "9"}
        };

        public static int CalculateTotal(List<string> calibrationValues)
        {
            int total = 0;

            foreach (var calibrationValue in calibrationValues)
            {
                List<(string Word, int Index)> normalisedData = new();

                AddNumberWordsToNormalisedData(calibrationValue, normalisedData);
                AddNumbersToNormalisedData(calibrationValue, normalisedData);

                var stringsFromNormalisedData = GetOrderedStringsFromNormalisedData(normalisedData);
                var listOfNormalisedNumbers = ConvertWordsToNumbers(stringsFromNormalisedData);

                if (!listOfNormalisedNumbers.Any())
                {
                    Console.WriteLine("No valid numbers found in the string, total will be 0.");
                    return total;
                }

                var validTwoDigitNumber = CalculateCalibrationValue(listOfNormalisedNumbers);
                total += validTwoDigitNumber;
            }

            return total;
        }

        private static int CalculateCalibrationValue(IEnumerable<string> listOfNormalisedNumbers)
        {
            var firstDigit = listOfNormalisedNumbers.First().First();
            var secondDigit = listOfNormalisedNumbers.Last().Last();

            var combinedString = $"{firstDigit}{secondDigit}";
            return int.Parse(combinedString);
        }

        private static IEnumerable<string> ConvertWordsToNumbers(IEnumerable<string> stringsFromNormalisedData)
        {
            return stringsFromNormalisedData
                .Select(match => StringToNumConvertor.TryGetValue(match, out string? value) ? value : match);
        }

        private static IEnumerable<string> GetOrderedStringsFromNormalisedData(IEnumerable<(string Word, int Index)> normalisedData)
        {
            return normalisedData
                    .OrderBy(valueTuple => valueTuple.Index)
                    .Select(valueTuple => valueTuple.Word);
        }

        private static void AddNumbersToNormalisedData(string calibrationValue, List<(string Word, int Index)> normalisedData)
        {
            var numberMatches = Regex.Matches(calibrationValue, CalibrationNumberMatchingPattern)
               .Cast<Match>();

            foreach (var match in numberMatches)
            {
                normalisedData.Add((match.Value, match.Index));
            }
        }

        private static void AddNumberWordsToNormalisedData(string calibrationValue, List<(string Word, int Index)> normalisedData)
        {
            foreach (var numString in StringToNumConvertor.Keys)
            {
                var index = calibrationValue.IndexOf(numString);
                while (index != -1)
                {
                    normalisedData.Add((numString, index));
                    index = calibrationValue.IndexOf(numString, index + 1);
                }
            }
        }
    }
}