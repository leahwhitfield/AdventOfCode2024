namespace AdventOfCode2024.Day9;

public class File(int id, int size, int position) : DiskSpace(size, position)
{
    public int Id { get; } = id;
}