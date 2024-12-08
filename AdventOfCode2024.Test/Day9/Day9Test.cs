namespace AdventOfCode2024.Test.Day9;

public class Day9Test
{
    private AdventOfCode2024.Day9.Day9 _day9;

    [SetUp]
    public void SetUp()
    {
        _day9 = new();
    }

    #region Part1
    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day9.Part1(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart1_Actual()
    {
        _day9 = new(true);
        Assert.That(_day9.Part1(), Is.EqualTo(0));
    }

    #endregion

    #region Part2
    [Test]
    public void ShouldDoPart2()
    {
        Assert.That(_day9.Part2(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart2_actual()
    {
        _day9 = new(true);
        Assert.That(_day9.Part2(), Is.EqualTo(0));
    }

    #endregion
}