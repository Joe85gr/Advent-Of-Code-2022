using Domain.Day1;

var day1Part1Result = Day1.GetsMaxCalories(File.ReadAllText("./Day1_Data.txt"));
var day1Part2Result = Day1.GetsSumOfTopThree(File.ReadAllText("./Day1_Data.txt"));

Console.WriteLine($"Day 1 Part 1 Solution: {day1Part1Result}");
Console.WriteLine($"Day 1 Part 1 Solution: {day1Part2Result}");