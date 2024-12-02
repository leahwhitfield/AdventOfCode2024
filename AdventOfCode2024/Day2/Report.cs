namespace AdventOfCode2024.Day2;

public class Report(int[] levels)
{
    public int[] Levels { get; } = levels;

    public bool IsSafe()
    {
        var isIncreasing = true;
        for (int i = 1; i < Levels.Length; i++)
        {
            var previousLevel = Levels[i - 1];
            var currentLevel = Levels[i];
            if (i == 1)
            {
                if (currentLevel < previousLevel)
                {
                    isIncreasing = false;
                }
            }

            var difference = Math.Abs(currentLevel - previousLevel);
            if (difference is < 1 or > 3) return false;
            if (isIncreasing)
            {
                if (currentLevel < previousLevel) return false;
            }
            else
            {
                if (currentLevel > previousLevel) return false;
            }

        }

        return true;
    }
}