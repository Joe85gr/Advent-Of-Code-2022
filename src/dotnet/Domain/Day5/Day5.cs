namespace Domain.Day5;

public static class Day5
{
    public static string RearrangeCrates(string[] data, ChallengePart challengePart)
    {
        var (rearrangements, rawCrates) = SetVars(data);

        var cratesMatrix = SetBaseMatrix(rawCrates);

        var newStackIsReversed = challengePart switch
        {
            ChallengePart.One => false,
            ChallengePart.Two => true,
            _ => throw new ArgumentOutOfRangeException(nameof(challengePart), challengePart, null)
        };
        
        RearrangeCratesMatrix(rearrangements, cratesMatrix, newStackIsReversed);

        return new string(cratesMatrix.Select(c => c.Value.Pop()).ToArray());
    }

    private static Dictionary<int, Stack<char>> SetBaseMatrix(IReadOnlyList<string> rawCrates)
    {
        var totalColumns = int.Parse(rawCrates.Last().Trim().Split(' ').Last());

        var matrix = new Dictionary<int, Stack<char>>();

        for (var i = 0; i < totalColumns; i++)
        {
            matrix.Add(i, new Stack<char>());
        }

        for (var i = rawCrates.Count - 2; i >= 0; i--)
        {
            var stack = rawCrates[i].Chunk(4).Select(c => new string(c).Trim()).ToArray();

            for (var currentColumn = 0; currentColumn < totalColumns; currentColumn++)
            {
                if (string.IsNullOrWhiteSpace(stack[currentColumn]) == false)
                    matrix[currentColumn].Push(char.Parse(stack[currentColumn].Substring(1, 1)));
            }
        }

        return matrix;
    }

    private static (Rearrangement[], string[]) SetVars(IReadOnlyList<string> data)
    {
        var rawCrates = data[0].Split('\n').ToArray();

        var rearrangements = data[1]
            .Split('\n')
            .Select(p => new Rearrangement(p))
            .ToArray();

        return (rearrangements, rawCrates);
    }

    private static void RearrangeCratesMatrix(IEnumerable<Rearrangement> rearrangements,
        Dictionary<int, Stack<char>> matrix, bool newStackIsReversed)
    {
        foreach (var rearrangement in rearrangements)
        {
            var newStack = new List<char>();

            for (var i = 0; i < rearrangement.Move; i++)
            {
                newStack.Add(matrix[rearrangement.From].Pop());
                // matrix[rearrangement.From].Pop();
            }

            if(newStackIsReversed) newStack.Reverse();
            
            foreach (var crate in newStack)
            {
                matrix[rearrangement.To].Push(crate);
            }
        }
    }
}