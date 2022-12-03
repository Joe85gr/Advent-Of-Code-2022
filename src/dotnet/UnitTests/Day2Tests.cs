using Domain.Day2;

namespace UnitTests;

public class Day2Tests
{
    private readonly string _data;

    public Day2Tests()
    {
        const string testDataFilePath = @"./TestData/Day2_Data.txt";
        _data = File.ReadAllText(testDataFilePath);
    }

    [Fact]
    public void GetTotalScore()
    {
        // Arrange
        var expectedResult = 15;

        // Act
        var result = Day2.GetTotalScore1(_data);

        // Assess
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void GetActualTotalScore()
    {
        // Arrange
        var expectedResult = 12;

        // Act
        var result = Day2.GetTotalScore2(_data);

        // Assess
        Assert.Equal(expectedResult, result);
    }
}