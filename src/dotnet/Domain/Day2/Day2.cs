namespace Domain.Day2;

public static class Day2
{
    public static int GetAssumedTotalScore(IEnumerable<string> rounds)
    {
        var totalScore1 = rounds.Select(GetMyPoints1).Sum();

        return totalScore1;
    }

    public static int GetActualTotalScore(IEnumerable<string> rounds)
    {
        var totalScore1 = rounds.Select(GetMyPoints2).Sum();

        return totalScore1;
    }

    private static int GetMyPoints1(string round)
    {
        var combinations = new Dictionary<string, int>()
        {
            {"A X", 3},
            {"A Y", 6},
            {"A Z", 0},
            {"B X", 0},
            {"B Y", 3},
            {"B Z", 6},
            {"C X", 6},
            {"C Y", 0},
            {"C Z", 3},
        };

        var handPoints = new Dictionary<string, int>()
        {
            {"X", 1},
            {"Y", 2},
            {"Z", 3},
        };

        var hand = round.Split(' ')[1];

        return combinations[round] + handPoints[hand];
    }

    private static int GetMyPoints2(string round)
    {
        var combinationsHandPoints = new Dictionary<string, int>()
        {
            {"A X", 3},
            {"A Y", 1},
            {"A Z", 2},

            {"B X", 1},
            {"B Y", 2},
            {"B Z", 3},

            {"C X", 2},
            {"C Y", 3},
            {"C Z", 1},
        };

        var outcomePoints = new Dictionary<string, int>()
        {
            {"X", 0},
            {"Y", 3},
            {"Z", 6},
        };

        var handPoints = round.Split(' ')[1];

        return combinationsHandPoints[round] + outcomePoints[handPoints];
    }
}