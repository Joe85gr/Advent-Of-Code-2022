using Domain.Day9;
using FluentAssertions;

namespace UnitTests;

public class Day9Tests
{
    [Fact]
    public void Part1()
    {
        // Arrange
        var data = File.ReadAllLines(@"./TestData/Day9_Data_Part1.txt")
            .Select(l => l.Split(' ')).ToArray();
        const int expectedResult = 13;
        const int nodes = 2;

        // Act
        var result = Day9.RopeBridge(data, nodes);

        // Assess
        result.Should().Be(expectedResult);
    }

    [Fact]
    public void Part2()
    {
        // Arrange
        var data = File.ReadAllLines(@"./TestData/Day9_Data_Part2.txt")
            .Select(l => l.Split(' ')).ToArray();
        const int expectedResult = 36;
        const int nodes = 10;
        
        // Act
        var result = Day9.RopeBridge(data, nodes);

        // Assess
        result.Should().Be(expectedResult);

        // Assess
        result.Should().Be(expectedResult);
    }
}

