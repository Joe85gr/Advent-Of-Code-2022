using FluentAssertions;
using Xunit.Abstractions;

namespace UnitTests;

public class Day10Tests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly string[][] _data;
    
    private List<int> _signalStrengths;
    private int _signalStrength;
    private int _cycle;
    private int _signalCycle;
    
    

    public Day10Tests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _data = File.ReadAllLines(@"./TestData/Day10_Data.txt")
            .Select(l => l.Split(' ')).ToArray();
    }

    [Fact]
    public void Part1()
    {
        // Arrange
        const int expectedResult = 13140;

        // Act
        _cycle = 1;
        _signalStrengths = new List<int>();
        _signalStrength = 1;

        _signalCycle = 20;

        for (var i = 0; i < _data.Length; i++)
        {
            if (_data[i][0] == "noop")
            {
                _cycle++;
            }
            else if (_data[i][0] == "addx")
            {
                _cycle++;
                CheckCycle();
                _cycle++;

                _signalStrength += int.Parse(_data[i][1]);
            }

            CheckCycle();
        }

        // Assess
        var result = _signalStrengths.Sum();

        result.Should().Be(expectedResult);
    }

    private void CheckCycle()
    {
        if (_cycle == _signalCycle)
        {
            _signalStrengths.Add(_signalStrength * _signalCycle);
            _signalCycle += 40;
        }
    }

    [Fact]
    public void Part2()
    {
        // Arrange
        var expectedResult = 0;
        // Act
        const int width = 40;
        const int height = 6;

        var screen = Enumerable.Range(0, height)
            .Select(_ => Enumerable.Range(0, width).Select(_ => '▓').ToArray())
            .ToArray();

        // Print(screen);

        var currentCycle = 0;
        var currentRow = 0;
        var register = 0;

        void AddCycle()
        {
        }

        foreach (var line in _data)
        {
            if (line[0] == "addx")
            {
                screen[currentRow][register] = '#';
                currentCycle++;

                Print(screen);
                screen[currentRow][register] = '#';
            }

            break;

            if (line[0] == "noop")
            {
                screen[currentRow][register] = '#';
                currentCycle++;
                Print(screen);
            }
        }

        // Assess
        var result = 0;
        result.Should().Be(expectedResult);
    }

    private void Print(IReadOnlyList<char[]> screen)
    {
        foreach (var line in screen)
        {
            _testOutputHelper.WriteLine(new string(line));
        }
    }
}