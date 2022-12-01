namespace Domain.Day1;

public class Day1
{
    public static int GetsMaxCalories(string data)
    {
        var calories = data.Split("\n\n");
        var maxCalories = calories
            .Select(num => num
                .Split("\n")
                .Select(n => Convert.ToInt32(n))
                .Sum()
            ).Max();

        return maxCalories;
    }

    public static int GetsSumOfTopThree(string data)
    {
        var calories = data.Split("\n\n");
        var sumOfTopThree = calories
            .Select(num => num.Split("\n").Select(n => Convert.ToInt32(n)).Sum()
            ).OrderDescending()
            .Take(3)
            .Sum();

        return sumOfTopThree;
    }
}