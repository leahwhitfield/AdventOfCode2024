namespace AdventOfCode2024.Test.Day6;

public class Day6Test
{
    private AdventOfCode2024.Day6.Day6 _day6;

    [SetUp]
    public void SetUp()
    {
        _day6 = new();
    }

    #region Part1
    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day6.Part1(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart1_Actual()
    {
        _day6 = new(true);
        Assert.That(_day6.Part1(), Is.EqualTo(0));
    }

    #endregion

    #region Part2
    [Test]
    public void ShouldDoPart2()
    {
        Assert.That(_day6.Part2(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart2_actual()
    {
        _day6 = new(true);
        Assert.That(_day6.Part2(), Is.EqualTo(0));
    }

    #endregion
}