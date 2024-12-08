using AdventOfCode2024.Day6;

namespace AdventOfCode2024.Day8;

public class Map((int, int) mapSize)
{
    public List<Antenna> Antennae { get; } = [];
    private (int, int) MapSize { get; } = mapSize;

    public int GetNumberOfAntinodes(bool considerHarmonics = false)
    {
        HashSet<Position> antinodePositions = [];
        for (var i = 0; i < Antennae.Count; i++)
        {
            var antenna = Antennae[i];
            for (var j = i + 1; j < Antennae.Count; j++)
            {
                var otherAntenna = Antennae[j];
                if (antenna.Equals(otherAntenna)) continue;
                if (antenna.Frequency != otherAntenna.Frequency) continue;
                if (considerHarmonics)
                    antinodePositions.UnionWith(CalculateAntinodePositionsPart2(antenna.Position,
                        otherAntenna.Position));
                else
                    antinodePositions.UnionWith(CalculateAntinodePositions(antenna.Position,
                        otherAntenna.Position));
            }
        }

        return antinodePositions.Count;
    }

    public Position[] CalculateAntinodePositions(Position firstAntennaPosition, Position secondAntennaPosition)
    {
        List<Position> positions = [];
        var xDifference = secondAntennaPosition.X - firstAntennaPosition.X;
        var yDifference = secondAntennaPosition.Y - firstAntennaPosition.Y;

        positions.Add(new Position(firstAntennaPosition.Y - yDifference, firstAntennaPosition.X - xDifference));
        positions.Add(new Position(secondAntennaPosition.Y + yDifference, secondAntennaPosition.X + xDifference));

        return positions.Where(antinodePosition =>
            antinodePosition is { Y: >= 0, X: >= 0 } &&
            antinodePosition.Y < MapSize.Item1 &&
            antinodePosition.X < MapSize.Item2).ToArray();
    }

    public Position[] CalculateAntinodePositionsPart2(Position firstAntennaPosition, Position secondAntennaPosition)
    {
        List<Position> positions = [];
        var xDifference = secondAntennaPosition.X - firstAntennaPosition.X;
        var yDifference = secondAntennaPosition.Y - firstAntennaPosition.Y;


        var currentPosition = firstAntennaPosition;
        while (currentPosition is { Y: >= 0, X: >= 0 })
        {
            positions.Add(currentPosition);
            currentPosition = new Position(currentPosition.Y - yDifference, currentPosition.X - xDifference);
        }

        currentPosition = secondAntennaPosition;
        while ( currentPosition.Y < MapSize.Item1 &&
            currentPosition.X < MapSize.Item2)
        {
            positions.Add(currentPosition);
            currentPosition = new Position(currentPosition.Y + yDifference, currentPosition.X + xDifference);
        }
        
        return positions.Where(antinodePosition =>
            antinodePosition is { Y: >= 0, X: >= 0 } &&
            antinodePosition.Y < MapSize.Item1 &&
            antinodePosition.X < MapSize.Item2).ToArray();
    }
}