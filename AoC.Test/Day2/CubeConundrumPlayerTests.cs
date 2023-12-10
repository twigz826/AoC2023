using AoC.Core.Day2;
using FluentAssertions;

namespace AoC.Test.Day2
{
    public class CubeConundrumPlayerTests
    {
        [Fact]
        public void ProcessValidGames_WhenProvidedAListWithAValidGame_ReturnsTheIdOfTheCubeConundrumGame()
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

            var result = CubeConundrumPlayer.ProcessValidGames(ccGame);
            result.Should().Be(1);
        }

        [Fact]
        public void ProcessValidGames_WhenProvidedAListWithOneInvalidGameExceedingRedMaxLimit_Returns0()
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

            var result = CubeConundrumPlayer.ProcessValidGames(ccGame);
            result.Should().Be(0);
        }

        [Fact]
        public void ProcessValidGames_WhenProvidedAListWithOneInvalidGameExceedingBlueMaxLimit_Returns0()
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

            var result = CubeConundrumPlayer.ProcessValidGames(ccGame);
            result.Should().Be(0);
        }

        [Fact]
        public void ProcessValidGames_WhenProvidedAListWithOneInvalidGameExceedingGreenMaxLimit_Returns0()
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

            var result = CubeConundrumPlayer.ProcessValidGames(ccGame);
            result.Should().Be(0);
        }


        [Fact]
        public void ProcessValidGames_WhenProvidedAListWithAValidGameWithMultipleDraws_ReturnsTheId()
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

            var result = CubeConundrumPlayer.ProcessValidGames(ccGame);
            result.Should().Be(1);
        }

        [Fact]
        public void ProcessValidGames_WhenProvidedAListWithMultipleValidGames_ReturnsTheSumOfTheIds()
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

            var result = CubeConundrumPlayer.ProcessValidGames(ccGame);
            result.Should().Be(3);
        }

        [Fact]
        public void ProcessValidGames_WhenProvidedAListWithValidAndInvalidGames_ReturnsTheSumOfTheValidIds()
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

            var result = CubeConundrumPlayer.ProcessValidGames(ccGame);
            result.Should().Be(5);
        }

        [Fact]
        public void CalculateMinNumberOfCubesForGame_WhenProvidedAListWithAGameWithOneDraw_ReturnsTheProductOfTheNumberOfEachCube()
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

            var result = CubeConundrumPlayer.CalculateMinNumberOfCubesForGame(ccGame);
            result.Should().Be(6);
        }

        [Fact]
        public void CalculateMinNumberOfCubesForGame_WhenProvidedAListWithAGameWithMultipleDraws_ReturnsTheProductOfTheMaxNumberOfEachCube()
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

            var result = CubeConundrumPlayer.CalculateMinNumberOfCubesForGame(ccGame);
            result.Should().Be(27);
        }

        [Fact]
        public void CalculateMinNumberOfCubesForGame_WhenProvidedAListWithMultipleGames_ReturnsTheSumOfTheProductsOfTheNumberOfEachCube()
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
                        { { "red", 10 }, { "blue", 10 }, { "green", 10} },
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
                        { { "red", 100 }, { "blue", 100 }, { "green", 100} },
                    }
                },
            };

            var result = CubeConundrumPlayer.CalculateMinNumberOfCubesForGame(ccGame);
            result.Should().Be(27 + 1000 + 1000000);
        }
    }
}
