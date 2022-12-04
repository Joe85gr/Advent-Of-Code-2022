using Domain.Day1;
using Domain.Day2;
using Domain.Day3;
using Domain.Day4;

var validDay = false;
var selectedDay = 0;
const int currentMaxDay = 4;

while (validDay == false)
{
    Console.WriteLine($"Select Day between 1 and {currentMaxDay}: ");
    validDay = int.TryParse(Console.ReadLine(), out selectedDay) && selectedDay is > 0 and <= currentMaxDay;
    if (validDay == false) Console.WriteLine($"Meh, {selectedDay} this isn't a valid day..");
}

var part1Result = 0;
var part2Result = 0;

var rawData = File.ReadAllText($"./Data/Day{selectedDay}_Data.txt");

switch (selectedDay)
{
    case 1:
        var calories = rawData.Split("\n\n");
        part1Result = Day1.GetsMaxCalories(calories);
        part2Result = Day1.GetsSumOfTopThree(calories);
        break;
    case 2:
        var rounds = rawData.Split("\n");
        part1Result = Day2.GetAssumedTotalScore(rounds);
        part2Result = Day2.GetActualTotalScore(rounds);
        break;
    case 3:
        var rucksacks = rawData.Split("\n");
        part1Result = Day3.GetTotalRucksacksPriority(rucksacks);
        part2Result = Day3.GetTotalGroupsPriority(rucksacks);
        break;
    case 4:
        var elvesPairs = new Elves(rawData).Pairs.ToArray();
        part1Result = elvesPairs.Select(Day4.CountIfTotallyOverlapped).Sum();
        part2Result = elvesPairs.Select(Day4.CountIfOverlapped).Sum();
        break;
}

if (part1Result == 0 || part2Result == 0) throw new Exception("Something went wrong. Results cannot be 0.");

Console.WriteLine($"Day {selectedDay} Part 1 Solution: {part1Result}");
Console.WriteLine($"Day {selectedDay} Part 2 Solution: {part2Result}");