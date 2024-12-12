using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Day11
{
    public class Day11(bool useActual = false) : Challenge(11, useActual)
    {
        public long[] Stones = [];
        Dictionary<(long, long), long> Cache = [];

        public override void LoadData()
        {
            Stones = Data[0].Split(" ").Select(long.Parse).ToArray();
        }

        public long FindNumberOfDescendantsOfStone(long stone, int blinkTimes)
        {
            long count = 0;
            if (Cache.ContainsKey((stone, blinkTimes))) return Cache[(stone, blinkTimes)];

            if (stone.ToString().Length % 2 == 0)
            {
                var newStone = stone.ToString();
                var stone1 = long.Parse(newStone[new Range(0, newStone.Length / 2)]);
                var stone2 = long.Parse(newStone[new Range(newStone.Length / 2, newStone.Length)]);

                count++;

                if (blinkTimes - 1 == 0)
                {
                    Cache.Add((stone, blinkTimes), count);
                    return count;
                }
                count += FindNumberOfDescendantsOfStone(stone1,
                    blinkTimes - 1);
                count += FindNumberOfDescendantsOfStone(stone2,
                    blinkTimes - 1);
            }
            else
            {
                if (blinkTimes - 1 == 0)
                {
                    Cache.Add((stone, blinkTimes), count);
                    return count;
                }
                if (stone == 0)
                {
                    count += FindNumberOfDescendantsOfStone(1, blinkTimes - 1);
                }
                else
                {
                    if (blinkTimes - 1 == 0)
                    {
                        Cache.Add((stone, blinkTimes), count);
                        return count;
                    }
                    count += FindNumberOfDescendantsOfStone(stone * 2024, blinkTimes - 1);
                }
            }

            Cache.Add((stone, blinkTimes), count);
            return count;
        }


        public override long Part1()
        {
            return Stones.Aggregate<long, long>(Stones.Length,
                (current, stone) => current + FindNumberOfDescendantsOfStone(stone, 25));
        }


        public override long Part2()
        {
            return Stones.Aggregate<long, long>(Stones.Length,
                (current, stone) => current + FindNumberOfDescendantsOfStone(stone, 75));
        }
    }
}