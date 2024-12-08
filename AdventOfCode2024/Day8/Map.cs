namespace AdventOfCode2024.Day8;

public class Map((int,int) mapSize)
{
    public List<Antenna> Antennae { get; } = [];
    public (int, int) MapSize { get; } = mapSize;
}