using System.Text.RegularExpressions;

namespace AoC.Core.Day3
{
    public static class EnginePartNumberCalculator
    {
        private static readonly string SpecialCharacters = "#*&%$=@/+-";

        public static int CalculateSumOfPartNumbers(List<string> engineSchematic)
        {
            List<int> separatedNumbers = new();

            var patternToFindPartNumbers = @$"((?<=[{SpecialCharacters}])\d+|\d+(?=[{SpecialCharacters}]))";
            var patternToStripSpecialCharacters = @"^\D|\D$";

            for (var index = 0; index < engineSchematic.Count; index++)
            {
                var matches = Regex.Matches(engineSchematic[index], patternToFindPartNumbers);

                if (matches.Any())
                {
                    foreach (Match match in matches.Cast<Match>())
                    {
                        separatedNumbers.Add(GetNumberFromMatch(match.Value, patternToStripSpecialCharacters));
                    }
                }

                if (!IsSingleLineInput(engineSchematic.Count))
                {
                    separatedNumbers = AddNumbersFromAdjacentLines(index, separatedNumbers, engineSchematic);
                }
            }

            return separatedNumbers.Sum();
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
            var specialCharIndexesLineBelow = FindSpecialCharacterIndexes(adjacentLine);
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

        private static List<int> FindSpecialCharacterIndexes(string schematicLine)
        {
            List<int> indexes = new();

            for (int i = 0; i < schematicLine.Length; i++)
            {
                if (SpecialCharacters.Contains(schematicLine[i]))
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
