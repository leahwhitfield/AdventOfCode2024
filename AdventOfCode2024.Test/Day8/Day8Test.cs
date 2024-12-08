namespace AdventOfCode2024.Test.Day8;

public class Day8Test
{
    private AdventOfCode2024.Day8.Day8 _day8;

    [SetUp]
    public void SetUp()
    {
        _day8 = new();
    }

    #region Part1
    [Test]
    public void ShouldLoadData()
    {
        Assert.That(_day8.Map.Antennae, Has.Count.EqualTo(7));
    } 
    
    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day8.Part1(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart1_Actual()
    {
        _day8 = new(true);
        Assert.That(_day8.Part1(), Is.EqualTo(0));
    }

    #endregion

    #region Part2
    [Test]
    public void ShouldDoPart2()
    {
        Assert.That(_day8.Part2(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart2_actual()
    {
        _day8 = new(true);
        Assert.That(_day8.Part2(), Is.EqualTo(0));
    }

    #endregion
}