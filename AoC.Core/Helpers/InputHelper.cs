namespace AoC.Core.Helpers
{
    public static class InputHelper
    {
        public static bool IsInputComplete(string? input)
        {
            return input?.ToLower() == "end";
        }

        public static List<string> GetPuzzleInput()
        {
            Console.WriteLine("Puzzle input values. Enter 'end' when all values have been entered\nValues: ");
            List<string> input = new();

            while (true)
            {
                var puzzleInput = Console.ReadLine();

                if (InputHelper.IsInputComplete(puzzleInput))
                {
                    break;
                }

                input.Add(puzzleInput!);
            }

            return input;
        }
    }
}
