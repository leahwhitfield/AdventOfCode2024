namespace AdventOfCode2024.Day12;

public class Region(char name)
{
    public char Name { get; set; } = name;
    public HashSet<(int, int)> PlotPoints { get; set; } = [];
    public (int, int) EndPoint { get; set; }
    public int Area { get; set; } = 0;
    public int Perimeter { get; set; } = 0;
}