from pathlib import Path

from domain.day1.day1 import Day1


class Program:
    currentMaxDay = 4

    def start(self):
        selectedDay = self.select_day()
        data = Path(f'../data/day{selectedDay}_data.txt').read_text()
        self.print_result(data, selectedDay)

    def select_day(self):
        while True:
            try:
                selectedDay = int(input("Select day:\n"))
            except ValueError:
                print("Invalid day.")
                continue

            if selectedDay < 0 or selectedDay > self.currentMaxDay:
                print("Invalid day.")
                continue

            return selectedDay

    @staticmethod
    def print_result(data, selected_day):
        part1Result = 0
        part2Result = 0

        if selected_day == 1:
            calories = data.split("\n\n")
            part1Result = Day1.get_highest_calories(calories)
            part2Result = Day1.get_top3_calories(calories)

        print(f"Part 1 result: {part1Result}")
        print(f"Part 2 result: {part2Result}")


app = Program()

app.start()
