namespace Domain.Day7;

public static class Day7
{
    public static int Part1(string[] log)
    {
        var directories = GenerateDirectoryList(log);

        directories.Remove("/");
        
        var result = directories.Where(d => d.Value <= 100000)
            .Sum(d => d.Value);

        return result;
    }
    
    public static int Part2(string[] log)
    {
        var directories = GenerateDirectoryList(log);
        
        var totalSpace = 70000000d;
        var minSpace = 30000000d;
        var sizes = directories.Select(d => d.Value).OrderBy(x => x).ToArray();

        var usedSpace = sizes.Max();

        var requiredSpace = minSpace - (totalSpace - usedSpace);
        
        var result = sizes.Where(s => s >= requiredSpace).OrderBy(x => x).ToArray().First();

        return result;
    }

    private static Dictionary<string, int> GenerateDirectoryList(IReadOnlyList<string> log)
    {
        var currentDirPath = new List<string> {"/"};

        var directories = new Dictionary<string, int>{ {currentDirPath[0], 0} };

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