namespace Domain.Day4;

public class Day4
{
    public static int GetTotallyOverlappedOnly(string data)
    {
        var pairs = data.Split('\n');
        var result = 0;

        foreach (var pair in pairs)
        {
            var elves = pair.Split(',');
            var elf1 = elves[0].Split('-').Select(n => Convert.ToInt32(n)).ToArray();
            var elf2 = elves[1].Split('-').Select(n => Convert.ToInt32(n)).ToArray();

            var firstElfCleanedSecondElfSections = elf1[0] >= elf2[0] && elf1[1] <= elf2[1];
            var secondElfCleanedFirstElfSections = elf2[0] >= elf1[0] && elf2[1] <= elf1[1];
            if (firstElfCleanedSecondElfSections || secondElfCleanedFirstElfSections) result++;
        }

        return result;
    }
    
    public static int GetAllOverlapped(string data)
    {
        var pairs = data.Split('\n');
        var result = 0;

        foreach (var pair in pairs)
        {
            var elves = pair.Split(',');
            var elf1 = elves[0].Split('-').Select(int.Parse).ToArray();
            var elf2 = elves[1].Split('-').Select(int.Parse).ToArray();

            var elf1Clean = GetRange(elf1[0], elf1[1]);
            var elf2Clean = GetRange(elf2[0], elf2[1]);

            if (elf1Clean.Intersect(elf2Clean).Any()) result++;
        }

        return result;
    }
    
    private static IEnumerable<int> GetRange(int first, int second)
    {
        for (var i = first; i <= second; i++)
        {
            yield return i;
        }
    }
}