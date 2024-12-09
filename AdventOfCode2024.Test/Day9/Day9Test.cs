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
    public void ShouldGenerateDiskMap()
    {
        List<int> expected =
        [
            0, 0, -1, -1, -1, 1, 1, 1, -1, -1, -1, 2, -1, -1, -1, 3, 3, 3, -1, 4, 4, -1, 5, 5, 5, 5, -1, 6, 6, 6, 6,
            -1, 7, 7, 7, -1, 8, 8, 8, 8, 9, 9
        ];
        Assert.That(_day9.DiskMap.Map, Is.EqualTo(expected));
    }

    [Test]
    public void ShouldDetectGap()
    {
        Assert.That(_day9.DiskMap.FindGap([0, 0, -1, -1, -1, 1, 1, 1]), Is.EqualTo(2));
    }

    [Test]
    public void ShouldMoveBlockToGap()
    {
        List<int> expected =
        [
            0, 0, 9, -1, -1, 1, 1, 1, -1, -1, -1, 2, -1, -1, -1, 3, 3, 3, -1, 4, 4, -1, 5, 5, 5, 5, -1, 6, 6, 6, 6, 6,
            -1, 7, 7, 7, -1, 8, 8, 8, 8, 9, -1
        ];
        Assert.That(
            _day9.DiskMap.MoveDataBlockToGap([
                0, 0, -1, -1, -1, 1, 1, 1, -1, -1, -1, 2, -1, -1, -1, 3, 3, 3, -1, 4, 4, -1, 5, 5, 5, 5, -1, 6, 6, 6, 6,
                6, -1, 7, 7, 7, -1, 8, 8, 8, 8, 9, 9
            ]),
            Is.EqualTo(expected));
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
        Assert.That(_day9.Part1(), Is.EqualTo(6283404590840));
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