namespace AdventOfCode2024.Test.Day7;

public class Day7Test
{
    private AdventOfCode2024.Day7.Day7 _day7;

    [SetUp]
    public void SetUp()
    {
        _day7 = new();
    }

    #region Part1
    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day7.Part1(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart1_Actual()
    {
        _day7 = new(true);
        Assert.That(_day7.Part1(), Is.EqualTo(0));
    }

    #endregion

    #region Part2
    [Test]
    public void ShouldDoPart2()
    {
        Assert.That(_day7.Part2(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart2_actual()
    {
        _day7 = new(true);
        Assert.That(_day7.Part2(), Is.EqualTo(0));
    }

    #endregion
}