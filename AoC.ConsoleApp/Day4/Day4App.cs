using AoC.Core.Day4;
using AoC.Core.Helpers;

namespace AoC.ConsoleApp.Day4
{
    public class Day4App
    {
        public void RunChallenges()
        {
            var input = InputHelper.GetPuzzleInput();

            var scratchCardTotal = ScratchCardSolver.CalculatePointsTotal(input);
            Console.WriteLine(scratchCardTotal);
        }
    }
}
