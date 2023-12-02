using AoC.Core.Day1;
using FluentAssertions;

namespace AoC.Test.Day1
{
    public class CalibrationValueCalculatorTests
    {
        [Fact]
        public void Calculate_WhenGivenASingleDigitStringInput_ReturnsATwoDigitNumberOfTheSameDigit()
        {
            var input = "1";
            var expectedOutput = 11;
            var calibrationValue = CalibrationValueCalculator.Calculate(input);
            calibrationValue.Should().Be(expectedOutput);
        }

        [Fact]
        public void Calculate_WhenGivenATwoDigitStringInput_ReturnsTheFirstAndLastDigitAsTwoDigitNumber()
        {
            var input = "12";
            var expectedOutput = 12;
            var calibrationValue = CalibrationValueCalculator.Calculate(input);
            calibrationValue.Should().Be(expectedOutput);
        }

        [Fact]
        public void Calculate_WhenGivenASingleDigitStringInputWithLetters_ReturnsATwoDigitNumberOfTheSameDigit()
        {
            var input = "1abc";
            var expectedOutput = 11;
            var calibrationValue = CalibrationValueCalculator.Calculate(input);
            calibrationValue.Should().Be(expectedOutput);
        }

        [Fact]
        public void Calculate_WhenGivenStringInputWithLettersAndNumbers_ReturnsTheFirstAndLastDigitAsTwoDigitNumber()
        {
            var input = "abc123def456ghi789";
            var expectedOutput = 19;
            var calibrationValue = CalibrationValueCalculator.Calculate(input);
            calibrationValue.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculateTotal_WhenGivenMultipleStringInputs_ReturnsTheTotalOfAllTwoDigitNumbersGenerated()
        {
            var input = new List<string> { "abc123def456ghi789", "81345678", "abcndmd5jdskfusk" };
            var expectedOutput = 19 + 88 + 55;
            var calibrationValue = CalibrationValueCalculator.CalculateTotal(input);
            calibrationValue.Should().Be(expectedOutput);
        }
    }
}