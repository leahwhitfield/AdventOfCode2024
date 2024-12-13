using AdventOfCode2024.Helpers;
using AdventOfCode2024.Test.Day12;

namespace AdventOfCode2024.Day12
{
    public class Day12(bool useActual = false) : Challenge(12, useActual)
    {
        public List<Region> Regions = new List<Region>();

        public override void LoadData()
        {
            var currentRegion = Data[0][0];
            Regions.Add(new Region(currentRegion, (0, 0)));
            for (var i = 0; i < Data.Count; i++)
            {
                for (var j = 0; j < Data[i].Length; j++)
                {
                    if (Data[i][j] == currentRegion) continue;

                    var lastRegion = Regions.Last();
                    lastRegion.EndPoint = (i, j);
                    lastRegion.Area = GetArea(lastRegion);
                    lastRegion.Perimeter = GetPerimeter(lastRegion);
                    Regions.Add(new Region(currentRegion, (i, j)));
                }
            }
        }

        private int GetArea(Region region)
        {
            var area = 0;

            for (int i = region.StartingPoint.Item1; i <= region.EndPoint.Item1; i++)
            {
                for (int j = region.StartingPoint.Item2; j <= region.EndPoint.Item2; j++)
                {
                    if (Data[i][j] == region.Name) area++;
                }
            }

            // return Data.SelectMany(line => line).Count(letter => letter == c);
            return area;
        }

        private int GetPerimeter(Region region)
        {
            var perimeter = 4;

            var columns = new Dictionary<int, int>();
            var rows = new Dictionary<int, int>();
            for (var i = region.StartingPoint.Item1; i <= region.EndPoint.Item1; i++)
            {
                for (var j = region.StartingPoint.Item2; j <= region.EndPoint.Item2; j++)
                {
                    if (Data[i][j] != region.Name) continue;
                    if (!columns.TryAdd(j, 1)) columns[j]++;

                    if (!rows.TryAdd(i, 1)) rows[i]++;
                }
            }

            switch (rows.Count)
            {
                case 1 when columns.Count == 1:
                    return perimeter;
                case 1 when columns.Count > 1:
                    perimeter += 2 * (columns.Count - 1);
                    break;
            }

            switch (columns.Count)
            {
                case 1 when rows.Count > 1:
                    perimeter += 2 * (rows.Count - 1);
                    break;
                case > 1 when rows.Count > 1:
                    perimeter = 2 * (columns.Count + rows.Count);
                    break;
            }

            return perimeter;
        }

        public override long Part1()
        {
            return Regions.Sum(region => region.Area * region.Perimeter);
        }

        public override long Part2()
        {
            return 0;
        }
    }
}