using System.Collections;
using Domain.Day2;
using Domain.Day3;
using Domain.Day4;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace UnitTests;

public class Day4Tests
{
    private readonly string _data;

    public Day4Tests()
    {
        const string testDataFilePath = @"./TestData/Day4_Data.txt";
        _data = File.ReadAllText(testDataFilePath);
    }

    [Fact]
    public void GetTotallyOverlappedOnly()
    {
        // Arrange
        const int expectedResult = 2;

        // Act
        var result = Day4.GetTotallyOverlappedOnly(_data);
        
        // Assess
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void GetAllOverlapped()
    {
        // Arrange
        const int expectedResult = 4;

        // Act
        var result = Day4.GetAllOverlapped(_data);
        
        // Assess
        Assert.Equal(expectedResult, result);
    }

    private static IEnumerable<int> GetRange(int first, int second)
    {
        for (var i = first; i <= second; i++)
        {
            yield return i;
        }
    }
}
