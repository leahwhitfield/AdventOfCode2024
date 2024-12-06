namespace AdventOfCode2024.Day6;

public class Position(int y, int x)
{
    public int Y { get; } = y;
    public int X { get; } = x;

    public override bool Equals(object obj)
    {
        var item = obj as Position;

        if (item == null)
        {
            return false;
        }

        return Y.Equals(item.Y) && X.Equals(item.X);
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(X,Y);
    }
}