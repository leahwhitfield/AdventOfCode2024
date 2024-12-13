namespace AdventOfCode2024.Test.Day12;

public class Day12Test
{
    private AdventOfCode2024.Day12.Day12 _day12;

    [SetUp]
    public void SetUp()
    {
        _day12 = new();
    }

    #region Part1
    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day12.Part1(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart1_Actual()
    {
        _day12 = new(true);
        Assert.That(_day12.Part1(), Is.EqualTo(0));
    }

    #endregion

    #region Part2

    [Test]
    public void ShouldDoPart2_actual()
    {
        _day12 = new(true);
        Assert.That(_day12.Part2(), Is.EqualTo(0));
    }

    #endregion
}