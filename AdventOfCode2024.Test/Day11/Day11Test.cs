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
        int[] expected = [125,17];
        Assert.That(_day11.Stones, Is.EqualTo(expected));
    }        
    
    [Test]
    public void ShouldMoveStonesOnBlink()
    {
        _day11.Blink();
        _day11.Blink();
        int[] expected = [253, 0, 2024, 14168];
        Assert.That(_day11.Stones, Is.EqualTo(expected));
        
        _day11.Blink();
        expected = [512072, 1, 20, 24, 28676032];
        Assert.That(_day11.Stones, Is.EqualTo(expected));
        
        _day11.Blink();
        expected = [512, 72, 2024, 2, 0, 2, 4, 2867, 6032];
        Assert.That(_day11.Stones, Is.EqualTo(expected));        
        
        _day11.Blink();
        expected = [1036288, 7, 2, 20, 24, 4048, 1, 4048, 8096, 28, 67, 60, 32];
        Assert.That(_day11.Stones, Is.EqualTo(expected));        
        
        _day11.Blink();
        expected = [2097446912, 14168, 4048, 2, 0, 2, 4, 40, 48, 2024, 40, 48, 80, 96, 2, 8, 6, 7, 6, 0, 3, 2];
        Assert.That(_day11.Stones, Is.EqualTo(expected));
        Assert.That(_day11.Stones.Length, Is.EqualTo(22));
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
    public void ShouldDoPart2()
    {
        Assert.That(_day11.Part2(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart2_actual()
    {
        _day11 = new(true);
        Assert.That(_day11.Part2(), Is.EqualTo(0));
    }

    #endregion
}