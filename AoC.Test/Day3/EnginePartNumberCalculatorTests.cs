using AoC.Core.Day3;
using FluentAssertions;

namespace AoC.Test.Day3
{
    public class EnginePartNumberCalculatorTests
    {
        [Fact]
        public void CalculateSumOfPartNumbers_WhenGivenANumberString_Returns0()
        {
            var input = new List<string> { "456" };
            var expectedOutput = 0;
            var sumOfPartNumbers = EnginePartNumberCalculator.CalculateSumOfPartNumbers(input);
            sumOfPartNumbers.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculateSumOfPartNumbers_WhenGivenANumberStringFollowedByASpecialCharacter_ReturnsTheNumber()
        {
            var input = new List<string> { "456*" };
            var expectedOutput = 456;
            var sumOfPartNumbers = EnginePartNumberCalculator.CalculateSumOfPartNumbers(input);
            sumOfPartNumbers.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculateSumOfPartNumbers_WhenGivenANumberStringPrecededByASpecialCharacter_ReturnsTheNumber()
        {
            var input = new List<string> { "*456" };
            var expectedOutput = 456;
            var sumOfPartNumbers = EnginePartNumberCalculator.CalculateSumOfPartNumbers(input);
            sumOfPartNumbers.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculateSumOfPartNumbers_WhenGivenAStringWithTwoNumbersAndNoSpecialCharacters_Returns0()
        {
            var input = new List<string> { "456...24590" };
            var expectedOutput = 0;
            var sumOfPartNumbers = EnginePartNumberCalculator.CalculateSumOfPartNumbers(input);
            sumOfPartNumbers.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculateSumOfPartNumbers_WhenGivenAStringWithTwoNumbersThatTouchSpecialCharacters_ReturnsTheSumOfTheNumbers()
        {
            var input = new List<string> { "*456........544*" };
            var expectedOutput = 1000;
            var sumOfPartNumbers = EnginePartNumberCalculator.CalculateSumOfPartNumbers(input);
            sumOfPartNumbers.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculateSumOfPartNumbers_WhenGivenAStringWithTwoNumbersOneTouchesASpecialCharacter_ReturnsThatNumber()
        {
            var input = new List<string> { "*456........544" };
            var expectedOutput = 456;
            var sumOfPartNumbers = EnginePartNumberCalculator.CalculateSumOfPartNumbers(input);
            sumOfPartNumbers.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculateSumOfPartNumbers_WhenGivenAStringWithTwoLinesMultipleNumbersMultipleSpecialCharacters_ReturnsTheSum()
        {
            var input = new List<string> { "....573.613.........965............691......892..948.......964........439.375..................320......273...........352.284...............",
                                           ".......*.............*.....814...............$....*........../..94......*....=.............103............/..882*...........+..............." };
            var expectedOutput = 573 + 613 + 965 + 892 + 948 + 964 + 439 + 375 + 273 + 882 + 284;
            var sumOfPartNumbers = EnginePartNumberCalculator.CalculateSumOfPartNumbers(input);
            sumOfPartNumbers.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculateSumOfPartNumbers_WhenGivenAStringWithThreeLinesMultipleNumbersMultipleSpecialCharacters_ReturnsTheSum()
        {
            var input = new List<string> { "....573.613.........965............691......892..948.......964........439.375..................320......273...........352.284...............",
                                           ".......*.............*.....814...............$....*........../..94......*....=.............103............/..882*...........+...............",
                                           "...........328....598.....*........................819...................199........60*132..@....................685..........6.........493." };
            var expectedOutput = 573 + 613 + 965 + 892 + 948 + 964 + 439 + 375 + 273 + 284 + 814 + 103 + 882 + 598 + 819 + 199 + 60 + 132 + 685;
            var sumOfPartNumbers = EnginePartNumberCalculator.CalculateSumOfPartNumbers(input);
            sumOfPartNumbers.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculateSumOfPartNumbers_WhenGivenAStringWithFourLinesMultipleNumbersMultipleSpecialCharacters_ReturnsTheSum()
        {
            var input = new List<string> { "....573.613.........965............691......892..948.......964........439.375..................320......273...........352.284...............",
                                           ".......*.............*.....814...............$....*........../..94......*....=.............103............/..882*...........+...............",
                                           "...........328....598.....*........................819...................199........60*132..@....................685..........6.........493.",
                                           "777....763...*.........510...614..................................439..............................216......925.......748....*....540......." };
            var expectedOutput = 573 + 613 + 965 + 892 + 948 + 964 + 439 + 375 + 273 + 284
                + 814 + 103 + 882
                + 328 + 598 + 819 + 199 + 60 + 132 + 685 + 6
                + 510;
            var sumOfPartNumbers = EnginePartNumberCalculator.CalculateSumOfPartNumbers(input);
            sumOfPartNumbers.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculateSumOfPartNumbers_WhenGivenAStringWithFiveLinesMultipleNumbersMultipleSpecialCharacters_ReturnsTheSum()
        {
            var input = new List<string> { "....573.613.........965............691......892..948.......964........439.375..................320......273...........352.284...............",
                                           ".......*.............*.....814...............$....*........../..94......*....=.............103............/..882*...........+...............",
                                           "...........328....598.....*........................819...................199........60*132..@....................685..........6.........493.",
                                           "777....763...*.........510...614..................................439..............................216......925.......748....*....540.......",
                                           "...=...-....710.............../...273.....933.............%...753...=......33......@........213$.....*..408...*......*.......514....*...130."};
            var expectedOutput = 573 + 613 + 965 + 892 + 948 + 964 + 439 + 375 + 273 + 284
                + 814 + 103 + 882
                + 328 + 598 + 819 + 199 + 60 + 132 + 685 + 6
                + 777 + 763 + 510 + 614 + 439 + 216 + 925 + 748 + 540
                + 710 + 213 + 514;
            var sumOfPartNumbers = EnginePartNumberCalculator.CalculateSumOfPartNumbers(input);
            sumOfPartNumbers.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculateGearRatio_WhenGivenANumberString_Returns0()
        {
            var input = new List<string> { "112" };
            var expectedOutput = 0;
            var gearRatio = EnginePartNumberCalculator.CalculateGearRatio(input);
            gearRatio.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculateGearRatio_WhenGivenANumberStringWithOneAdjacentAsterisk_Returns0()
        {
            var input = new List<string> { "112*" };
            var expectedOutput = 0;
            var gearRatio = EnginePartNumberCalculator.CalculateGearRatio(input);
            gearRatio.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculateGearRatio_WhenGivenTwoNumbersWithAnAdjacentAsterisk_ReturnsTheProductOfTheNumbers()
        {
            var input = new List<string> { "112*10" };
            var expectedOutput = 1120;
            var gearRatio = EnginePartNumberCalculator.CalculateGearRatio(input);
            gearRatio.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculateGearRatio_WhenGivenAStringWithTwoLines_ReturnsTheGearRatio()
        {
            var input = new List<string> { "....573.613......",
                                           ".......*........." };
            var expectedOutput = 573 * 613;
            var sumOfPartNumbers = EnginePartNumberCalculator.CalculateGearRatio(input);
            sumOfPartNumbers.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculateGearRatio_WhenGivenAStringWithThreeLines_ReturnsTheGearRatio()
        {
            var input = new List<string> { "....573..........",
                                           ".......*.........",
                                           ".34....9....#1..."};
            var expectedOutput = 573 * 9;
            var sumOfPartNumbers = EnginePartNumberCalculator.CalculateGearRatio(input);
            sumOfPartNumbers.Should().Be(expectedOutput);
        }
    }
}
