namespace AdventOfCode2024.Day6;

public class LabMap((int, int) mapSize)
{
    public Guard Guard;
    public readonly List<Position> Obstacles = [];
    public (int, int) MapSize = mapSize;
    private HashSet<Position> _positionsVisited = [];
    
    public int MoveGuard()
    {
        _positionsVisited.Add(Guard.Position);
        while (GuardWithinMap())
        {
            if (GuardCanMove())
            {
                Guard.Move();
                if (GuardWithinMap())
                {
                    _positionsVisited.Add(Guard.Position);
                }
            }
            else
            {
                Guard.Turn();
            }
        }

        return _positionsVisited.Count;
    }

    private bool GuardWithinMap()
    {
        return Guard.Position.Y < MapSize.Item1 && Guard.Position.Y >= 0 && Guard.Position.X < MapSize.Item2 &&
               Guard.Position.X >= 0;
    }

    private bool GuardCanMove()
    {
        return Guard.Direction switch
        {
            Direction.Up => !Obstacles.Contains(new Position(Guard.Position.Y - 1, Guard.Position.X)),
            Direction.Right => !Obstacles.Contains(new Position(Guard.Position.Y, Guard.Position.X + 1)),
            Direction.Down => !Obstacles.Contains(new Position(Guard.Position.Y + 1, Guard.Position.X)),
            _ => !Obstacles.Contains(new Position(Guard.Position.Y, Guard.Position.X - 1))
        };
    }
}