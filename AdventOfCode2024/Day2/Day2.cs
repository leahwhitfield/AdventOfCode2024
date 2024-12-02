using AdventOfCode2024.Helpers;


namespace AdventOfCode2024.Day2
{
    public class Day2(bool useActual = false) : Challenge('2', useActual)
    {
        public List<Report> Reports { get; } = [];

        public void LoadReports()
        {
            foreach (var values in Data.Select(line => line.Split(" ")))
            {
                Reports.Add(new Report(values.Select(int.Parse).ToArray()));
            }
        }
        public override int Part1()
        {
            LoadReports();

            return Reports.Count(report => report.IsSafe());
        }

        public override int Part2()
        {
            LoadReports();

            return Reports.Count(report => report.IsSafeProblemDampener());
        }
    }
}