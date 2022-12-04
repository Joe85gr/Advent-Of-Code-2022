namespace Domain.Day3;

public class Day3
{
    private const int LowerCaseOffset = 96;
    private const int UpperCaseOffset = 38;
    
    public static int GetTotalRucksacksPriority(string data)
    {
        var rucksacks = data.Split("\n")
            .Select(r => r.ToCharArray());
        
        return rucksacks.Select(GetRucksackPriority).Sum();
    }

    public static int GetTotalGroupsPriority(string data)
    {
        var rucksacks = data.Split("\n");
        var result = 0;

        for (var i = 0; i < rucksacks.Length; i+=3)
        {
            var elf1 = rucksacks[i];
            var elf2 = rucksacks[i + 1];
            var elf3 = rucksacks[i + 2];

            var badge = elf1.Intersect(elf2).Intersect(elf3).First();

            result += char.IsLower(badge) 
                ? badge - 96 
                : badge - 38;
        }

        return result;
    }

    private static int GetRucksackPriority(char[] compartments)
    {
        var firstCompartment = compartments.Take(compartments.Length / 2);
        var secondCompartment = compartments.Skip(compartments.Length / 2);
        var commonLetter = firstCompartment.Intersect(secondCompartment).First();
        
        return char.IsLower(commonLetter) ? commonLetter - LowerCaseOffset : commonLetter - UpperCaseOffset;
    }
}