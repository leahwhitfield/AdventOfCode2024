using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Day7
{
    public class Day7(bool useActual = false) : BigChallenge(7, useActual)
    {
        public readonly List<CalibrationEquation> _calibrationEquations = [];

        public override void LoadData()
        {
            foreach (var line in Data)
            {
                var equation = line.Split(": ");
                var value = long.Parse(equation[0]);
                var numbers = equation[1].Split(" ").Select(long.Parse).ToArray();
                _calibrationEquations.Add(new CalibrationEquation(value, numbers));
            }
        }

        public override long Part1()
        {
            return _calibrationEquations.Where(equation => equation.IsPossiblyTrue()).Sum(equation => equation.TestValue);
        }


        public override long Part2()
        {
            return  _calibrationEquations.Where(equation => equation.IsPossiblyTrue(true)).Sum(equation => equation.TestValue);
        }
    }
}