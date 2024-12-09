namespace AdventOfCode2024.Day9;

public abstract class DiskSpace
{
    public int Size;
    public int[] BlockPositions;

    public DiskSpace(int size, int position)
    {
        Size = size;
        BlockPositions = new int[size];
        for (var i = 0; i < size; i++)
        {
            BlockPositions[i] = position + i;
        }
    }
}