using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Day1
{
    public class Day1 : IChallenge
    {
        private List<string> _data = new();

        public Day1(String input)
        {
            FileHelper.ReadFromInputFileByLine(input, (line) => _data.Add(line));
        }


        public int Part1()
        {
            return 0;
        }

        public int Part2()
        {
            return 0;
        }
    }
}