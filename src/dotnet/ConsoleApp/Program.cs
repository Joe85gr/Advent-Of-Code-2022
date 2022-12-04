using Domain.Day1;
using Domain.Day2;
using Domain.Day3;
using Domain.Day4;

var day1Part1Result = Day1.GetsMaxCalories(File.ReadAllText("./Data/Day1_Data.txt"));
var day1Part2Result = Day1.GetsSumOfTopThree(File.ReadAllText("./Data/Day1_Data.txt"));

Console.WriteLine($"Day 1 Part 1 Solution: {day1Part1Result}");
Console.WriteLine($"Day 1 Part 2 Solution: {day1Part2Result}");

var day2Part1Result = Day2.GetTotalScore1(File.ReadAllText("./Data/Day2_Data.txt"));
var day2Part2Result = Day2.GetTotalScore2(File.ReadAllText("./Data/Day2_Data.txt"));

Console.WriteLine($"Day 2 Part 1 Solution: {day2Part1Result}");
Console.WriteLine($"Day 2 Part 2 Solution: {day2Part2Result}");

var day3Part1Result = Day3.GetTotalRucksacksPriority(File.ReadAllText("./Data/Day3_Data.txt"));
var day3Part2Result = Day3.GetTotalGroupsPriority(File.ReadAllText("./Data/Day3_Data.txt"));

Console.WriteLine($"Day 3 Part 1 Solution: {day3Part1Result}");
Console.WriteLine($"Day 3 Part 2 Solution: {day3Part2Result}");

var elvesPairs = new Elves(File.ReadAllText("./Data/Day4_Data.txt")).Pairs.ToArray();
var day4Part1Result = elvesPairs.Select(Day4.CountIfTotallyOverlapped).Sum();
var day4Part2Result = elvesPairs.Select(Day4.CountIfOverlapped).Sum();

Console.WriteLine($"Day 4 Part 1 Solution: {day4Part1Result}");
Console.WriteLine($"Day 4 Part 2 Solution: {day4Part2Result}");