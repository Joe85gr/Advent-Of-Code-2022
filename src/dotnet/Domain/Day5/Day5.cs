namespace Domain.Day5;

public static class Day5
{
    public static string Part1(string[] data)
    {
        var (rearrangements, rawCrates) = SetVars(data);

        var cratesMatrix = SetBaseMatrix(rawCrates);

        RearrangeMatrixPart1(rearrangements, cratesMatrix);

        return cratesMatrix
            .Aggregate("", (result, crate) => result + crate.Value.Last());
    }

    public static string Part2(string[] data)
    {
        var (rearrangements, rawCrates) = SetVars(data);

        var matrix = SetBaseMatrix(rawCrates);

        RearrangeMatrixPart2(rearrangements, matrix);

        return matrix
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
            var row = rawCrates[i].Chunk(4).Select(c => new string(c).Trim()).ToArray();

            for (var currentColumn = 0; currentColumn < totalColumns; currentColumn++)
            {
                if (string.IsNullOrWhiteSpace(row[currentColumn]) == false)
                    matrix[currentColumn].Add(row[currentColumn].Substring(1, 1));
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

    private static void RearrangeMatrixPart1(IEnumerable<Rearrangement> rearrangements, 
        Dictionary<int, List<string>> matrix)
    {
        foreach (var rearrangement in rearrangements)
        {
            for (var i = 0; i < rearrangement.Move; i++)
            {
                matrix[rearrangement.To].Add(matrix[rearrangement.From].Last());
                matrix[rearrangement.From].RemoveAt(matrix[rearrangement.From].Count - 1);
            }
        }
    }

    private static void RearrangeMatrixPart2(IEnumerable<Rearrangement> rearrangements,
        Dictionary<int, List<string>> matrix)
    {
        foreach (var rearrangement in rearrangements)
        {
            var row = new List<string>();

            for (var i = 0; i < rearrangement.Move; i++)
            {
                row.Add(matrix[rearrangement.From].Last());
                matrix[rearrangement.From].RemoveAt(matrix[rearrangement.From].Count - 1);
            }

            for (var i = row.Count; i > 0; i--)
            {
                matrix[rearrangement.To].Add(row[i - 1]);
            }
        }
    }
}