﻿using AoC.Core.Day4;
using FluentAssertions;

namespace AoC.Test.Day4
{
    public class ScratchCardSolverTests
    {
        [Fact]
        public void CalculatePointsTotal_WhenGivenAValidInputNoMatches_Returns0()
        {
            var input = new List<string> { "Card   1: 82 | 24" };
            var expectedOutput = 0;
            var totalPoints = ScratchCardSolver.CalculatePointsTotal(input);
            totalPoints.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculatePointsTotal_WhenGivenAValidInputOneMatch_Returns1()
        {
            var input = new List<string> { "Card   1: 82 | 82" };
            var expectedOutput = 1;
            var totalPoints = ScratchCardSolver.CalculatePointsTotal(input);
            totalPoints.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculatePointsTotal_WhenGivenAValidInputTwoMatches_Returns1()
        {
            var input = new List<string> { "Card   1: 82 41 | 82 41" };
            var expectedOutput = 2;
            var totalPoints = ScratchCardSolver.CalculatePointsTotal(input);
            totalPoints.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculatePointsTotal_WhenGivenAValidInputMultipleScratchcards_Returns1()
        {
            var input = new List<string> { "Card   1: 82 41 16 1 | 82 41 16 1",
                                           "Card   2: 82 41 | 82 41"};
            var expectedOutput = 8 + 2;
            var totalPoints = ScratchCardSolver.CalculatePointsTotal(input);
            totalPoints.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculateScratchCardsWon_WhenGivenAValidInputNoMatches_Returns1()
        {
            var input = new List<string> { "Card   1: 82 | 24" };
            var expectedOutput = 1;
            var totalPoints = ScratchCardSolver.CalculateScratchCardsWon(input);
            totalPoints.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculateScratchCardsWon_WhenGivenAValidInputOneMatch_Returns3()
        {
            var input = new List<string> { "Card   1: 82 | 82",
                                           "Card   2: 82 | 41"};
            var expectedOutput = 3;
            var totalPoints = ScratchCardSolver.CalculateScratchCardsWon(input);
            totalPoints.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculateScratchCardsWon_WhenGivenAValidInputManyMatches_ReturnsTotalScratchCards()
        {
            var input = new List<string> { "Card   1: 82 41 | 82 41", //Win copy of 2 and 3
                                           "Card   2: 82 | 82", //Original wins copy of 3, copy wins a copy of 3
                                           "Card   3: 82 | 41" }; //Original wins nothing, 1st copy, 2nd copy, 3rd copy
            var expectedOutput = 4 + 2 + 1;
            var totalPoints = ScratchCardSolver.CalculateScratchCardsWon(input);
            totalPoints.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculateScratchCardsWon_WhenGivenAValidInputManyMatchesManyCards_ReturnsTotalScratchCards()
        {
            var input = new List<string> { "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
                                           "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
                                           "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
                                           "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
                                           "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
                                           "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11" };
            var expectedOutput = 1 + 2 + 4 + 8 + 14 + 1;
            var totalPoints = ScratchCardSolver.CalculateScratchCardsWon(input);
            totalPoints.Should().Be(expectedOutput);
        }
    }
}
