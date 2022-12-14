using Domain.Day2;
using FluentAssertions;

namespace UnitTests;

public class Day2Tests
{
    private readonly string[] _rounds;

    public Day2Tests()
    {
        _rounds = File.ReadAllText(@"./TestData/Day2_Data.txt")
            .Split("\n");
    }

    [Fact]
    public void GetAssumedTotalScore()
    {
        // Arrange
        const int expectedResult = 15;

        // Act
        var result = Day2.GetAssumedTotalScore(_rounds);

        // Assess
        result.Should().Be(expectedResult);    
    }

    [Fact]
    public void GetActualTotalScore()
    {
        // Arrange
        const int expectedResult = 12;

        // Act
        var result = Day2.GetActualTotalScore(_rounds);

        // Assess
        result.Should().Be(expectedResult);
    }
}