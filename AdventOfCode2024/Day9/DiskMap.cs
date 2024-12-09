namespace AdventOfCode2024.Day9;

public class DiskMap
{
    public List<DiskSpace> DiskSpaces = [];
    public string Map;

    public void AddDiskSpace(int size, int? id)
    {
        var position = DiskSpaces.Count > 0 ? DiskSpaces[^1].BlockPositions[0] + DiskSpaces[^1].Size : 0;

        if (size <= 0) return;
        if (id != null)
        {
            DiskSpaces.Add(new File((int)id, size, position));
        }
        else
        {
            DiskSpaces.Add(new FreeSpace(size, position));
        }
    }

    public string GetCurrentDiskMap()
    {
        var map = new char[DiskSpaces.Sum(x => x.BlockPositions.Length)];
        for (var i = 0; i < map.Length; i++)
        {
            foreach (var diskSpace in DiskSpaces)
            {
                foreach (var blockPosition in diskSpace.BlockPositions)
                {
                    if (blockPosition == i)
                    {
                        if (diskSpace is File file) map[i] = file.Id.ToString()[0];
                        else map[i] = '.';
                    }
                }
            }
        }
        return new string(map);
    }

    public void CompactData()
    {
        Map = GetCurrentDiskMap();
        var gap = FindGap(Map);
        while (gap > 0)
        {
            Map = MoveDataBlockToGap(Map);
            gap = FindGap(Map);
        }
    }

    public string MoveDataBlockToGap(string map)
    {
        var gap = FindGap(map);
        var newMap = map.ToCharArray();
        var dataBlock = FindLastDataBlock(map);
        newMap[gap] = dataBlock.Item1;
        newMap[dataBlock.Item2] = '.';

        return new string(newMap);
    }

    private (char, int) FindLastDataBlock(string map)
    {
        var dataBlock = '.';
        for (var i = map.Length - 1; i >= 0; i--)
        {
            if (map[i] != '.') return (map[i], i);
        }

        return (dataBlock, 0);
    }

    public int FindGap(string map)
    {
        var freeSpace = 0;
        for (var i = 0; i < map.Length; i++)
        {
            var block = map[i];
            if (block == '.' && freeSpace == 0)
            {
                freeSpace = i;
            }

            if (freeSpace > 0 && block != '.') return freeSpace;
        }

        return 0;
    }

    public int GetChecksum()
    {
        var total = 0;

        for (var i = 0; i < Map.Length; i++)
        {
            var number = Map[i];
            if (number != '.')
            {
                total += i * int.Parse(number.ToString());
            }
        }

        return total;
    }
}