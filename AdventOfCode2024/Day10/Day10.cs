using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Day10
{
    public class Day10(bool useActual = false) : Challenge(10, useActual)
    {
        public int[][] Map;

        public override void LoadData()
        {
            Map = new int[Data.Count][];
            for (var i = 0; i < Data.Count; i++)
            {
                var line = Data[i];
                Map[i] = line.Select(x => int.Parse(x.ToString())).ToArray();
            }
        }

        public int FindTrailheads(bool shouldBeDistinct = true)
        {
            var startingPositions = GetStartingPositions();
            int totalTrailheadScore = 0;

            foreach (var startingPosition in startingPositions)
            {
                List<(int, int)> currentTrailHead = [startingPosition];

                if (shouldBeDistinct) totalTrailheadScore += NinePointsCanNavigateTo(currentTrailHead).Count;
                else totalTrailheadScore += NumberOfPathsToNinePoints(currentTrailHead);
            }

            return totalTrailheadScore;
        }

        private int NumberOfPathsToNinePoints(List<(int, int)> currentTrailHead)
        {
            var currentPosition = currentTrailHead.Last();
            List<(int, int)> directions = FindPossibleDirections(currentPosition, currentTrailHead);
            int score = 0;

            foreach (var direction in directions)
            {
                currentTrailHead.Add((direction.Item1, direction.Item2));

                score += NumberOfPathsToNinePoints(currentTrailHead);
                currentTrailHead.Remove(currentTrailHead.Last());
            }

            if (currentTrailHead.Count > 9) score++;

            return score;
        }

        private HashSet<(int, int)> NinePointsCanNavigateTo(List<(int, int)> currentTrailHead)
        {
            var currentPosition = currentTrailHead.Last();
            List<(int, int)> directions = FindPossibleDirections(currentPosition, currentTrailHead);
            HashSet<(int, int)> nineHeightPositionsReached = [];


            foreach (var direction in directions)
            {
                currentTrailHead.Add((direction.Item1, direction.Item2));

                nineHeightPositionsReached =
                    nineHeightPositionsReached.Union(NinePointsCanNavigateTo(currentTrailHead)).ToHashSet();
                currentTrailHead.Remove(currentTrailHead.Last());
            }

            if (currentTrailHead.Count > 9)
            {
                nineHeightPositionsReached.Add(currentPosition);
            }

            return nineHeightPositionsReached;
        }

        private List<(int, int)> FindPossibleDirections((int, int) currentPosition, List<(int, int)> currentTrailHead)
        {
            List<(int, int)> possibleDirections = [];
            // Look right
            if (LookInDirection(currentPosition, currentTrailHead.Count, 0, 1))
                possibleDirections.Add((currentPosition.Item1, currentPosition.Item2 + 1));

            // Look left
            if (LookInDirection(currentPosition, currentTrailHead.Count, 0, -1))
                possibleDirections.Add((currentPosition.Item1, currentPosition.Item2 - 1));

            // Look down
            if (LookInDirection(currentPosition, currentTrailHead.Count, 1, 0))
                possibleDirections.Add((currentPosition.Item1 + 1, currentPosition.Item2));

            // Look up
            if (LookInDirection(currentPosition, currentTrailHead.Count, -1, 0))
                possibleDirections.Add((currentPosition.Item1 - 1, currentPosition.Item2));

            return possibleDirections;
        }

        private bool LookInDirection((int, int) currentPosition, int nextNumber, int y, int x)
        {
            var positionToCheck = (currentPosition.Item1 + y, currentPosition.Item2 + x);
            if (positionToCheck.Item1 < 0 || positionToCheck.Item2 < 0 || positionToCheck.Item1 >= Map.Length ||
                positionToCheck.Item2 >= Map[0].Length) return false;
            var potentialNextStep = Map[positionToCheck.Item1][positionToCheck.Item2];
            return potentialNextStep == nextNumber;
        }


        public List<(int, int)> GetStartingPositions()
        {
            List<(int, int)> startingPositions = [];
            for (int i = 0; i < Map.Length; i++)
            {
                for (int j = 0; j < Map[i].Length; j++)
                {
                    if (Map[i][j] == 0) startingPositions.Add((i, j));
                }
            }

            return startingPositions;
        }

        public override long Part1()
        {
            return FindTrailheads();
        }


        public override long Part2()
        {
            return FindTrailheads(false);
        }
    }
}