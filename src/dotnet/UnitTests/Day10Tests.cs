using FluentAssertions;
using Xunit.Abstractions;

namespace UnitTests;

public class Day10Tests
{
    private readonly string[][] _data;


    public Day10Tests(ITestOutputHelper testOutputHelper)
    {
        _data = File.ReadAllLines(@"./TestData/Day10_Data.txt")
            .Select(l => l.Split(' ')).ToArray();
    }

    [Fact]
    public void Part1()
    {
        // Arrange
        const int expectedResult = 13140;

        // Act
        var cycle = 1;
        var signalStrenghts = new List<int>();
        var signalStrenght = 1;
        
        var signalCycle = 20;

        for (var i = 0; i < _data.Length; i++)
        {
            if (_data[i][0] == "noop")
            {
                cycle++;
            }

            if (_data[i][0] == "addx")
            {
                cycle++;

                if (cycle == signalCycle)
                {
                    signalStrenghts.Add(signalStrenght * signalCycle);
                    signalCycle += 40;
                }

                cycle++;

                signalStrenght += int.Parse(_data[i][1]);
            }

            if (cycle == signalCycle)
            {
                signalStrenghts.Add(signalStrenght * signalCycle);
                signalCycle += 40;
            }
        }
        
        // Assess
        var result = signalStrenghts.Sum();

        result.Should().Be(expectedResult);
    }
    
}