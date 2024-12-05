using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Day5
{
    public class Day5(bool useActual = false) : Challenge('5', useActual)
    {
        public List<(int, int)> PageOrderingRules = [];
        public List<int[]> Updates = [];
        public override void LoadData()
        {
            foreach (var line in Data)
            {
                if (line.Contains("|"))
                {
                    var rules = line.Split("|");
                    PageOrderingRules.Add((int.Parse(rules[0]), int.Parse(rules[1])));
                }

                if (line.Contains(","))
                {
                    Updates.Add(line.Split(",").Select(l => int.Parse(l)).ToArray());
                }
            }
        }


        public override int Part1()
        {
            return 0;
        }

        public override int Part2()
        {
            return 0;
        }
    }
}