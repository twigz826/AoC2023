namespace AoC.Core.Day2
{
    public static class CubeConundrumPlayer
    {
        public const int RedCubesMaximumNumber = 12;
        public const int BlueCubesMaximumNumber = 14;
        public const int GreenCubesMaximumNumber = 13;

        private static readonly Dictionary<string, int> MaxCubesPerColor = new()
        {
            {"red", RedCubesMaximumNumber},
            {"blue", BlueCubesMaximumNumber},
            {"green", GreenCubesMaximumNumber}
        };

        public static int ProcessValidGames(List<CubeConundrumGame> ccGames)
        {
            var total = 0;

            foreach (var game in ccGames)
            {
                ValidateGame(game);
            }

            var validGames = ccGames.Where(game => game.Valid);
            foreach (var game in validGames)
            {
                total += game.Id;
            }

            return total;
        }

        public static int CalculateMinNumberOfCubesForGame(List<CubeConundrumGame> ccGames)
        {
            var total = 0;
            foreach (var game in ccGames)
            {
                total += ProductOfMinNumberOfCubes(game);
            }

            return total;
        }

        private static int ProductOfMinNumberOfCubes(CubeConundrumGame game)
        {
            var redMinNumber = GetMinNumberOfCubes("red", game);
            var greenMinNumber = GetMinNumberOfCubes("green", game);
            var blueMinNumber = GetMinNumberOfCubes("blue", game);
            return redMinNumber * greenMinNumber * blueMinNumber;
        }

        private static int GetMinNumberOfCubes(string colour, CubeConundrumGame game)
        {
            var maxCubeValue = game.CubeDraws
                .Where(draw => draw.ContainsKey(colour))
                .Select(draw => draw[colour])
                .DefaultIfEmpty(0)
                .Max();

            return maxCubeValue;
        }

        private static void ValidateGame(CubeConundrumGame game)
        {
            foreach (var draw in game.CubeDraws)
            {
                if (!IsDrawValid(draw))
                {
                    game.Valid = false;
                    break;
                }
            }
        }

        private static bool IsDrawValid(Dictionary<string, int> draw)
        {
            foreach (var cubeColour in draw.Keys)
            {
                if (draw[cubeColour] > MaxCubesPerColor[cubeColour])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
