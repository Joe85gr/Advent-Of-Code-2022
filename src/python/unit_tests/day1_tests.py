import unittest
from pathlib import Path
from domain.day1.day1 import Day1


class TestDay1(unittest.TestCase):

    data = Path('test_data/Day1_data.txt').read_text()

    def test_top3_calories(self):
        # arrange
        expectedResult = 45000

        # act
        calories = self.data.split("\n\n")
        result = Day1.get_top3_calories(calories)

        # assert
        self.assertEqual(expectedResult, result)

    def test_highest_calories(self):
        # arrange
        expectedResult = 24000

        # act
        calories = self.data.split("\n\n")
        result = Day1.get_highest_calories(calories)

        # assert
        self.assertEqual(expectedResult, result)


if __name__ == '__main__':
    unittest.main()
