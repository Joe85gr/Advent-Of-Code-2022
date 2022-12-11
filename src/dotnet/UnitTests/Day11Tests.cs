using Domain;
using Domain.Day11;
using FluentAssertions;

namespace UnitTests;

public class Day11Tests
{
    private readonly Monkey[] _monkeys;

    public Day11Tests()
    {
        _monkeys = File.ReadAllText(@"./TestData/Day11_Data.txt")
            .Split("\n\n").Select(m => new Monkey(m)).ToArray();
    }

    [Fact]
    public void Part1()
    {
        // Arrange
        const int expectedResult = 10605;
    
        // Act
        var result = Day11.Part1(_monkeys, ChallengePart.One);

        // Assess
        result.Should().Be(expectedResult);
    }

    [Fact]
    public void Part2()
    {
        const double expectedResult = 2713310158;
        
        // calculated using https://www.calculatorsoup.com/calculators/math/lcm.php with the Test values
        const int leastCommonMultiple = 96577; 
        
        // Act
        var result = Day11.Part1(_monkeys, ChallengePart.Two, leastCommonMultiple);

        // Assess
        result.Should().Be(expectedResult);
    }
}