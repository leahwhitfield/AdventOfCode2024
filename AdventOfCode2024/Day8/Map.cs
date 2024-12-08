using AdventOfCode2024.Day6;

namespace AdventOfCode2024.Day8;

public class Map((int, int) mapSize)
{
    public List<Antenna> Antennae { get; } = [];
    private (int, int) MapSize { get; } = mapSize;

    public int GetNumberOfAntinodes()
    {
        HashSet<Position> antinodePositions = [];
        for (var i = 0; i < Antennae.Count; i++)
        {
            var antenna = Antennae[i];
            for (var j = i + 1; j < Antennae.Count; j++)
            {
                var otherAntenna = Antennae[j];
                if (antenna.Equals(otherAntenna)) continue;
                if (antenna.Frequency == otherAntenna.Frequency)
                {
                    antinodePositions.UnionWith(CalculateAntinodePositions(antenna.Position, otherAntenna.Position));
                }
            }
        }

        return antinodePositions.Count;
    }

    public Position[] CalculateAntinodePositions(Position firstAntennaPosition, Position secondAntennaPosition)
    {
        List<Position> positions = [];
        var xDifference = firstAntennaPosition.X - secondAntennaPosition.X;
        var yDifference = firstAntennaPosition.Y - secondAntennaPosition.Y;

        positions.Add(new Position(firstAntennaPosition.Y + yDifference, firstAntennaPosition.X + xDifference));
        positions.Add(new Position(secondAntennaPosition.Y - yDifference, secondAntennaPosition.X - xDifference));
        
        return positions.Where(antinodePosition =>
            antinodePosition is { Y: >= 0, X: >= 0 } &&
            antinodePosition.Y < MapSize.Item1 &&
            antinodePosition.X < MapSize.Item2).ToArray();
    }
}