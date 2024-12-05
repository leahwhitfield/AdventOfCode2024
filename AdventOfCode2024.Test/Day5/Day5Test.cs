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
    public void ShouldLoadData()
    {
        Assert.That(_day5.PageOrderingRules, Has.Count.EqualTo(21));
        Assert.That(_day5.Updates, Has.Count.EqualTo(6));
    }

    [Test]
    public void ShouldBeCorrectOrder()
    {
        Assert.True(_day5.IsInCorrectOrder([75, 47, 61, 53, 29]));
    }

    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day5.Part1(), Is.EqualTo(143));
    }

    [Test]
    public void ShouldDoPart1_Actual()
    {
        _day5 = new(true);
        Assert.That(_day5.Part1(), Is.EqualTo(6242));
    }

    #endregion

    #region Part2

    [Test]
    public void ShouldOrderUpdate()
    {
        Assert.That(_day5.OrderUpdate([75, 97, 47, 61, 53]), Is.EqualTo(new[] { 97, 75, 47, 61, 53 }));
        Assert.That(_day5.OrderUpdate([61, 13, 29]), Is.EqualTo(new[] { 61, 29, 13 }));
        Assert.That(_day5.OrderUpdate([97, 13, 75, 29, 47]), Is.EqualTo(new[] { 97, 75, 47, 29, 13 }));
    }

    [Test]
    public void ShouldDoPart2()
    {
        Assert.That(_day5.Part2(), Is.EqualTo(123));
    }

    [Test]
    public void ShouldDoPart2_actual()
    {
        _day5 = new(true);
        Assert.That(_day5.Part2(), Is.EqualTo(0));
    }

    #endregion
}