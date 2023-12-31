
namespace AoC.Core.Day4
{
    public static class ScratchCardSolver
    {
        public static int CalculatePointsTotal(List<string> input)
        {
            var total = 0;

            foreach (var scratchCardInput in input)
            {
                var tracker = 0;

                var winningNumbers = ExtractWinningNumbers(scratchCardInput);
                var scratchCardNumbers = ExtractScratchCardNumbers(scratchCardInput);

                foreach (var num in scratchCardNumbers)
                {
                    if (winningNumbers.Contains(num))
                    {
                        tracker += 1;
                    }
                }

                if (tracker > 0)
                {
                    var points = (int)Math.Pow(2, tracker - 1);
                    total += points;
                }
            }

            return total;
        }

        private static List<string> ExtractScratchCardNumbers(string scratchCardInput)
        {
            var startIndexScratchCard = scratchCardInput.IndexOf('|') + 1;
            var endIndexScratchCard = scratchCardInput.Length;
            var scratchCard = scratchCardInput[startIndexScratchCard..endIndexScratchCard]
                .Split(" ")
                .Where(num => !String.IsNullOrEmpty(num))
                .ToList();

            return scratchCard;
        }

        private static List<string> ExtractWinningNumbers(string scratchCardInput)
        {
            var startIndexWinningNumbers = scratchCardInput.IndexOf(':') + 1;
            var endIndexWinningNumbers = scratchCardInput.IndexOf('|');
            var winningNumbers = scratchCardInput[startIndexWinningNumbers..endIndexWinningNumbers]
                .Split(" ")
                .Where(num => !String.IsNullOrEmpty(num))
                .ToList();

            return winningNumbers;
        }
    }
}
