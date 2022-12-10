using System.Numerics;

namespace Domain.Day9;

public static class Day9
{
    public static int RopeBridge(IEnumerable<string[]> data, int nodes)
    {
        var rope = Enumerable
            .Range(0, nodes)
            .Select(_ => new Vector2(0, 0))
            .ToArray();

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

        return result;
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

        if (Math.Abs(difference.X) > 1 && Math.Abs(difference.Y) > 1)
        {
            tail.X+= Math.Sign(difference.X);
            tail.Y+= Math.Sign(difference.Y);
        }
        else if (Math.Abs(difference.X) > 1 && difference.Y == 0) tail.X += Math.Sign(difference.X);
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