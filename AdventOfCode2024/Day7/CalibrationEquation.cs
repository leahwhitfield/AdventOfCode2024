namespace AdventOfCode2024.Day7;

public class CalibrationEquation(long testValue, long[] numbers)
{
    public long TestValue { get; } = testValue;
    public long[] Numbers { get; } = numbers;

    public bool IsPossiblyTrue(bool canConcat = false)
    {
        return IsPossiblyTrue(TestValue, Numbers, canConcat);
    }

    private bool IsPossiblyTrue(long runningTotal, long[] values, bool canConcat = false)
    {
        for (int i = values.Length - 1; i >= 0; i--)
        {
            var currentNumber = values[i];
            if (runningTotal == currentNumber) return true;
            if (runningTotal % currentNumber != 0)
            {
                if (runningTotal - currentNumber < 0)
                {
                    return canConcat && TryConcat(runningTotal, values, currentNumber, i);
                }

                if (canConcat && TryConcat(runningTotal, values, currentNumber, i)) return true;
                runningTotal -= currentNumber;
            }
            else
            {
                if (IsPossiblyTrue((runningTotal / currentNumber), values.Take(i).ToArray(), canConcat)) return true;
                if (canConcat && TryConcat(runningTotal, values, currentNumber, i)) return true;

                runningTotal -= currentNumber;
            }
        }
        return false;
    }

    private bool TryConcat(long runningTotal, long[] values, long currentNumber, int i)
    {
        var tryConcat = RemoveCurrentNumber(runningTotal, currentNumber);
        return tryConcat != runningTotal && IsPossiblyTrue(RemoveCurrentNumber(runningTotal, currentNumber),
            values.Take(i).ToArray(), true);
    }

    private static long RemoveCurrentNumber(long runningTotal, long currentNumber)
    {
        var newNumber = runningTotal;

        if (runningTotal.ToString().EndsWith(currentNumber.ToString()))
        {
            newNumber = long.Parse(runningTotal.ToString()
                .Remove(runningTotal.ToString().Length - currentNumber.ToString().Length));
        }

        return newNumber;
    }
}