namespace Domain.Day11;

public class Operation
{
    public OperationType Type { get; }
    public string Value { get; }

    public Operation(string data)
    {
        var instructions = data.Split(' ');
        Value = instructions[5];

        Type = instructions[4] switch
        {
            "*" => OperationType.Multiply,
            "+" => OperationType.Add,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}