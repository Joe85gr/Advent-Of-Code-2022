using Domain.Day7;
using FluentAssertions;

namespace UnitTests;

public class Day7Tests
{
    private readonly string[] _log;

    public Day7Tests()
    {
        _log = File.ReadAllLines(@"./TestData/Day7_Data.txt");
    }

    [Fact]
    public void Part1()
    {
        // Arrange
        const int expectedResult = 95437;
        
        // Act
        var result = Day7.Part1(_log);

        // Assess
        result.Should().Be(expectedResult);
    }
    
    [Fact]
    public void Part2()
    {
        // Arrange
        const int expectedResult = 24933642;

        // Act
        var result = Day7.Part2(_log);
        
        // Assess
        result.Should().Be(expectedResult);
    }
}