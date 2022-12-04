namespace Domain.Day4;

public record ElfPair
{
    public ElfRange FirstElf { get; }
    public ElfRange SecondElf { get; }

    public ElfPair(IEnumerable<string> pair)
    {
        var elves = pair
            .Select(p => p.Split('-'))
            .Select(r => new ElfRange(int.Parse(r[0]), int.Parse(r[1])))
            .ToArray();

        FirstElf = elves[0];
        SecondElf = elves[1];
    }
}