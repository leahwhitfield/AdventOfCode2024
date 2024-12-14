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
    public void ShouldLoadRegions()
    {
        var region = _day12.Regions[0];
        Assert.That(region.PlotPoints.Count, Is.EqualTo(12));
    }

    [Test]
    public void ShouldGetPerimeterAndArea()
    {
        var region = _day12.Regions[0];
        Assert.That(region.Area, Is.EqualTo(12));
        Assert.That(region.Perimeter, Is.EqualTo(18));

        region = _day12.Regions[1];
        Assert.That(region.Area, Is.EqualTo(4));
        Assert.That(region.Perimeter, Is.EqualTo(8));        
        
        region = _day12.Regions[2];
        Assert.That(region.Area, Is.EqualTo(14));
        Assert.That(region.Perimeter, Is.EqualTo(28));     
        
        region = _day12.Regions[3];
        Assert.That(region.Area, Is.EqualTo(10));
        Assert.That(region.Perimeter, Is.EqualTo(18));      
        
        region = _day12.Regions[4];
        Assert.That(region.Area, Is.EqualTo(13));
        Assert.That(region.Perimeter, Is.EqualTo(20));        
        
        region = _day12.Regions[5];
        Assert.That(region.Area, Is.EqualTo(11));
        Assert.That(region.Perimeter, Is.EqualTo(20));
        
        region = _day12.Regions[6];
        Assert.That(region.Area, Is.EqualTo(1));
        Assert.That(region.Perimeter, Is.EqualTo(4));
        
        region = _day12.Regions[7];
        Assert.That(region.Area, Is.EqualTo(13));
        Assert.That(region.Perimeter, Is.EqualTo(18));
        
        region = _day12.Regions[8];
        Assert.That(region.Area, Is.EqualTo(14));
        Assert.That(region.Perimeter, Is.EqualTo(22));
        
        region = _day12.Regions[9];
        Assert.That(region.Area, Is.EqualTo(5));
        Assert.That(region.Perimeter, Is.EqualTo(12));
        
        region = _day12.Regions[10];
        Assert.That(region.Area, Is.EqualTo(3));
        Assert.That(region.Perimeter, Is.EqualTo(8));
    }

    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day12.Part1(), Is.EqualTo(1930));
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