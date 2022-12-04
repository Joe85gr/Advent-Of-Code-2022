namespace Domain.Day4;

public static class Day4
{
    public static int CountIfTotallyOverlapped(ElfPair pair)
    {
        var firstElfCleanedSecondElfSections =
            pair.FirstElf.From >= pair.SecondElf.From && pair.FirstElf.To <= pair.SecondElf.To;
        
        var secondElfCleanedFirstElfSections =
            pair.SecondElf.From >= pair.FirstElf.From && pair.SecondElf.To <= pair.FirstElf.To;

        return firstElfCleanedSecondElfSections || secondElfCleanedFirstElfSections ? 1 : 0;
    }

    public static int CountIfOverlapped(ElfPair pair)
    {
        var elf1Clean = GetRange(pair.FirstElf.From, pair.FirstElf.To);
        var elf2Clean = GetRange(pair.SecondElf.From, pair.SecondElf.To);

        return elf1Clean.Intersect(elf2Clean).Any() ? 1 : 0;
    }
    
    private static IEnumerable<int> GetRange(int first, int second)
    {
        for (var i = first; i <= second; i++)
        {
            yield return i;
        }
    }
}