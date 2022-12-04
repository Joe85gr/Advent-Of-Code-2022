using Domain.Day4;

namespace UnitTests;

public class Day4Tests
{
    private readonly IEnumerable<ElfPair> _elvesPairs;

    public Day4Tests()
    {
        const string testDataFilePath = @"./TestData/Day4_Data.txt";
        var data = File.ReadAllText(testDataFilePath);
        _elvesPairs = new Elves(data).Pairs;
    }

    [Fact]
    public void GetTotallyOverlappedOnly()
    {
        // Arrange
        const int expectedResult = 2;

        // Act
        var result = _elvesPairs.Select(Day4.CountIfTotallyOverlapped).Sum();
        
        // Assess
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void GetAllOverlapped()
    {
        // Arrange
        const int expectedResult = 4;

        // Act
        var result = _elvesPairs.Select(Day4.CountIfOverlapped).Sum();
        
        // Assess
        Assert.Equal(expectedResult, result);
    }
}
