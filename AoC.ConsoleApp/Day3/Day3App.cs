using AoC.Core.Day3;
using AoC.Core.Helpers;

namespace AoC.ConsoleApp.Day3
{
    public class Day3App
    {
        public void RunChallenges()
        {
            var input = InputHelper.GetPuzzleInput();

            var engineSchematicNumbers = EnginePartNumberCalculator.CalculateSumOfPartNumbers(input);
            var gearRatioTotal = EnginePartNumberCalculator.CalculateGearRatio(input);

            Console.WriteLine(gearRatioTotal);
        }
    }
}
