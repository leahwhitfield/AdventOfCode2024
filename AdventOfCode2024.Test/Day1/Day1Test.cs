using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Test.Day1;

using AdventOfCode2024.Day1;

public class Tests
{
    Day1 _day1;

    [SetUp]
    public void SetUp()
    {
        var input = Constants.BasePath + "day1_example.txt";
        _day1 = new Day1(input);
    }

    #region Part1
    [Test]
    public void ShouldDoPart1()
    {
        Assert.That(_day1.Part1(), Is.EqualTo(0));
    }
    
    #endregion

    #region Part2
    
   
    #endregion
}