namespace AdventOfCode2024.Day9;

public class DiskMap
{
    public List<int> Map = [];

    public void AddDiskSpace(int size, int? id)
    {
        if (size <= 0) return;

        for (int i = 0; i < size; i++)
        {
            if (id != null) Map.Add((int)id);
            else Map.Add(-1);
        }
    }

    public void CompactData()
    {
        while (FindGap(Map) > 0)
        {
            Map = MoveDataBlockToGap(Map);
        }
    }

    public List<int> MoveDataBlockToGap(List<int> map)
    {
        var gap = FindGap(map);
        var dataBlock = FindLastDataBlock(map);
        map[gap] = dataBlock.Item1;
        map[dataBlock.Item2] = -1;

        return map;
    }

    private (int, int) FindLastDataBlock(List<int> map)
    {
        var dataBlock = -1;
        for (var i = map.Count - 1; i >= 0; i--)
        {
            if (map[i] != -1) return (map[i], i);
        }

        return (dataBlock, 0);
    }

    public int FindGap(List<int> map)
    {
        var freeSpace = 0;
        for (var i = 0; i < map.Count; i++)
        {
            var block = map[i];
            if (block == -1 && freeSpace == 0)
            {
                freeSpace = i;
            }

            if (freeSpace > 0 && block > -1) return freeSpace;
        }

        return 0;
    }

    public long GetChecksum()
    {
        long total = 0;

        for (var i = 0; i < Map.Count; i++)
        {
            var number = Map[i];
            if (number != -1)
            {
                total += i * uint.Parse(number.ToString());
            }
        }

        return total;
    }
}