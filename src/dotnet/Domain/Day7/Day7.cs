namespace Domain.Day7;

public static class Day7
{
    public static int Part1(string[] log)
    {
        var directories = GenerateDirectoryList(log);
        const int sizeThreshold = 100000;

        directories.Remove("/");

        var result = directories
            .Where(dir => dir.Value <= sizeThreshold)
            .Sum(dir => dir.Value);

        return result;
    }

    public static int Part2(string[] log)
    {
        var directories = GenerateDirectoryList(log);

        const int totalSpace = 70000000;
        const int minSpace = 30000000;

        var sizes = directories
            .Select(dir => dir.Value)
            .OrderBy(size => size)
            .ToArray();

        var usedSpace = sizes.Max();

        var requiredSpace = minSpace - (totalSpace - usedSpace);

        var result = sizes
            .Where(size => size >= requiredSpace)
            .MinBy(size => size);

        return result;
    }

    private static Dictionary<string, int> GenerateDirectoryList(IReadOnlyList<string> log)
    {
        const string root = "/";
        
        var currentDirPath = new List<string> {root};

        var directories = new Dictionary<string, int> {{root, 0}};

        for (var i = 1; i < log.Count; i++)
        {
            if (log[i].Contains("$ cd ") && log[i].Contains("$ cd ..") == false)
            {
                var newDir = log[i].Split(' ')[2];
                currentDirPath.Add(newDir);
                var newDirFullPath = string.Join("/", currentDirPath);
                directories.Add(newDirFullPath, 0);
            }
            else if (log[i].Contains("$ cd .."))
            {
                currentDirPath.RemoveAt(currentDirPath.Count - 1);
            }
            else if (int.TryParse(log[i].Split(' ')[0], out var size))
            {
                var folderSizeToUpdate = currentDirPath[0];
                directories[folderSizeToUpdate] += size;
                for (var j = 1; j < currentDirPath.Count; j++)
                {
                    folderSizeToUpdate += $"/{currentDirPath[j]}";
                    directories[folderSizeToUpdate] += size;
                }
            }
        }

        return directories;
    }
}