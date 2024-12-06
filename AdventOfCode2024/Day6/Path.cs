namespace AdventOfCode2024.Day6;

public class Path(Position position, Direction direction)
{
    public readonly Position Position = position;
    public Direction Direction = direction;


    public override bool Equals(object obj)
    {
        var item = obj as Path;

        if (item == null)
        {
            return false;
        }

        return Position.Equals(item.Position) && Direction.Equals(item.Direction);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Position, direction);
    }
}