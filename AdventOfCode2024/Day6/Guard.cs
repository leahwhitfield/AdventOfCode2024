namespace AdventOfCode2024.Day6;

public class Guard(Position startingPosition, Direction startingDirection)
{
    public Position Position { get; private set; } = startingPosition;
    public Direction Direction { get; private set; } = startingDirection;

    public void MoveTo(Position position, Direction direction)
    {
        Position = position;
        Direction = direction;
    }

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
        Direction = Direction switch
        {
            Direction.Up => Direction.Right,
            Direction.Down => Direction.Left,
            Direction.Left => Direction.Up,
            Direction.Right => Direction.Down,
            _ => Direction
        };
    }
}

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}