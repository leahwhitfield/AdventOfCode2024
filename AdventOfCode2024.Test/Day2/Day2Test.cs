using AdventOfCode2024.Day2;

namespace AdventOfCode2024.Test.Day2;

public class Day2Test
{
    AdventOfCode2024.Day2.Day2 _day2;

    [SetUp]
    public void SetUp()
    {
        _day2 = new();
    }

    #region Part1

    [Test]
    public void ShouldLoadReports()
    {
        _day2.LoadReports();
        Assert.That(_day2.Reports, Has.Count.EqualTo(6));
        Assert.That(_day2.Reports[2].Levels[3], Is.EqualTo(2));
    }

    [Test]
    public void ShouldBeTrueIfAllIncreasing()
    {
        var report = new Report([1, 2, 3, 4]);
        Assert.True(report.IsSafe());
    }

    [Test]
    public void ShouldBeTrueIfAllDecreasing()
    {
        var report = new Report([4,3,2,1]);
        Assert.True(report.IsSafe());
    }

    [Test]
    public void ShouldBeFalseIfDifferenceLessThan1()
    {
        var report = new Report([4,4,2,1]);
        Assert.False(report.IsSafe());
    }

    [Test]
    public void ShouldBeFalseIfDifferenceMoreThan3()
    {
        var report = new Report([1,2,7,8,9]);
        Assert.False(report.IsSafe());
    }

    [Test]
    public void ShouldBeUnsafe()
    {
        Assert.False(new Report([9,7,6,2,1]).IsSafe());
        Assert.False(new Report([1,3,2,4,5]).IsSafe());
        Assert.False(new Report([8,6,4,4,1]).IsSafe());
    }

    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day2.Part1(), Is.EqualTo(2));
    }

    [Test]
    public void ShouldDoPart1_Actual()
    {
        _day2 = new AdventOfCode2024.Day2.Day2(true);
        Assert.That(_day2.Part1(), Is.EqualTo(230));
    }

    #endregion

    #region Part2

    [Test]
    public void ShouldDoPart2()
    {
        Assert.That(_day2.Part2(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart2_actual()
    {
        _day2 = new(true);
        Assert.That(_day2.Part2(), Is.EqualTo(0));
    }

    #endregion
}