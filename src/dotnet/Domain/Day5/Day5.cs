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

        return cratesMatrix
            .Aggregate("", (result, crate) => result + crate.Value.Last());
    }

    private static Dictionary<int, List<string>> SetBaseMatrix(IReadOnlyList<string> rawCrates)
    {
        var totalColumns = int.Parse(rawCrates.Last().Trim().Split(' ').Last());

        var matrix = new Dictionary<int, List<string>>();

        for (var i = 0; i < totalColumns; i++)
        {
            matrix.Add(i, new List<string>());
        }

        for (var i = rawCrates.Count - 2; i >= 0; i--)
        {
            var stack = rawCrates[i].Chunk(4).Select(c => new string(c).Trim()).ToArray();

            for (var currentColumn = 0; currentColumn < totalColumns; currentColumn++)
            {
                if (string.IsNullOrWhiteSpace(stack[currentColumn]) == false)
                    matrix[currentColumn].Add(stack[currentColumn].Substring(1, 1));
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
        Dictionary<int, List<string>> matrix, bool newStackIsReversed)
    {
        foreach (var rearrangement in rearrangements)
        {
            var newStack = new List<string>();

            for (var i = 0; i < rearrangement.Move; i++)
            {
                newStack.Add(matrix[rearrangement.From].Last());
                matrix[rearrangement.From].RemoveAt(matrix[rearrangement.From].Count - 1);
            }

            if(newStackIsReversed) newStack.Reverse();
            
            foreach (var crate in newStack)
            {
                matrix[rearrangement.To].Add(crate);
            }
        }
    }
}