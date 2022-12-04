namespace Domain.Day1;

public class Day1
{
    public static int GetsMaxCalories(IEnumerable<string> calories)
    {
        var maxCalories = calories
            .Select(num => num
                .Split("\n")
                .Select(n => Convert.ToInt32(n))
                .Sum()
            ).Max();

        return maxCalories;
    }

    public static int GetsSumOfTopThree(IEnumerable<string> calories)
    {
        var sumOfTopThree = calories
            .Select(num => num.Split("\n").Select(n => Convert.ToInt32(n)).Sum()
            ).OrderByDescending(n => n)
            .Take(3)
            .Sum();

        return sumOfTopThree;
    }
}