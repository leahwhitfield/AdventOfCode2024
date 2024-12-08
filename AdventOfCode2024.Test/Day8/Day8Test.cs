using AdventOfCode2024.Day6;
using AdventOfCode2024.Day8;

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
        Assert.That(_day8.Map.Antennae[1], Is.EqualTo(new Antenna('0', new Position(2, 5))));
        Assert.That(_day8.Map.Antennae[3], Is.EqualTo(new Antenna('0', new Position(4, 4))));
    }

    [Test]
    public void ShouldBeEqual()
    {
        var antenna1 = new Antenna('1', new Position(1, 1));
        var antenna2 = new Antenna('1', new Position(1, 1));
        Assert.That(antenna1, Is.EqualTo(antenna2));
    }

    [Test]
    public void ShouldGetAntennaPositions()
    {
        var antenna1 =  new Position(2, 5);
        var antenna2 = new Position(4, 4);
        var calculateAntinodePositions = _day8.Map.CalculateAntinodePositions(antenna1, antenna2);

        Assert.That(calculateAntinodePositions[0], Is.EqualTo(new Position(0, 6)));
        Assert.That(calculateAntinodePositions[1], Is.EqualTo(new Position(6, 3)));

        antenna1 = new Position(3, 4);
        antenna2 = new Position(5, 5);
        calculateAntinodePositions = _day8.Map.CalculateAntinodePositions(antenna1, antenna2);

        Assert.That(calculateAntinodePositions[0], Is.EqualTo(new Position(1, 3)));
        Assert.That(calculateAntinodePositions[1], Is.EqualTo(new Position(7, 6)));
    }

    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day8.Part1(), Is.EqualTo(14));
    }

    [Test]
    public void ShouldDoPart1_Actual()
    {
        _day8 = new(true);
        Assert.That(_day8.Part1(), Is.EqualTo(313));
    }

    #endregion

    #region Part2
    [Test]
    public void ShouldDoPart2()
    {
        Assert.That(_day8.Part2(), Is.EqualTo(34));
    }

    [Test]
    public void ShouldDoPart2_actual()
    {
        _day8 = new(true);
        Assert.That(_day8.Part2(), Is.EqualTo(1064));
    }

    #endregion
}