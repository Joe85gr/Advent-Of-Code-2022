namespace Domain.Day6;

public static class Day6
{
    public static int FindFirstUniqueOccurrence(string data, ChallengePart challengePart)
    {
        var buffer = data.ToCharArray();
        
        var size = challengePart switch
        {
            ChallengePart.One => 4,
            ChallengePart.Two => 14,
            _ => throw new ArgumentOutOfRangeException(nameof(challengePart), challengePart, null)
        };

        var sample = buffer.Take(size).ToArray();

        var result = 0;
        
        for (var i = size; i < buffer.Length; i++)
        {
            if (sample.Length == sample.Distinct().Count())
            {
                result = i;
                break;
            }

            for (var j = 0; j < size - 1; j++)
                sample[j] = sample[j + 1];
            
            sample[size - 1] = buffer[i];
        }

        return result;
    }
}