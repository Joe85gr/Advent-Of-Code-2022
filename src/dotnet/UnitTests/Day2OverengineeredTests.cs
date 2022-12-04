using Domain.Day2.OverengineeredVersion;
using FluentAssertions;

namespace UnitTests;

public class Day2OverengineeredTests
{
    private readonly string[] _rounds;

    public Day2OverengineeredTests()
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
        var result = Day2Overengineered.GetTotalScore1(_rounds);

        // Assess
        result.Should().Be(expectedResult);    
    }

    [Fact]
    public void GetActualTotalScore()
    {
        // Arrange
        const int expectedResult = 12;

        // Act
        var result = Day2Overengineered.GetTotalScore2(_rounds);

        // Assess
        result.Should().Be(expectedResult);
    }
}