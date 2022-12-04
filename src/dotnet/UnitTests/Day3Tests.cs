using Domain.Day2;
using Domain.Day3;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace UnitTests;

public class Day3Tests
{
    private readonly string[] _rucksacks;

    public Day3Tests()
    {
        var data = File.ReadAllText(@"./TestData/Day3_Data.txt");
        _rucksacks = data.Split("\n");
    }

    [Fact]
    public void GetPriority()
    {
        // Arrange
        const int expectedResult = 157;

        // Act
        var result = Day3.GetTotalRucksacksPriority(_rucksacks);

        // Assess
        result.Should().Be(expectedResult);
    }

    [Fact]
    public void GetPriority2()
    {
        // Arrange
        const int expectedResult = 70;

        // Act
        var result = Day3.GetTotalGroupsPriority(_rucksacks);

        // Assess
        result.Should().Be(expectedResult);
    }
}