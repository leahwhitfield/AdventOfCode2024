namespace AdventOfCode2024.Helpers;

public abstract class Challenge : IChallenge
{
    public abstract int Part1();
    public abstract int Part2();

    protected readonly List<string> Data = [];

    public abstract void LoadData();

    public Challenge(char day, bool useActual)
    {
        var input = useActual ? "actual" : "example";
        FileHelper.ReadFromInputFileByLine(Constants.BasePath + "day" + day + "_" + input + ".txt",
            (line) => Data.Add(line));
        LoadData();
    }
}