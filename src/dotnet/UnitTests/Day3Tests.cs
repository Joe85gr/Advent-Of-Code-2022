using Domain.Day2;
using Domain.Day3;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace UnitTests;

public class Day3Tests
{
    private readonly string _data;

    public Day3Tests()
    {
        const string testDataFilePath = @"./TestData/Day3_Data.txt";
        _data = File.ReadAllText(testDataFilePath);
    }

    [Fact]
    public void GetPriority()
    {
        // Arrange
        const int expectedResult = 157;

        // Act
        var result = Day3.GetTotalRucksacksPriority(_data);

        // Assess
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void GetPriority2()
    {
        // Arrange
        const int expectedResult = 70;

        // Act
        var result = Day3.GetTotalGroupsPriority(_data);

        // Assess
        Assert.Equal(expectedResult, result);
    }
}