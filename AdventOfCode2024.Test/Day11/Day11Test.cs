namespace AdventOfCode2024.Test.Day11;

public class Day11Test
{
    private AdventOfCode2024.Day11.Day11 _day11;

    [SetUp]
    public void SetUp()
    {
        _day11 = new();
    }

    #region Part1

    [Test]
    public void ShouldLoadData()
    {
        int[] expected = [125, 17];
        Assert.That(_day11.Stones, Is.EqualTo(expected));
    }

    [Test]
    public void ShouldGetStoneCount()
    {
        Assert.That(_day11.FindNumberOfDescendantsOfStone(253, 1), Is.EqualTo(0));
        Assert.That(_day11.FindNumberOfDescendantsOfStone(2024, 1), Is.EqualTo(1));
        Assert.That(_day11.FindNumberOfDescendantsOfStone(125, 2), Is.EqualTo(1));
        Assert.That(_day11.FindNumberOfDescendantsOfStone(125, 3), Is.EqualTo(1));
        Assert.That(_day11.FindNumberOfDescendantsOfStone(125, 4), Is.EqualTo(2));
        Assert.That(_day11.FindNumberOfDescendantsOfStone(125, 5), Is.EqualTo(4));
        Assert.That(_day11.FindNumberOfDescendantsOfStone(125, 6), Is.EqualTo(6));
    }


    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day11.Part1(), Is.EqualTo(55312));
    }

    [Test]
    public void ShouldDoPart1_Actual()
    {
        _day11 = new(true);
        Assert.That(_day11.Part1(), Is.EqualTo(194782));
    }

    #endregion

    #region Part2

    [Test]
    public void ShouldDoPart2_actual()
    {
        _day11 = new(true);
        Assert.That(_day11.Part2(), Is.EqualTo(233007586663131));
    }

    #endregion
}