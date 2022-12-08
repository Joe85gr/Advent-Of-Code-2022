using Domain.Day8;
using FluentAssertions;

namespace UnitTests;

public class Day8Tests
{
    private readonly int[][] _treeMatrix;

    public Day8Tests()
    {
        _treeMatrix = File.ReadAllLines(@"./TestData/Day8_Data.txt")
            .Select(line => line.Select(digit => int.Parse(digit.ToString())).ToArray())
            .ToArray();
    }
    
    [Fact]
    public void GetVisibleTrees()
    {
        // Arrange
        const int expectedResult = 21;
        
        // Act
        var result = Day8.GetVisibleTrees(_treeMatrix);

        // Assess
        result.Should().Be(expectedResult);
    }

    [Fact]
    public void GetMaxScenicScore()
    {
        // Arrange
        const int expectedResult = 8;
        
        // Act
        var result = Day8.GetMaxScenicScore(_treeMatrix);
        
        // Assess
        result.Should().Be(expectedResult);
    }


}