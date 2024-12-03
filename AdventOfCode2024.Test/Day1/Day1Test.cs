namespace AdventOfCode2024.Test.Day1;

public class Day1Test
{
    AdventOfCode2024.Day1.Day1 _day1;

    [SetUp]
    public void SetUp()
    {
        _day1 = new AdventOfCode2024.Day1.Day1();
    }

    #region Part1
    [Test]
    public void ShouldReadArrays()
    {
        var firstList = _day1.FirstList;
        var secondList = _day1.SecondList;
        
        Assert.Multiple(() =>
        {
            Assert.That(firstList, Has.Count.EqualTo(6));
            Assert.That(secondList, Has.Count.EqualTo(6));
        });
    }    
    
    [Test]
    public void ShouldSortArrays()
    {
        var firstList = _day1.FirstList;
        var secondList = _day1.SecondList;

        Assert.Multiple(() =>
        {
            Assert.That(firstList[0], Is.EqualTo(1));
            Assert.That(firstList[1], Is.EqualTo(2));
            Assert.That(firstList[5], Is.EqualTo(4));            
            Assert.That(secondList[0], Is.EqualTo(3));
            Assert.That(secondList[1], Is.EqualTo(3));
            Assert.That(secondList[5], Is.EqualTo(9));
        });

    }
    
    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day1.Part1(), Is.EqualTo(11));
    }
    
    [Test] public void ShouldSumAllDistancesForPuzzleInput()
    {
        _day1 = new AdventOfCode2024.Day1.Day1(true);
        Assert.That(_day1.Part1(), Is.EqualTo(1388114));
    }
    
    #endregion

    #region Part2
    
    [Test]
    public void ShouldDoPart2()
    {
        Assert.That(_day1.Part2(), Is.EqualTo(31));
    }
    
    [Test]
    public void ShouldDoPart2_actual()
    {
        _day1 = new AdventOfCode2024.Day1.Day1(true);
        Assert.That(_day1.Part2(), Is.EqualTo(23529853));
    }

    #endregion
}