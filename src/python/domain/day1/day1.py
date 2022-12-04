class Day1:

    @staticmethod
    def get_highest_calories(calories: [str]):

        totalCalories = [sum(map(int, calorie.split('\n'))) for calorie in calories]

        return max(totalCalories)

    @staticmethod
    def get_top3_calories(calories: [str]):

        totalCalories = sorted([sum(map(int, calorie.split('\n'))) for calorie in calories], reverse=True)

        return sum(totalCalories[:3])
