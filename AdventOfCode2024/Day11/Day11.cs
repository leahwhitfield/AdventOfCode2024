using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Day11
{
    public class Day11(bool useActual = false) : Challenge(11, useActual)
    {
        public long[] Stones = [];

        public override void LoadData()
        {
            Stones = Data[0].Split(" ").Select(long.Parse).ToArray();
        }

        public void Blink()
        {
            List<long> newLayout = [];
            foreach (var stone in Stones)
            {
                if (stone == 0) newLayout.Add(1);
                else if (stone.ToString().Length % 2 == 0)
                {
                    var newStone = stone.ToString();
                    newLayout.Add(long.Parse(newStone[new Range(0, newStone.Length / 2)]));
                    newLayout.Add(long.Parse(newStone[new Range(newStone.Length / 2, newStone.Length)]));
                }
                else newLayout.Add(stone * 2024);
            }

            Stones = newLayout.ToArray();
        }


        public override long Part1()
        {
            for (int i = 0; i < 25; i++)
            {
                Blink();
            }

            return Stones.Length;
        }


        public override long Part2()
        {
            return 0;
        }
    }
}