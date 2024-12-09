namespace AdventOfCode2024.Test.Day10;

public class Day10Test
{
    private AdventOfCode2024.Day10.Day10 _day10;

    [SetUp]
    public void SetUp()
    {
        _day10 = new();
    }

    #region Part1
    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day10.Part1(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart1_Actual()
    {
        _day10 = new(true);
        Assert.That(_day10.Part1(), Is.EqualTo(0));
    }

    #endregion

    #region Part2
    [Test]
    public void ShouldDoPart2()
    {
        Assert.That(_day10.Part2(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart2_actual()
    {
        _day10 = new(true);
        Assert.That(_day10.Part2(), Is.EqualTo(0));
    }

    #endregion
}