using AdventOfCode2024.Day6;

namespace AdventOfCode2024.Day8;

public class Antenna(char frequency, Position position)
{
    public char Frequency { get; } = frequency;
    public Position Position { get; } = position;

    public override bool Equals(object obj)
    {
        var item = obj as Antenna;

        if (item == null)
        {
            return false;
        }

        return Frequency.Equals(item.Frequency) && Position.Equals(item.Position);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Frequency, Position);
    }
}