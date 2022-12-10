using System.Numerics;
using FluentAssertions;

namespace UnitTests;

public class Day9Tests
{
    [Fact]
    public void Part1()
    {
        // Arrange
        var data = File.ReadAllLines(@"./TestData/Day9_Data_Part1.txt")
            .Select(l => l.Split(' ')).ToArray();
        const int expectedResult = 13;
        const int nodes = 2;

        var rope = Enumerable
            .Range(0, nodes)
            .Select(_ => new Vector2(0, 0))
            .ToArray();

        // Act
        var visitedPositions = new HashSet<Vector2>();

        foreach (var line in data)
        {
            var direction = GetDirection(line[0]);
            var times = int.Parse(line[1]);

            for (var i = 0; i < times; i++)
            {
                rope[0] += direction;

                for (var node = 1; node < rope.Length; node++)
                {
                    rope[node] = MoveTail(rope[node - 1], rope[node]);

                    if (node == rope.Length - 1) visitedPositions.Add(rope[node]);
                }
            }
        }

        var result = visitedPositions.Count;

        // Assess
        result.Should().Be(expectedResult);
    }

    [Fact]
    public void Part2()
    {
        // Arrange
        var data = File.ReadAllLines(@"./TestData/Day9_Data_Part2.txt")
            .Select(l => l.Split(' ')).ToArray();
        const int expectedResult = 36;
        const int nodes = 10;

        var rope = Enumerable
            .Range(0, nodes)
            .Select(_ => new Vector2(0, 0))
            .ToArray();

        // Act
        var visitedPositions = new HashSet<Vector2>();

        foreach (var line in data)
        {
            var direction = GetDirection(line[0]);
            var times = int.Parse(line[1]);

            for (var i = 0; i < times; i++)
            {
                rope[0] += direction;

                for (var node = 1; node < rope.Length; node++)
                {
                    rope[node] = MoveTail(rope[node - 1], rope[node]);

                    if (node == rope.Length - 1) visitedPositions.Add(rope[node]);
                }
            }
        }

        var result = visitedPositions.Count;

        // Assess
        result.Should().Be(expectedResult);
    }

    
    private static Vector2 GetDirection(string direction) => direction switch
    {
        "R" => new Vector2(1, 0),
        "L" => new Vector2(-1, 0),
        "U" => new Vector2(0, -1),
        "D" => new Vector2(0, 1),
        _ => throw new ArgumentOutOfRangeException()
    };

    private static Vector2 MoveTail(Vector2 head, Vector2 tail)
    {
        var difference = head - tail;

        if (Math.Abs(difference.X) > 1 && difference.Y == 0) tail.X += Math.Sign(difference.X);
        else if (Math.Abs(difference.Y ) > 1 && difference.X == 0) tail.Y+= Math.Sign(difference.Y);
        else if (Math.Abs(difference.Y) > 1 && Math.Abs(difference.X) > 0)
        {
            tail.X = head.X;
            tail.Y+= Math.Sign(difference.Y);
        }
        else if (Math.Abs(difference.X) > 1 && Math.Abs(difference.Y) > 0)
        {
            tail.Y = head.Y;
            tail.X+= Math.Sign(difference.X);
        }

        return tail;
    }
}