using Domain.Day1;

namespace UnitTests;

public class Day1Tests
{
    private readonly string _data;

    public Day1Tests()
    {
        const string testDataFilePath = @"./TestData/Day1_Data.txt";
        _data = File.ReadAllText(testDataFilePath);
    }

    [Fact]
    public void GetsMaxCalories()
    {
        // Arrange
        const int expectedResult = 24000;

        // Act
        var result = Day1.GetsMaxCalories(_data);

        // Assess
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void GetsSumOfTopThree()
    {
        // Arrange
        const int expectedResult = 45000;

        // Act
        var result = Day1.GetsSumOfTopThree(_data);

        // Assess
        Assert.Equal(expectedResult, result);
    }
}