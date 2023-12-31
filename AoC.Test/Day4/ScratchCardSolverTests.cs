using AoC.Core.Day4;
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
    }
}
