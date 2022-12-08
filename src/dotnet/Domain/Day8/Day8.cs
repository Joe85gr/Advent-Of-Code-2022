namespace Domain.Day8;

public static class Day8
{
    public static int GetVisibleTrees(int[][] treeMatrix)
    {
        var outerTrees = treeMatrix.Length * 2 + (treeMatrix[0].Length - 2) * 2;

        var visibleTrees = 0;
        
        for (var i = 1; i < treeMatrix.Length - 1; i++)
        {
            var currentRow = treeMatrix[i];

            for (var j = 1; j < treeMatrix[0].Length - 1; j++)
            {
                var currentNumber = treeMatrix[i][j];

                var currentColumn = treeMatrix.Select(t => t[j]).ToArray();
                var maxBottom = currentColumn.Where((col, row) => row > i).Max();
                var maxTop = currentColumn.Where((col, row) => row < i).Max();

                var maxRight = currentRow.Where((row, col) => col > j).Max();
                var maxLeft = currentRow.Where((row, col) => col < j).Max();

                if (currentNumber > maxBottom || currentNumber > maxTop
                                              || currentNumber > maxLeft || currentNumber > maxRight) visibleTrees++;
            }

        }
        
        var result = visibleTrees + outerTrees;

        return result;
    }

    public static int GetMaxScenicScore(int[][] treeMatrix)
    {
        var maxScenicScore = 0;
        
        for (var i = 1; i < treeMatrix.Length - 1; i++)
        {
            var currentRow = treeMatrix[i];

            for (var j = 1; j < treeMatrix[0].Length - 1; j++)
            {
                var currentColumn = treeMatrix.Select(t => t[j]).ToArray();

                var currentTree = treeMatrix[i][j];

                var bottom = currentColumn.Where((col, row) => row > i);
                var top = currentColumn.Where((col, row) => row < i);
                var right = currentRow.Where((row, col) => col > j);
                var left = currentRow.Where((row, col) => col < j);

                var bottomVisibleTrees = CountVisibleTrees(bottom, currentTree, false);
                var topVisibleTrees = CountVisibleTrees(top, currentTree, true);
                var leftVisibleTrees = CountVisibleTrees(left, currentTree, true);
                var rightVisibleTrees = CountVisibleTrees(right, currentTree, false);
                
                var scenicScore = topVisibleTrees * bottomVisibleTrees * leftVisibleTrees * rightVisibleTrees;

                if (scenicScore > maxScenicScore)
                {
                    maxScenicScore = scenicScore;
                }

            }
            
        }

        return maxScenicScore;
    }

    private static int CountVisibleTrees(IEnumerable<int> trees, int currentTree, bool reverse)
    {
        var visibleTrees = 0;

        if (reverse) trees = trees.Reverse().ToArray();

        foreach (var tree in trees)
        {
            visibleTrees++;
            if (tree >= currentTree) break;
        }

        return visibleTrees;
    }
}