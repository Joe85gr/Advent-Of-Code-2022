using Domain.Day5;
using FluentAssertions;

namespace UnitTests;

public class Day5Tests
{
    private readonly string[] _data;

    public Day5Tests()
    {
        _data = File.ReadAllText(@"./TestData/Day5_Data.txt").Split("\n\n");
    }

    [Fact]
    public void Part1()
    {
        // Arrange
        const string expectedResult = "CMZ";
        
        // Act
        var result = Day5.Part1(_data);

        // Assess
        result.Should().Be(expectedResult);
    }
    
    [Fact]
    public void Part2()
    {
        // Arrange
        const string expectedResult = "MCD";
    
        // Act
        var result = Day5.Part2(_data);
    
        // Assess
        result.Should().Be(expectedResult);
    }
}