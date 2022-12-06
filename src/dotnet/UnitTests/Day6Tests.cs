using Domain;
using Domain.Day6;
using FluentAssertions;

namespace UnitTests;

public class Day6Tests
{
    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void Part1(string buffer, int expectedResult)
    {
        // Act
        var result = Day6.FindFirstUniqueOccurrence(buffer, ChallengePart.One);
        
        // Assess
        result.Should().Be(expectedResult);
    }
    
    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void Part2(string buffer, int expectedResult)
    {
        // Act
        var result = Day6.FindFirstUniqueOccurrence(buffer, ChallengePart.Two);
        
        // Assess
        result.Should().Be(expectedResult);
    }
}