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
    }
}