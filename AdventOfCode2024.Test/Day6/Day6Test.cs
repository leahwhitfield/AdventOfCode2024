using AdventOfCode2024.Day6;
using Path = AdventOfCode2024.Day6.Path;

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
    public void ShouldLoadData()
    {
        Assert.That(_day6.LabMap.Guard.Direction, Is.EqualTo(Direction.Up));
        Assert.That(_day6.LabMap.Guard.Position, Is.EqualTo(new Position(6, 4)));
        Assert.True(_day6.LabMap.Obstacles.Contains(new Position(0, 4)));
        Assert.That(_day6.LabMap.MapSize, Is.EqualTo((10, 10)));
    }

    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day6.Part1(), Is.EqualTo(41));
    }

    [Test]
    public void ShouldDoPart1_Actual()
    {
        _day6 = new(true);
        Assert.That(_day6.Part1(), Is.EqualTo(4826));
    }

    #endregion

    #region Part2
    [Test]
    public void ShouldBeEqualPaths()
    {
        var path1 = new Path(new Position(1, 1), Direction.Left);
        var path2 = new Path(new Position(1, 1), Direction.Left);
        Assert.True(path1.Equals(path2));
    }
    
    [Test]
    public void ShouldNotBeEqualPaths()
    {
        var path1 = new Path(new Position(1, 1), Direction.Left);
        var path2 = new Path(new Position(1, 1), Direction.Up);
        Assert.False(path1.Equals(path2));
        path1 = new Path(new Position(1, 2), Direction.Up);
        path2 = new Path(new Position(1, 5), Direction.Up);
        Assert.False(path1.Equals(path2));

        HashSet<Path> paths = [path1];
        Assert.False(paths.Contains(path2));
    }

    [Test]
    public void ShouldDoPart2()
    {
        Assert.That(_day6.Part2(), Is.EqualTo(6));
    }

    [Test]
    public void ShouldDoPart2_actual()
    {
        _day6 = new(true);
        Assert.That(_day6.Part2(), Is.EqualTo(1721));
    }

    #endregion
}