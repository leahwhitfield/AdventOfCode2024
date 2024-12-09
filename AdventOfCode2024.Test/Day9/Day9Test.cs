using AdventOfCode2024.Day9;

namespace AdventOfCode2024.Test.Day9;

public class Day9Test
{
    private AdventOfCode2024.Day9.Day9 _day9;

    [SetUp]
    public void SetUp()
    {
        _day9 = new();
    }

    #region Part1

    [Test]
    public void ShouldLoadData()
    {
        Assert.That(_day9.DiskMap.DiskSpaces[^1].Size, Is.EqualTo(2));
        Assert.That(_day9.DiskMap.DiskSpaces, Has.Count.EqualTo(18));
        Assert.That(_day9.DiskMap.DiskSpaces[0].Size, Is.EqualTo(2));
        Assert.That(_day9.DiskMap.DiskSpaces[3].Size, Is.EqualTo(3));
        Assert.That(_day9.DiskMap.DiskSpaces[6].Size, Is.EqualTo(3));
    }

    [Test]
    public void ShouldGenerateDiskMap()
    {
        Assert.That(_day9.DiskMap.GetCurrentDiskMap(), Is.EqualTo("00...111...2...333.44.5555.6666.777.888899"));
    }

    [Test]
    public void ShouldDetectGap()
    {
        Assert.That(_day9.DiskMap.FindGap("00...111"), Is.EqualTo(2));
        Assert.That(_day9.DiskMap.FindGap("00...111...2...333.44.5555.6666.777.888899"), Is.EqualTo(2));
        Assert.That(_day9.DiskMap.FindGap("0099811188827..333.44.5555.6666.77........"), Is.EqualTo(13));
        Assert.That(_day9.DiskMap.FindGap("0099811188827773336446555566.............."), Is.EqualTo(0));
    }

    [Test]
    public void ShouldMoveBlockToGap()
    {
        Assert.That(_day9.DiskMap.MoveDataBlockToGap("00...111...2...333.44.5555.6666.777.888899"),
            Is.EqualTo("009..111...2...333.44.5555.6666.777.88889."));
        Assert.That(_day9.DiskMap.MoveDataBlockToGap("0099811188827..333.44.5555.6666.77........"),
            Is.EqualTo("00998111888277.333.44.5555.6666.7........."));
    }
    
    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day9.Part1(), Is.EqualTo(1928));
    }

    [Test]
    public void ShouldDoPart1_Actual()
    {
        _day9 = new(true);
        Assert.That(_day9.Part1(), Is.EqualTo(0));
    }

    #endregion

    #region Part2

    [Test]
    public void ShouldDoPart2()
    {
        Assert.That(_day9.Part2(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart2_actual()
    {
        _day9 = new(true);
        Assert.That(_day9.Part2(), Is.EqualTo(0));
    }

    #endregion
}