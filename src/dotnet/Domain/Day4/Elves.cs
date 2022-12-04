namespace Domain.Day4;

public record Elves
{
    public IEnumerable<ElfPair> Pairs { get; }

    public Elves(string data)
    {
        Pairs = data
            .Split('\n')
            .Select(p => p
                .Split(','))
            .Select(p => new ElfPair(p));
    }
}