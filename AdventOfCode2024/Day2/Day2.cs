using AdventOfCode2024.Helpers;


namespace AdventOfCode2024.Day2
{
    public class Day2(bool useActual = false) : Challenge(2, useActual)
    {
        public List<Report> Reports { get; } = [];

        public override void LoadData()
        {
            foreach (var values in Data.Select(line => line.Split(" ")))
            {
                Reports.Add(new Report(values.Select(int.Parse).ToArray()));
            }
        }
        public override int Part1()
        {
            return Reports.Count(report => report.IsSafe());
        }

        public override int Part2()
        {
            return Reports.Count(report => report.IsSafeProblemDampener());
        }
    }
}