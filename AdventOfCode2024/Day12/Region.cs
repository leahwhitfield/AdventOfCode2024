namespace AdventOfCode2024.Test.Day12;

public class Region(char name, (int,int) startingPoint)
{
    public char Name { get; set; } = name;
    public (int,int) StartingPoint { get; set; } = startingPoint;
    public (int,int) EndPoint { get; set; }
    public int Area { get; set; } = 0;
    public int Perimeter { get; set; } = 0;
}