namespace AdventOfCode2024.Day7;

public class CalibrationEquation(long testValue, long[] numbers)
{
    public long TestValue { get; } = testValue;
    public long[] Numbers { get; } = numbers;

    public bool IsPossiblyTrue()
    {
        return IsPossiblyTrue(TestValue, Numbers);
    }

    private bool IsPossiblyTrue(long runningTotal, long[] values)
    {
        for (int i = values.Length - 1; i >= 0; i--)
        {
            var currentNumber = values[i];
            if (runningTotal == currentNumber) return true;
            if (runningTotal % currentNumber != 0)
            {
                if (runningTotal - currentNumber < 0)
                {
                    return false;
                }

                runningTotal -= currentNumber;
            }
            else
            {
                if (IsPossiblyTrue((runningTotal / currentNumber), values.Take(i).ToArray())) return true;

                runningTotal -= currentNumber;
            }
        }

        return false;
    }
}