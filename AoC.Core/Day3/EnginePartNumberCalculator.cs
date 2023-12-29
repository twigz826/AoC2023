using System.Text.RegularExpressions;

namespace AoC.Core.Day3
{
    public static class EnginePartNumberCalculator
    {
        private static readonly string SpecialCharacters = "#*&%$=@/+-";
        private static readonly string PatternToStripSpecialCharacters = @"^\D|\D$";
        private static readonly string NumberMatchingPattern = @"\d+";
        private static readonly string AsteriskMatchingPattern = @"\*";

        public static int CalculateGearRatio(List<string> engineSchematic)
        {
            var total = 0;
            for (var index = 0; index < engineSchematic.Count; index++)
            {
                var asteriskMatches = GetAsteriskMatches(engineSchematic[index]);

                foreach (var asteriskMatch in asteriskMatches)
                {
                    string? prevRow = null;
                    string? nextRow = null;
                    if (index > 0)
                    {
                        prevRow = engineSchematic[index - 1];
                    }
                    if (index < engineSchematic.Count - 1)
                    {
                        nextRow = engineSchematic[index + 1];
                    }

                    var matchedNumbers = RetrieveAdjacentNumbers(asteriskMatch, engineSchematic[index], prevRow, nextRow);

                    if (matchedNumbers.Count == 2)
                    {
                        total += matchedNumbers[0] * matchedNumbers[1];
                    }
                }
            }

            return total;
        }

        public static int CalculateSumOfPartNumbers(List<string> engineSchematic)
        {
            List<int> separatedNumbers = new();

            var patternToFindPartNumbers = GetRegexPatternToMatchWholeNumbers(SpecialCharacters);

            for (var index = 0; index < engineSchematic.Count; index++)
            {
                var matches = Regex.Matches(engineSchematic[index], patternToFindPartNumbers);

                if (matches.Any())
                {
                    foreach (Match match in matches.Cast<Match>())
                    {
                        separatedNumbers.Add(GetNumberFromMatch(match.Value, PatternToStripSpecialCharacters));
                    }
                }

                if (!IsSingleLineInput(engineSchematic.Count))
                {
                    separatedNumbers = AddNumbersFromAdjacentLines(index, separatedNumbers, engineSchematic);
                }
            }

            return separatedNumbers.Sum();
        }

        private static List<int> GetAsteriskMatches(string engineSchematicLine)
        {
            List<int> matches = new();
            for (var index = 0; index < engineSchematicLine.Length; index++)
            {
                if (Regex.IsMatch(engineSchematicLine[index].ToString(), @"\*"))
                {
                    matches.Add(index);
                }
            }
            return matches;
        }

        private static List<int> RetrieveAdjacentNumbers(int asteriskIndex, string currentRow, string? previousRow, string? nextRow)
        {
            List<int> adjacentNumbers = new();

            var rowNumberMatches = Regex.Matches(currentRow, NumberMatchingPattern).ToList();

            if (previousRow != null)
            {
                rowNumberMatches.AddRange(Regex.Matches(previousRow, NumberMatchingPattern));
            }
            if (nextRow != null)
            {
                rowNumberMatches.AddRange(Regex.Matches(nextRow, NumberMatchingPattern));
            }

            var adjacentNums = rowNumberMatches
                .Where(row => asteriskIndex >= row.Index - 1 && asteriskIndex <= (row.Index + row.Length))
                .Select(match => int.Parse(match.Value));

            adjacentNumbers.AddRange(adjacentNums);

            return adjacentNumbers;
        }

        private static string GetRegexPatternToMatchWholeNumbers(string pattern)
        {
            return @$"((?<=[{pattern}])\d+|\d+(?=[{pattern}]))";
        }

        private static List<int> AddNumbersFromAdjacentLines(int index, List<int> separatedNumbers, List<string> engineSchematic)
        {
            if (IsFirstLine(index))
            {
                separatedNumbers.AddRange(GetMatchingNumbersFromLine(engineSchematic[index], engineSchematic[index + 1]));
            }
            else if (IsLastLine(index, engineSchematic.Count - 1))
            {
                separatedNumbers.AddRange(GetMatchingNumbersFromLine(engineSchematic[index], engineSchematic[index - 1]));
            }
            else
            {
                separatedNumbers.AddRange(GetMatchingNumbersFromLine(engineSchematic[index], engineSchematic[index - 1]));
                separatedNumbers.AddRange(GetMatchingNumbersFromLine(engineSchematic[index], engineSchematic[index + 1]));
            }

            return separatedNumbers;
        }

        private static int GetNumberFromMatch(string value, string patternToStripSpecialCharacters)
        {
            var numberString = Regex.Replace(value, patternToStripSpecialCharacters, "");
            return int.Parse(numberString);
        }

        private static bool IsSingleLineInput(int engineSchematicCount)
        {
            return engineSchematicCount == 1;
        }

        private static List<int> GetMatchingNumbersFromLine(string engineSchematicLine, string adjacentLine)
        {
            var specialCharIndexesLineBelow = FindSpecialCharacterIndexes(adjacentLine, SpecialCharacters);
            var numberIndexes = FindAllNumberIndexes(engineSchematicLine);

            var currentMatchingIndexes = FindMatchingIndexes(specialCharIndexesLineBelow, numberIndexes);
            return ExtractNumbersAtIndexes(engineSchematicLine, currentMatchingIndexes);
        }

        private static List<int> ExtractNumbersAtIndexes(string engineSchematicLine, List<int> matchingIndexes)
        {
            List<int> numbers = new();
            List<(int start, int end)> extractedRanges = new();

            foreach (var index in matchingIndexes)
            {
                var start = index;
                var end = index;

                while (start > 0 && char.IsDigit(engineSchematicLine[start - 1]))
                {
                    start--;
                }

                while (end < engineSchematicLine.Length && char.IsDigit(engineSchematicLine[end]))
                {
                    end++;
                }

                if (start != end)
                {
                    var range = (start, end);
                    if (!extractedRanges.Contains(range))
                    {
                        var number = int.Parse(engineSchematicLine[start..end]);
                        numbers.Add(number);
                        extractedRanges.Add(range);
                    }
                }
            }

            return numbers;
        }

        private static List<int> FindMatchingIndexes(List<int> specialCharIndexes, List<int> numberIndexes)
        {
            HashSet<int> matchingIndexes = new();

            foreach (int specialIndex in specialCharIndexes)
            {
                if (numberIndexes.Contains(specialIndex)) matchingIndexes.Add(specialIndex);
                if (numberIndexes.Contains(specialIndex - 1)) matchingIndexes.Add(specialIndex - 1);
                if (numberIndexes.Contains(specialIndex + 1)) matchingIndexes.Add(specialIndex + 1);
            }

            return new List<int>(matchingIndexes);
        }

        private static List<int> FindAllNumberIndexes(string schematicLine)
        {
            List<int> indexes = new();

            for (var i = 0; i < schematicLine.Length; i++)
            {
                if (char.IsDigit(schematicLine[i]))
                {
                    indexes.Add(i);
                }
            }

            return indexes;
        }

        private static List<int> FindSpecialCharacterIndexes(string schematicLine, string characterRegexPattern)
        {
            List<int> indexes = new();

            for (int i = 0; i < schematicLine.Length; i++)
            {
                if (characterRegexPattern.Contains(schematicLine[i]))
                {
                    indexes.Add(i);
                }
            }

            return indexes;
        }

        private static bool IsLastLine(int index, int count)
        {
            return index == count;
        }

        private static bool IsFirstLine(int index)
        {
            return index == 0;
        }
    }
}
