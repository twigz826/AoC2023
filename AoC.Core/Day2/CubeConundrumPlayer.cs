
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

        public static int PlayGames(List<CubeConundrumGame> ccGames)
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
