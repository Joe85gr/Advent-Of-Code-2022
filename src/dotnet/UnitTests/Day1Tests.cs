using Domain.Day1;
using FluentAssertions;

namespace UnitTests;

public class Day1Tests
{
    private readonly string[] _calories;

    public Day1Tests()
    {
        _calories = File.ReadAllText(@"./TestData/Day1_Data.txt")
            .Split("\n\n");
    }

    [Fact]
    public void GetsMaxCalories()
    {
        // Arrange
        const int expectedResult = 24000;

        // Act
        var result = Day1.GetsMaxCalories(_calories);

        // Assess
        result.Should().Be(expectedResult);
    }

    [Fact]
    public void GetsSumOfTopThree()
    {
        // Arrange
        const int expectedResult = 45000;

        // Act
        var result = Day1.GetsSumOfTopThree(_calories);

        // Assess
        result.Should().Be(expectedResult);
    }
}