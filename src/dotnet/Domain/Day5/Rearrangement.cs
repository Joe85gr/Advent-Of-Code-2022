namespace Domain.Day5;

public record Rearrangement
{
    public int Move;
    public int From;
    public int To;

    public Rearrangement(string procedure)
    {
        var p = procedure.Split(' ');
        Move = int.Parse(p[1]);
        From = int.Parse(p[3]) - 1;
        To = int.Parse(p[5]) - 1;
    }
}