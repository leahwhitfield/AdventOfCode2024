namespace AdventOfCode2024.Day6;

public class Guard(Position startingPosition, Direction startingDirection)
{
    public Position Position { get; private set; } = startingPosition;
    public Direction Direction { get; private set; } = startingDirection;

    public void Move()
    {
        Position = Direction switch
        {
            Direction.Up => new Position(Position.Y - 1, Position.X),
            Direction.Down => new Position(Position.Y + 1, Position.X),
            Direction.Left => new Position(Position.Y, Position.X - 1),
            Direction.Right => new Position(Position.Y, Position.X + 1),
            _ => Position
        };
    }

    public void Turn()
    {
        Direction = DirectionMethods.Turn90Degrees(Direction);
    }
}

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

static class DirectionMethods
{
    public static Direction GetDirection(char arrow)
    {
        switch (arrow)
        {
            case '^':
                return Direction.Up;
            case '<':
                return Direction.Left;
            case '>':
                return Direction.Right;
            case 'v':
                return Direction.Down;
            default: return Direction.Up;
        }
    }

    public static Direction Turn90Degrees(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                return Direction.Right;
            case Direction.Down:
                return Direction.Left;
            case Direction.Left:
                return Direction.Up;
            case Direction.Right:
                return Direction.Down;
            default: return Direction.Up;
        }
    }
}