namespace AdventOfCode2024.Test.Day4;

public class Day4Test
{
    private AdventOfCode2024.Day4.Day4 _day4;

    [SetUp]
    public void SetUp()
    {
        _day4 = new();
    }

    #region Part1
    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day4.Part1(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart1_Actual()
    {
        _day4 = new(true);
        Assert.That(_day4.Part1(), Is.EqualTo(0));
    }

    #endregion

    #region Part2
    [Test]
    public void ShouldDoPart2()
    {
        Assert.That(_day4.Part2(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart2_actual()
    {
        _day4 = new(true);
        Assert.That(_day4.Part2(), Is.EqualTo(0));
    }

    #endregion
}