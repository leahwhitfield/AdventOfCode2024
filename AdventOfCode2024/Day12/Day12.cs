using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Day12
{
    public class Day12(bool useActual = false) : Challenge(12, useActual)
    {
        public List<Region> Regions = [];

        public override void LoadData()
        {
            for (var i = 0; i < Data.Count; i++)
            {
                for (var j = 0; j < Data[i].Length; j++)
                {
                    var currentRegion = new Region(Data[i][j]);

                    if (Regions.Any(region =>
                            region.Name == currentRegion.Name && region.PlotPoints.Contains((i, j)))) continue;
                    currentRegion.PlotPoints.Add((i, j));
                    currentRegion = FindWholeRegion(currentRegion);
                    currentRegion.Area = GetArea(currentRegion);
                    currentRegion.Perimeter = GetPerimeter(currentRegion);
                    Regions.Add(currentRegion);
                }
            }
        }

        private Region FindWholeRegion(Region currentRegion)
        {
            var plotPoints = currentRegion.PlotPoints;
            SearchForRegions(currentRegion, plotPoints);
            SearchForRegions(currentRegion, plotPoints);

            currentRegion.PlotPoints = currentRegion.PlotPoints.Concat(plotPoints).ToHashSet();

            return currentRegion;
        }

        private void SearchForRegions(Region currentRegion, HashSet<(int, int)> plotPoints)
        {
            for (var i = 0; i < Data.Count; i++)
            {
                for (var j = 0; j < Data[i].Length; j++)
                {
                    if (currentRegion.Name != Data[i][j]) continue;
                    if (plotPoints.Count == 0) plotPoints.Add((i, j));
                    if (plotPoints.Any(
                            p => p.Item1 >= i - 1 && p.Item1 <= i + 1 && p.Item2 >= j - 1 && p.Item2 <= j + 1))
                    {
                        plotPoints.Add((i, j));
                    }
                }
            }
        }

        private int GetArea(Region region)
        {
            return region.PlotPoints.Count;
        }

        private int GetPerimeter(Region region)
        {
            var perimeter = 0;
            var rowIndexes = region.PlotPoints.Select(p => p.Item1).Distinct().Order();
            List<int> lastRowColumns = null;
            List<int> currentRowColumns;

            foreach (var rowIndex in rowIndexes)
            {
                currentRowColumns = GetColumnsInRow(region, rowIndex);
                if (rowIndex == rowIndexes.First())
                {
                    perimeter += currentRowColumns.Count();
                    lastRowColumns = GetColumnsInRow(region, rowIndex);
                }

                if (rowIndex == rowIndexes.Last())
                {
                    perimeter += currentRowColumns.Count();
                }

                perimeter += 2;
                if (lastRowColumns.Last() != currentRowColumns.Last())
                {
                    perimeter += Math.Abs(lastRowColumns.Last() - currentRowColumns.Last());
                }

                if (lastRowColumns.First() != currentRowColumns.First())
                {
                    perimeter += Math.Abs(lastRowColumns.First() - currentRowColumns.First());
                }

                perimeter += GetColumnGapLength(currentRowColumns);
                lastRowColumns = currentRowColumns;
            }

            return perimeter;
        }

        private int GetColumnGapLength(List<int> rowColumns)
        {
            var totalGap = 0;

            for (int i = 1; i < rowColumns.Count; i++)
            {
                var columnIndex = rowColumns[i];
                if (columnIndex - rowColumns[i - 1] > 1)
                {
                    totalGap += Math.Abs(columnIndex - rowColumns[i - 1]);
                }
            }

            return totalGap;
        }

        private List<int> GetColumnsInRow(Region region, int rowIndex)
        {
            return region.PlotPoints.Where(p => p.Item1 == rowIndex).Select(p => p.Item2).Order().ToList();
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