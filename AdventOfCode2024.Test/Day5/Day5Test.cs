namespace AdventOfCode2024.Test.Day5;

public class Day5Test
{
    private AdventOfCode2024.Day5.Day5 _day5;

    [SetUp]
    public void SetUp()
    {
        _day5 = new();
    }

    #region Part1
    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day5.Part1(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart1_Actual()
    {
        _day5 = new(true);
        Assert.That(_day5.Part1(), Is.EqualTo(0));
    }

    #endregion

    #region Part2
    [Test]
    public void ShouldDoPart2()
    {
        Assert.That(_day5.Part2(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart2_actual()
    {
        _day5 = new(true);
        Assert.That(_day5.Part2(), Is.EqualTo(0));
    }

    #endregion
}