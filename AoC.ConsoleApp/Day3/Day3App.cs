using AoC.Core.Day3;
using AoC.Core.Helpers;

namespace AoC.ConsoleApp.Day3
{
    public class Day3App
    {
        public List<string> schematicLines = new();

        public void RunChallenges()
        {
            Console.WriteLine("Puzzle input values. Enter 'end' when all values have been entered\nValues: ");

            while (true)
            {
                var puzzleInput = Console.ReadLine();

                if (InputHelper.IsInputComplete(puzzleInput))
                {
                    break;
                }

                schematicLines.Add(puzzleInput!);
            }

            var engineSchematicNumbers = EnginePartNumberCalculator.CalculateSumOfPartNumbers(schematicLines);
            var gearRatioTotal = EnginePartNumberCalculator.CalculateGearRatio(schematicLines);

            Console.WriteLine(gearRatioTotal);
        }
    }
}
