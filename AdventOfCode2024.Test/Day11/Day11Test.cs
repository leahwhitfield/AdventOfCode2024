namespace AdventOfCode2024.Test.Day11;

public class Day11Test
{
    private AdventOfCode2024.Day11.Day11 _day11;

    [SetUp]
    public void SetUp()
    {
        _day11 = new();
    }

    #region Part1
    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day11.Part1(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart1_Actual()
    {
        _day11 = new(true);
        Assert.That(_day11.Part1(), Is.EqualTo(0));
    }

    #endregion

    #region Part2
    [Test]
    public void ShouldDoPart2()
    {
        Assert.That(_day11.Part2(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart2_actual()
    {
        _day11 = new(true);
        Assert.That(_day11.Part2(), Is.EqualTo(0));
    }

    #endregion
}