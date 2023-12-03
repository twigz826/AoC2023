using AoC.Core.Day2;
using FluentAssertions;

namespace AoC.Test.Day2
{
    public class CubeConundrumPlayerTests
    {
        [Fact]
        public void PlayGames_WhenProvidedAListWithAValidGame_ReturnsTheIdOfTheCubeConundrumGame()
        {
            var ccGame = new List<CubeConundrumGame>()
            {
                new()
                {
                    Id = 1,
                    CubeDraws = new List<Dictionary<string, int>>()
                    { new()
                    { { "red", 1 }, { "blue", 2 }, { "green", 3} }
                    }
                }
            };

            var result = CubeConundrumPlayer.PlayGames(ccGame);
            result.Should().Be(1);
        }

        [Fact]
        public void PlayGames_WhenProvidedAListWithOneInvalidGameExceedingRedMaxLimit_Returns0()
        {
            var ccGame = new List<CubeConundrumGame>()
            {
                new()
                {
                    Id = 1,
                    CubeDraws = new List<Dictionary<string, int>>()
                    { new()
                    { { "red", 20 }, { "blue", 2 }, { "green", 3} }
                    }
                }
            };

            var result = CubeConundrumPlayer.PlayGames(ccGame);
            result.Should().Be(0);
        }

        [Fact]
        public void PlayGames_WhenProvidedAListWithOneInvalidGameExceedingBlueMaxLimit_Returns0()
        {
            var ccGame = new List<CubeConundrumGame>()
            {
                new()
                {
                    Id = 1,
                    CubeDraws = new List<Dictionary<string, int>>()
                    { new()
                    { { "red", 1 }, { "blue", 15 }, { "green", 3} }
                    }
                }
            };

            var result = CubeConundrumPlayer.PlayGames(ccGame);
            result.Should().Be(0);
        }

        [Fact]
        public void PlayGames_WhenProvidedAListWithOneInvalidGameExceedingGreenMaxLimit_Returns0()
        {
            var ccGame = new List<CubeConundrumGame>()
            {
                new()
                {
                    Id = 1,
                    CubeDraws = new List<Dictionary<string, int>>()
                    { new()
                    { { "red", 1 }, { "blue", 1 }, { "green", 14} }
                    }
                }
            };

            var result = CubeConundrumPlayer.PlayGames(ccGame);
            result.Should().Be(0);
        }


        [Fact]
        public void PlayGames_WhenProvidedAListWithAValidGameWithMultipleDraws_ReturnsTheId()
        {
            var ccGame = new List<CubeConundrumGame>()
            {
                new()
                {
                    Id = 1,
                    CubeDraws = new List<Dictionary<string, int>>()
                    {
                        new()
                        { { "red", 1 }, { "blue", 1 }, { "green", 1} },
                        new()
                        { { "red", 2 }, { "blue", 2 }, { "green", 2} },
                        new()
                        { { "red", 3 }, { "blue", 3 }, { "green", 3} },
                    }
                }
            };

            var result = CubeConundrumPlayer.PlayGames(ccGame);
            result.Should().Be(1);
        }

        [Fact]
        public void PlayGames_WhenProvidedAListWithMultipleValidGames_ReturnsTheSumOfTheIds()
        {
            var ccGame = new List<CubeConundrumGame>()
            {
                new()
                {
                    Id = 1,
                    CubeDraws = new List<Dictionary<string, int>>()
                    {
                        new()
                        { { "red", 1 }, { "blue", 1 }, { "green", 1} },
                        new()
                        { { "red", 2 }, { "blue", 2 }, { "green", 2} },
                        new()
                        { { "red", 3 }, { "blue", 3 }, { "green", 3} },
                    }
                },
                new()
                {
                    Id = 2,
                    CubeDraws = new List<Dictionary<string, int>>()
                    {
                        new()
                        { { "red", 4 }, { "blue", 5 }, { "green", 6} },
                        new()
                        { { "red", 7 }, { "blue", 8 }, { "green", 9} },
                        new()
                        { { "red", 10 }, { "blue", 11 }, { "green", 12} },
                    }
                },
            };

            var result = CubeConundrumPlayer.PlayGames(ccGame);
            result.Should().Be(3);
        }

        [Fact]
        public void PlayGames_WhenProvidedAListWithValidAndInvalidGames_ReturnsTheSumOfTheValidIds()
        {
            var ccGame = new List<CubeConundrumGame>()
            {
                new()
                {
                    Id = 3,
                    CubeDraws = new List<Dictionary<string, int>>()
                    {
                        new()
                        { { "red", 1 }, { "blue", 1 }, { "green", 1} },
                        new()
                        { { "red", 2 }, { "blue", 2 }, { "green", 2} },
                        new()
                        { { "red", 3 }, { "blue", 3 }, { "green", 3} },
                    }
                },
                new()
                {
                    Id = 2,
                    CubeDraws = new List<Dictionary<string, int>>()
                    {
                        new()
                        { { "red", 4 }, { "blue", 5 }, { "green", 6} },
                        new()
                        { { "red", 7 }, { "blue", 8 }, { "green", 9} },
                        new()
                        { { "red", 10 }, { "blue", 11 }, { "green", 12} },
                    }
                },
                new()
                {
                    Id = 1,
                    CubeDraws = new List<Dictionary<string, int>>()
                    {
                        new()
                        { { "red", 4 }, { "blue", 5 }, { "green", 6} },
                        new()
                        { { "red", 7 }, { "blue", 20 }, { "green", 9} },
                        new()
                        { { "red", 10 }, { "blue", 11 }, { "green", 12} },
                    }
                },
            };

            var result = CubeConundrumPlayer.PlayGames(ccGame);
            result.Should().Be(5);
        }
    }
}
