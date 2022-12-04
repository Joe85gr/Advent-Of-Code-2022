using Domain.Day4;
using FluentAssertions;

namespace UnitTests;

public class Day4Tests
{
    private readonly IEnumerable<ElfPair> _elvesPairs;

    public Day4Tests()
    {
        var data = File.ReadAllText(@"./TestData/Day4_Data.txt");
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
        result.Should().Be(expectedResult);
    }

    [Fact]
    public void GetAllOverlapped()
    {
        // Arrange
        const int expectedResult = 4;

        // Act
        var result = _elvesPairs.Select(Day4.CountIfOverlapped).Sum();
        
        // Assess
        result.Should().Be(expectedResult);
    }
}
