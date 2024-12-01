namespace AdventOfCode2024.Test.Day2;

public class Day2Test
{
    AdventOfCode2024.Day2.Day2 _day2;

    [SetUp]
    public void SetUp()
    {
        _day2 = new();
    }

    #region Part1

    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day2.Part1(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart1_Actual()
    {
        _day2 = new AdventOfCode2024.Day2.Day2(true);
        Assert.That(_day2.Part1(), Is.EqualTo(0));
    }

    #endregion

    #region Part2

    [Test]
    public void ShouldDoPart2()
    {
        Assert.That(_day2.Part2(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart2_actual()
    {
        _day2 = new(true);
        Assert.That(_day2.Part2(), Is.EqualTo(0));
    }

    #endregion
}