namespace AoC.Core.Helpers
{
    public static class InputHelper
    {
        public static bool IsInputComplete(string? input)
        {
            return input?.ToLower() == "end";
        }
    }
}
