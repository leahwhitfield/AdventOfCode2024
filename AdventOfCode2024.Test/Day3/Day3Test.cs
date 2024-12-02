namespace AdventOfCode2024.Test.Day3;

public class Day3Test
{
    private AdventOfCode2024.Day3.Day3 _day3;

    [SetUp]
    public void SetUp()
    {
        _day3 = new();
    }

    #region Part1
    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day3.Part1(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart1_Actual()
    {
        _day3 = new(true);
        Assert.That(_day3.Part1(), Is.EqualTo(0));
    }

    #endregion

    #region Part2
    [Test]
    public void ShouldDoPart2()
    {
        Assert.That(_day3.Part2(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart2_actual()
    {
        _day3 = new(true);
        Assert.That(_day3.Part2(), Is.EqualTo(0));
    }

    #endregion
}