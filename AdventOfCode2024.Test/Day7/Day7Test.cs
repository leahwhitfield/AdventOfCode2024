using AdventOfCode2024.Day7;

namespace AdventOfCode2024.Test.Day7;

public class Day7Test
{
    private AdventOfCode2024.Day7.Day7 _day7;

    [SetUp]
    public void SetUp()
    {
        _day7 = new();
    }

    #region Part1

    [Test]
    public void ShouldLoadData()
    {
        Assert.That(_day7._calibrationEquations, Has.Count.EqualTo(9));
        Assert.That(_day7._calibrationEquations[1].TestValue, Is.EqualTo(3267));
        Assert.That(_day7._calibrationEquations[2].Numbers[1], Is.EqualTo(5));
    }

    [Test]
    public void ShouldReturnTrue()
    {
        Assert.True(new CalibrationEquation(100, [50,40,10]).IsPossiblyTrue());
        Assert.True(new CalibrationEquation(190, [10,19]).IsPossiblyTrue());
        Assert.True(new CalibrationEquation(3267, [81,40,27]).IsPossiblyTrue());
        Assert.True(new CalibrationEquation(292, [11,6,16,20]).IsPossiblyTrue());
    }

    [Test]
    public void ShouldReturnFalse()
    {
        Assert.False(new CalibrationEquation(83, [17, 5]).IsPossiblyTrue());
        Assert.False(new CalibrationEquation(156, [15, 6]).IsPossiblyTrue());
        Assert.False(new CalibrationEquation(7290, [6, 8, 6, 15]).IsPossiblyTrue());
        Assert.False(new CalibrationEquation(161011, [16, 10, 13]).IsPossiblyTrue());
        Assert.False(new CalibrationEquation(192, [17, 8, 14]).IsPossiblyTrue());
        Assert.False(new CalibrationEquation(21037, [9, 7, 18, 13]).IsPossiblyTrue());
        Assert.False(new CalibrationEquation(25056746772, [4, 47, 136, 21, 79, 49]).IsPossiblyTrue());
        Assert.False(new CalibrationEquation(1387, [33, 502, 69, 775, 5]).IsPossiblyTrue());
    }

    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day7.Part1(), Is.EqualTo(3749));
    }

    [Test]
    public void ShouldDoPart1_Actual()
    {
        _day7 = new(true);
        Assert.That(_day7.Part1(), Is.EqualTo(975671981569));
    }

    #endregion

    #region Part2

    [Test]
    public void ShouldDoPart2()
    {
        Assert.That(_day7.Part2(), Is.EqualTo(0));
    }

    [Test]
    public void ShouldDoPart2_actual()
    {
        _day7 = new(true);
        Assert.That(_day7.Part2(), Is.EqualTo(0));
    }

    #endregion
}