namespace Domain.Day11;

public static class Day11
{
    public static double Part1(Monkey[] monkeys, ChallengePart challengePart, double leastCommonMultiple = 0)
    {
        if (challengePart == ChallengePart.Two && leastCommonMultiple == 0)
            throw new Exception("Part 2 requires you to pass least common multiple between the Test values!");
        
        var rounds = challengePart == ChallengePart.One ? 20 : 10000;

        for (var i = 0; i < rounds; i++)
        {
            foreach (var monkey in monkeys)
            {
                var worryLevels = monkey.WorryLevels;

                monkey.WorryLevels = new List<double>();

                monkey.Inspected += worryLevels.Count;

                foreach (var worryLevel in worryLevels)
                {
                    var value = monkey.Operation.Value == "old"
                        ? worryLevel
                        : int.Parse(monkey.Operation.Value);

                    var newWorryLevel = worryLevel;

                    if (monkey.Operation.Type == OperationType.Add) newWorryLevel += value;
                    else if (monkey.Operation.Type == OperationType.Multiply) newWorryLevel *= value;
                    else throw new ArgumentOutOfRangeException();

                    newWorryLevel = DecreaseWorry(challengePart, newWorryLevel, leastCommonMultiple);
                    
                    if (newWorryLevel % monkey.Test == 0) monkeys[monkey.IfTrue].WorryLevels.Add(newWorryLevel);
                    else if (newWorryLevel % monkey.Test > 0) monkeys[monkey.IfFalse].WorryLevels.Add(newWorryLevel);
                    else throw new ArgumentOutOfRangeException();
                }
            }
        }

        var monkeyBusinessLevels = monkeys.Select(m => m.Inspected).OrderByDescending(x => x).ToArray();

        var result = monkeyBusinessLevels.Take(2).Aggregate(1d, (current, next) => current * next);

        return result;
    }

    private static double DecreaseWorry(ChallengePart challengePart, double worryLevel, double leastCommonMultiple)
    {
        return challengePart switch
        {
            ChallengePart.One => Math.Floor(worryLevel / 3),
            ChallengePart.Two => worryLevel % leastCommonMultiple,
            _ => throw new ArgumentOutOfRangeException(nameof(challengePart), challengePart, null)
        };
    }
}