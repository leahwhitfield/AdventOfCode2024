using AdventOfCode2024.Day6;

namespace AdventOfCode2024.Day8;

public class Antenna(char frequency, Position position)
{
    public char Frequency { get; } = frequency;
    public Position Position { get; } = position;
}