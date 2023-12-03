namespace AoC.Core.Day2
{
    public class CubeConundrumGame
    {
        public int Id { get; set; }

        public bool Valid { get; set; } = true;

        public List<Dictionary<string, int>> CubeDraws { get; set; } = new List<Dictionary<string, int>>();
    }
}
