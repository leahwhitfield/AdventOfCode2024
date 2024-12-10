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
    public void ShouldLoadData()
    {
        Assert.That(_day10.Map[1][1], Is.EqualTo(8));
    }
        
    [Test]
    public void ShouldGetStartingPositions()
    {
        Assert.That(_day10.GetStartingPositions()[0], Is.EqualTo((0, 2)));
        Assert.That(_day10.GetStartingPositions()[2], Is.EqualTo((2, 4)));
    }
    
    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day10.Part1(), Is.EqualTo(36));
    }

    [Test]
    public void ShouldDoPart1_Actual()
    {
        _day10 = new(true);
        Assert.That(_day10.Part1(), Is.EqualTo(557));
    }

    #endregion

    #region Part2
    [Test]
    public void ShouldDoPart2()
    {
        Assert.That(_day10.Part2(), Is.EqualTo(81));
    }

    [Test]
    public void ShouldDoPart2_actual()
    {
        _day10 = new(true);
        Assert.That(_day10.Part2(), Is.EqualTo(1062));
    }

    #endregion
}