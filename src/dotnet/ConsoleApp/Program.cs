﻿using Domain;
using Domain.Day1;
using Domain.Day2;
using Domain.Day3;
using Domain.Day4;
using Domain.Day5;

var validDay = false;
var selectedDay = 0;
const int currentMaxDay = 5;

while (validDay == false)
{
    Console.WriteLine($"Select Day between 1 and {currentMaxDay}: ");
    validDay = int.TryParse(Console.ReadLine(), out selectedDay) && selectedDay is > 0 and <= currentMaxDay;
    if (validDay == false) Console.WriteLine($"Meh, {selectedDay} this isn't a valid day..");
}

var part1Result = "";
var part2Result = "";

var timer = new System.Diagnostics.Stopwatch();

timer.Start();

var rawData = File.ReadAllText($"./Data/Day{selectedDay}_Data.txt");

switch (selectedDay)
{
    case 1:
        var calories = rawData.Split("\n\n");
        part1Result = Day1.GetsMaxCalories(calories).ToString();
        part2Result = Day1.GetsSumOfTopThree(calories).ToString();
        break;
    case 2:
        var rounds = rawData.Split("\n");
        part1Result = Day2.GetAssumedTotalScore(rounds).ToString();
        part2Result = Day2.GetActualTotalScore(rounds).ToString();
        break;
    case 3:
        var rucksacks = rawData.Split("\n");
        part1Result = Day3.GetTotalRucksacksPriority(rucksacks).ToString();
        part2Result = Day3.GetTotalGroupsPriority(rucksacks).ToString();
        break;
    case 4:
        var elvesPairs = new Elves(rawData).Pairs.ToArray();
        part1Result = elvesPairs.Select(Day4.CountIfTotallyOverlapped).Sum().ToString();
        part2Result = elvesPairs.Select(Day4.CountIfOverlapped).Sum().ToString();
        break;
    case 5:
        var data = rawData.Split("\n\n");
        part1Result = Day5.RearrangeCrates(data, ChallengePart.One);
        part2Result = Day5.RearrangeCrates(data, ChallengePart.Two);
        break;
}

timer.Stop();

if ( string.IsNullOrWhiteSpace(part1Result) || string.IsNullOrWhiteSpace(part2Result)) 
    throw new Exception("Something went wrong. Results cannot be empty.");

Console.WriteLine($"Day {selectedDay} Part 1 Solution: {part1Result}");
Console.WriteLine($"Day {selectedDay} Part 2 Solution: {part2Result}");
Console.WriteLine($"Executed in: {timer.ElapsedMilliseconds}ms");