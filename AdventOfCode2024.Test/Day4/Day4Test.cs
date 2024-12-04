namespace AdventOfCode2024.Test.Day4;

public class Day4Test
{
    private AdventOfCode2024.Day4.Day4 _day4;

    [SetUp]
    public void SetUp()
    {
        _day4 = new();
    }

    #region Part1

    [Test]
    public void ShouldSetCharArray()
    {
        Assert.That(_day4.Wordsearch[0][0], Is.EqualTo('M'));
        Assert.That(_day4.Wordsearch[9][8], Is.EqualTo('S'));
    }

    [Test]
    public void ShouldFindHorizontalXmas()
    {
        var wordsearch = new[] { new[] { 'M', 'X', 'M', 'A', 'S', 'T' } };
        var count = _day4.WordCount("XMAS", wordsearch);
        Assert.That(count, Is.EqualTo(1));
    }

    [Test]
    public void ShouldFindReverseHorizontalXmas()
    {
        var wordsearch = new[] { new[] { 'M', 'S', 'A', 'M', 'X', 'T' } };
        var count = _day4.WordCount("XMAS", wordsearch);
        Assert.That(count, Is.EqualTo(1));
    }

    [Test]
    public void ShouldFindVerticalXmas()
    {
        char[][] wordsearch = [['X'], ['M'], ['A'], ['S']];

        var count = _day4.WordCount("XMAS", wordsearch);
        Assert.That(count, Is.EqualTo(1));
    }

    [Test]
    public void ShouldFindReverseVerticalXmas()
    {
        char[][] wordsearch =
        [
            ['S'],
            ['A'],
            ['M'],
            ['X']
        ];

        var count = _day4.WordCount("XMAS", wordsearch);
        Assert.That(count, Is.EqualTo(1));
    }

    [Test]
    public void ShouldNotFindIncompleteReverseVerticalXmas()
    {
        char[][] wordsearch =
        [
            ['X'],
            ['A'],
            ['M'],
            ['X']
        ];

        var count = _day4.WordCount("XMAS", wordsearch);
        Assert.That(count, Is.EqualTo(0));
    }

    [Test]
    public void ShouldFindDownRightDiagonalXmas()
    {
        char[][] wordsearch =
        [
            ['X'],
            ['Q', 'M'],
            ['Q', 'Q', 'A'],
            ['Q', 'Q', 'Q', 'S']
        ];

        var count = _day4.WordCount("XMAS", wordsearch);
        Assert.That(count, Is.EqualTo(1));
    }

    [Test]
    public void ShouldFindDownLeftDiagonalXmas()
    {
        char[][] wordsearch =
        [
            ['Q', 'Q', 'Q', 'X'],
            ['Q', 'Q', 'M', 'S'],
            ['Q', 'A', 'Q', 'S'],
            ['S', 'Q', 'Q', 'S']
        ];

        var count = _day4.WordCount("XMAS", wordsearch);
        Assert.That(count, Is.EqualTo(1));
    }

    [Test]
    public void ShouldFindUpRightDiagonalXmas()
    {
        char[][] wordsearch =
        [
            ['Q', 'Q', 'Q', 'S'],
            ['Q', 'Q', 'A', 'S'],
            ['Q', 'M', 'Q', 'S'],
            ['X', 'Q', 'Q', 'S']
        ];

        var count = _day4.WordCount("XMAS", wordsearch);
        Assert.That(count, Is.EqualTo(1));
    }

    [Test]
    public void ShouldFindUpLeftDiagonalXmas()
    {
        char[][] wordsearch =
        [
            ['S'],
            ['Q', 'A'],
            ['Q', 'Q', 'M'],
            ['Q', 'Q', 'Q', 'X']
        ];

        var count = _day4.WordCount("XMAS", wordsearch);
        Assert.That(count, Is.EqualTo(1));
    }

    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day4.Part1(), Is.EqualTo(18));
    }

    [Test]
    public void ShouldDoPart1_Actual()
    {
        _day4 = new(true);
        Assert.That(_day4.Part1(), Is.EqualTo(0));
    }

    #endregion

    #region Part2

    [Test]
    public void ShouldDoPart2()
    {
        Assert.That(_day4.Part2(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart2_actual()
    {
        _day4 = new(true);
        Assert.That(_day4.Part2(), Is.EqualTo(0));
    }

    #endregion
}