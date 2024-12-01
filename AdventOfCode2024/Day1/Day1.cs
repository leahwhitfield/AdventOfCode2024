using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Day1
{
    public class Day1 : IChallenge
    {
        private readonly List<string> _data = [];
        public readonly List<int> FirstList = new();
        public readonly List<int> SecondList = new();

        public Day1(String input)
        {
            FileHelper.ReadFromInputFileByLine(input, (line) => _data.Add(line));
        }

        public void LoadLists()
        {
            foreach (var values in _data.Select(line => line.Split("   ")))
            {
                FirstList.Add(int.Parse(values[0]));
                SecondList.Add(int.Parse(values[1]));
            }
        }

        public void SortLists()
        {
            FirstList.Sort();
            SecondList.Sort();
        }

        public int Part1()
        {
            LoadLists();
            SortLists();

            var distanceCount = 0;
            for (int i = 0; i < FirstList.Count; i++)
            {
                distanceCount += GetDistance(i);
            }

            return distanceCount;
        }

        private int GetDistance(int i)
        {
            return Math.Abs(FirstList[i] - SecondList[i]);
        }

        private int GetSimilarityScore(int number)
        {
            return number * SecondList.FindAll(i => i == number).Count;
        }

        public int Part2()
        {
            LoadLists();
            SortLists();

            var similarityScore = 0;
            for (int i = 0; i < FirstList.Count; i++)
            {
                similarityScore += GetSimilarityScore(FirstList[i]);
            }

            return similarityScore;
        }
    }
}