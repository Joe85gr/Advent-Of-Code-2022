import unittest
from pathlib import Path


class TestDay1(unittest.TestCase):
    data = Path('./test_data/Day2_data.txt').read_text()

    def part1(self):
        # arrange
        expectedResult = 15

        # act
        adversaryHands = {
            "A": "Rock",
            "B": "Paper",
            "C": "Scissor"
        }

        meHands = {
            "X": "Rock",
            "Y": "Paper",
            "Z": "Scissor"
        }

        basePoints = {
            "Rock": "1",
            "Paper": "2",
            "Scissor": "3",
        }

        resultPoints = {
            "Lose": 0,
            "Draw": 3,
            "Win": 6,
        }

        combinations = {
            "RockRock": "Draw",
            "RockPaper": "Lose",
            "RockScissor": "Win",

            "PaperRock": "Win",
            "PaperPaper": "Draw",
            "PaperScissor": "Lose",

            "ScissorRock": "Lose",
            "ScissorPaper": "Win",
            "ScissorScissor": "Draw"
        }

        totalResult = 0
        games = self.data.split("\n")
        for game in games:
            hands = game.split(' ')
            adversary = adversaryHands[hands[0]]
            me = meHands[hands[1]]
            currentGameResult = basePoints[me] + resultPoints[combinations[adversary + me]]
            totalResult += currentGameResult

        # assert
        self.assertEqual(expectedResult, totalResult)


if __name__ == '__main__':
    unittest.main()
