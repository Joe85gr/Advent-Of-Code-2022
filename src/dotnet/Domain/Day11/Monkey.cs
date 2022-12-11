namespace Domain.Day11;

public class Monkey
{
    public List<double> WorryLevels { get; set; }
    public Operation Operation { get; }
    public double Test { get; }
    public int IfTrue { get; }
    public int IfFalse { get; }

    public double Inspected { get; set; }

    public Monkey(string data)
    {
        var instructions = data.Split('\n').Select(l => l.Trim()).ToArray();

        WorryLevels = instructions[1]
            .Replace("Starting items: ", "")
            .Split(',').Select(double.Parse).ToList();
        Operation = new Operation(instructions[2]);
        Test = int.Parse(instructions[3].Split(' ')[3]);
        IfTrue = int.Parse(instructions[4].Split(' ')[5]);
        IfFalse = int.Parse(instructions[5].Split(' ')[5]);
    }
}