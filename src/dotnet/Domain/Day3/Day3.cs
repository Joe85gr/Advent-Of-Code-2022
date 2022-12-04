namespace Domain.Day3;

public static class Day3
{
    private const int LowerCaseOffset = 96;
    private const int UpperCaseOffset = 38;
    
    public static int GetTotalRucksacksPriority(IEnumerable<string> rucksacks)
    {
        var compartments = rucksacks.Select(r => r.ToCharArray());
        return compartments.Select(GetRucksackPriority).Sum();
    }

    public static int GetTotalGroupsPriority(IEnumerable<string> rucksacks)
    {
        var totalGroupPriority = rucksacks
            .Chunk(3)
            .Select(GetGroupPriority)
            .Sum();

        return totalGroupPriority;
    }

    private static int GetRucksackPriority(char[] compartments)
    {
        var firstCompartment = compartments.Take(compartments.Length / 2);
        var secondCompartment = compartments.Skip(compartments.Length / 2);
        var commonLetter = firstCompartment.Intersect(secondCompartment).First();
        
        return char.IsLower(commonLetter) ? commonLetter - LowerCaseOffset : commonLetter - UpperCaseOffset;
    }

    private static int GetGroupPriority(string[] group)
    {
        var elf1 = group[0];
        var elf2 = group[1];
        var elf3 = group[2];

        var badge = elf1.Intersect(elf2).Intersect(elf3).First();

        return char.IsLower(badge) 
            ? badge - 96 
            : badge - 38;
    }
}