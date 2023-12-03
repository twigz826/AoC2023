namespace AoC.Core.Day2
{
    public static class CubeConundrumPlayer
    {
        public const int RedCubesMaximumNumber = 12;
        public const int BlueCubesMaximumNumber = 14;
        public const int GreenCubesMaximumNumber = 13;

        public static int PlayGames(List<CubeConundrumGame> ccGames)
        {
            var total = 0;

            foreach (var game in ccGames)
            {
                foreach (var draw in game.CubeDraws)
                {
                    foreach (var cubeColour in draw.Keys)
                    {
                        switch (cubeColour)
                        {
                            case "red":
                                if (draw[cubeColour] > RedCubesMaximumNumber)
                                {
                                    game.Valid = false;
                                }
                                break;
                            case "blue":
                                if (draw[cubeColour] > BlueCubesMaximumNumber)
                                {
                                    game.Valid = false;
                                }
                                break;
                            case "green":
                                if (draw[cubeColour] > GreenCubesMaximumNumber)
                                {
                                    game.Valid = false;
                                }
                                break;
                        }
                    }
                }
            }

            var validGames = ccGames.Where(game => game.Valid);
            foreach (var game in validGames)
            {
                total += game.Id;
            }

            return total;
        }
    }
}
