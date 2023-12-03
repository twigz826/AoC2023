using AoC.Core.Day1;
using FluentAssertions;

namespace AoC.Test.Day1
{
    public class CalibrationValueCalculatorTests
    {
        [Fact]
        public void Calculate_WhenGivenASingleDigitStringInput_ReturnsATwoDigitNumberOfTheSameDigit()
        {
            var input = new List<string> { "1" };
            var expectedOutput = 11;
            var calibrationValue = CalibrationValueCalculator.CalculateTotal(input);
            calibrationValue.Should().Be(expectedOutput);
        }

        [Fact]
        public void Calculate_WhenGivenATwoDigitStringInput_ReturnsTheFirstAndLastDigitAsTwoDigitNumber()
        {
            var input = new List<string> { "12" };
            var expectedOutput = 12;
            var calibrationValue = CalibrationValueCalculator.CalculateTotal(input);
            calibrationValue.Should().Be(expectedOutput);
        }

        [Fact]
        public void Calculate_WhenGivenASingleDigitStringInputWithLetters_ReturnsATwoDigitNumberOfTheSameDigit()
        {
            var input = new List<string> { "1abc" };
            var expectedOutput = 11;
            var calibrationValue = CalibrationValueCalculator.CalculateTotal(input);
            calibrationValue.Should().Be(expectedOutput);
        }

        [Fact]
        public void Calculate_WhenGivenStringInputWithLettersAndNumbers_ReturnsTheFirstAndLastDigitAsTwoDigitNumber()
        {
            var input = new List<string> { "abc123def456ghi789" };
            var expectedOutput = 19;
            var calibrationValue = CalibrationValueCalculator.CalculateTotal(input);
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

        [Fact]
        public void Calculate_WhenGivenStringInputWithANumberWord_ReturnsATwoDigitNumberOfTheSameDigit()
        {
            var input = new List<string> { "one" };
            var expectedOutput = 11;
            var calibrationValue = CalibrationValueCalculator.CalculateTotal(input);
            calibrationValue.Should().Be(expectedOutput);
        }

        [Fact]
        public void CalculateTotal_WhenGivenStringInputsWithANumberWordAndNumbers_ReturnsTheTotalOfAllTwoDigitNumbersGenerated()
        {
            var input = new List<string> { "two1nine", "eightwothree", "abcone2threexyz", "xtwone3four", "4nineeightseven2", "zoneight234", "7pqrstsixteen" };
            var expectedOutput = 29 + 83 + 13 + 24 + 42 + 14 + 76;
            var calibrationValue = CalibrationValueCalculator.CalculateTotal(input);
            calibrationValue.Should().Be(expectedOutput);
        }

        [Fact]
        public void Calculate_WhenGivenStringInputsWithANumberWordThatOverlaps_ReturnsTheCorrectTwoDigitNumber()
        {
            var input = new List<string> { "twone", "eightwo", "sevenine", "1", "2two4", "101eightwo" };
            var expectedOutput = 21 + 82 + 79 + 11 + 24 + 12;
            var calibrationValue = CalibrationValueCalculator.CalculateTotal(input);
            calibrationValue.Should().Be(expectedOutput);
        }
    }
}