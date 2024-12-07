namespace AdventOfCode2024.Helpers;

public abstract class BigChallenge
{
    public abstract long Part1();
    public abstract long Part2();

    protected readonly List<string> Data = [];

    public abstract void LoadData();

    public BigChallenge(char day, bool useActual)
    {
        var input = useActual ? "actual" : "example";
        FileHelper.ReadFromInputFileByLine(Constants.BasePath + "day" + day + "_" + input + ".txt",
            (line) => Data.Add(line));
        LoadData();
    }
}