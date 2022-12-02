using Domain.Day1;
using Domain.Day2;

var day1Part1Result = Day1.GetsMaxCalories(File.ReadAllText("./Day1_Data.txt"));
var day1Part2Result = Day1.GetsSumOfTopThree(File.ReadAllText("./Day1_Data.txt"));

Console.WriteLine($"Day 1 Part 1 Solution: {day1Part1Result}");
Console.WriteLine($"Day 1 Part 2 Solution: {day1Part2Result}");

var day2Part1Result = Day2.GetTotalScore1(File.ReadAllText("./Day1_Data.txt"));
var day2Part2Result = Day2.GetTotalScore2(File.ReadAllText("./Day1_Data.txt"));

Console.WriteLine($"Day 2 Part 1 Solution: {day2Part1Result}");
Console.WriteLine($"Day 2 Part 2 Solution: {day2Part2Result}");