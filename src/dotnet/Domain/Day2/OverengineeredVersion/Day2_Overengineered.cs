namespace Domain.Day2.OverengineeredVersion;

public static class Day2Overengineered
{
    private const int AdversaryIndex = 0;
    private const int MyIndex = 1;
    
    public static int GetTotalScore1(IEnumerable<string> rounds)
    {
        var score = rounds
            .Select(CalculateGuessedRoundResult)
            .Sum();

        return score;
    }

    public static int GetTotalScore2(IEnumerable<string> rounds)
    {
        var totalPoints = rounds
            .Select(CalculateActualRoundResult)
            .Sum();
        
        return totalPoints;
    }
    
    private static readonly Dictionary<char, Hand> GuessedHandsMapping = new()
    {
        {'A', Hand.Rock},
        {'B', Hand.Paper},
        {'C', Hand.Scissor},
        {'X', Hand.Rock},
        {'Y', Hand.Paper},
        {'Z', Hand.Scissor},
    };

    private static readonly Dictionary<char, Result> MyResultsMapping = new()
    {
        {'X', Result.Lose},
        {'Y', Result.Draw},
        {'Z', Result.Win}
    };

    
    private static Hand GetMyHand(Hand adversaryHand, Result result)
    {
        if (adversaryHand == Hand.Rock && result == Result.Win) return Hand.Paper;
        if (adversaryHand == Hand.Rock && result == Result.Lose) return Hand.Scissor;
        if (adversaryHand == Hand.Paper && result == Result.Win) return Hand.Scissor;
        if (adversaryHand == Hand.Paper && result == Result.Lose) return Hand.Rock;
        if (adversaryHand == Hand.Scissor && result == Result.Win) return Hand.Rock;
        if (adversaryHand == Hand.Scissor && result == Result.Lose) return Hand.Paper;

        return adversaryHand;
    }

    private static readonly Dictionary<Hand, Hand> WinningHands = new()
    {
        {Hand.Rock, Hand.Scissor},
        {Hand.Paper, Hand.Rock},
        {Hand.Scissor, Hand.Paper},
    };

    private static int CalculateGuessedRoundResult(string round)
    {
        var hands = round
            .Split(' ')
            .Select(char.Parse)
            .ToArray();

        var adversaryHand = GuessedHandsMapping[hands[AdversaryIndex]];
        var myHand = GuessedHandsMapping[hands[MyIndex]];
        
        if (myHand == adversaryHand) return (int)Result.Draw + (int)myHand;
        if (WinningHands[myHand] == adversaryHand) return (int)Result.Win + (int)myHand;
        return (int)Result.Lose + (int)myHand;
    }

    private static int CalculateActualRoundResult(string round)
    {
        var hands = round
            .Split(' ')
            .Select(char.Parse)
            .ToArray();

        var adversaryHand = GuessedHandsMapping[hands[AdversaryIndex]];
        var result = MyResultsMapping[hands[MyIndex]];
        var myHand = GetMyHand(adversaryHand, result);

        return (int)result + (int)myHand;
    }
}