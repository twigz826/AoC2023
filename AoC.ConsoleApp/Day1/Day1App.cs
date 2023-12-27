using AoC.Core.Day1;
using AoC.Core.Helpers;

namespace AoC.ConsoleApp.Day1
{
    public class Day1App
    {
        public List<string> CalibrationValues = new();

        public void RunFirstChallenge()
        {
            Console.WriteLine("Calibration values input. Enter 'end' when all values have been entered\nValues: ");

            while (true)
            {
                var calibrationValue = Console.ReadLine();

                if (InputHelper.IsInputComplete(calibrationValue))
                {
                    break;
                }

                AddValidStringToCalibrationValues(calibrationValue);
            }

            var calibrationTotal = CalibrationValueCalculator.CalculateTotal(CalibrationValues);

            Console.WriteLine($"Calibration total: {calibrationTotal}");
        }

        private void AddValidStringToCalibrationValues(string? calibrationValue)
        {
            if (!String.IsNullOrEmpty(calibrationValue))
            {
                CalibrationValues.Add(calibrationValue);
            }
        }
    }
}
