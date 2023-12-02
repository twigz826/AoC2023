using AoC.Core.Day1;

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

                if (IsInputComplete(calibrationValue))
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

        private static bool IsInputComplete(string? input)
        {
            return input?.ToLower() == "end";
        }
    }
}
