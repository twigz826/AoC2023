namespace AoC.Core.Day4
{
    public static class ScratchCardSolver
    {
        public static int CalculateScratchCardsWon(List<string> input)
        {
            Dictionary<int, int> scratchCardTracker = new();
            var cardNumber = 0;
            var total = input.Count;

            foreach (var scratchCardInput in input)
            {
                cardNumber += 1;
                var numberOfExtraCards = scratchCardTracker.TryGetValue(cardNumber, out int value) ? value : 0;

                var winningNumbers = ExtractWinningNumbers(scratchCardInput);
                var scratchCardNumbers = ExtractScratchCardNumbers(scratchCardInput);

                var totalWinningNumbersOnScratchCard = MatchWinningNumbersToScratchCard(scratchCardNumbers, winningNumbers);

                for (var i = 0; i < 1 + numberOfExtraCards; i++)
                {
                    for (var j = 0; j < totalWinningNumbersOnScratchCard; j++)
                    {
                        if (NoScratchCardsLeft(j, cardNumber, input.Count))
                        {
                            break;
                        }

                        scratchCardTracker = AggregateScratchCards(scratchCardTracker, cardNumber, j);
                    }
                }
            }

            total += TotalAdditionalScratchCardsWon(scratchCardTracker);
            return total;
        }

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

        private static int TotalAdditionalScratchCardsWon(Dictionary<int, int> scratchCardTracker)
        {
            return scratchCardTracker.Sum(item => item.Value);
        }

        private static int MatchWinningNumbersToScratchCard(List<string> scratchCardNumbers, List<string> winningNumbers)
        {
            var tracker = 0;
            foreach (var num in scratchCardNumbers)
            {
                if (winningNumbers.Contains(num))
                {
                    tracker += 1;
                }
            }

            return tracker;
        }

        private static Dictionary<int, int> AggregateScratchCards(Dictionary<int, int> scratchCardTracker, int cardNumber, int index)
        {
            if (!scratchCardTracker.ContainsKey(index + cardNumber + 1))
            {
                scratchCardTracker[index + cardNumber + 1] = 0;
            }

            scratchCardTracker[index + cardNumber + 1] += 1;
            return scratchCardTracker;
        }

        private static bool NoScratchCardsLeft(int index, int cardNumber, int count)
        {
            return index + cardNumber > count;
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
