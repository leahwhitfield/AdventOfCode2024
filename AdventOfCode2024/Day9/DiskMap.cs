namespace AdventOfCode2024.Day9;

public class DiskMap
{
    public string Map = "";

    public void AddDiskSpace(int size, int? id)
    {
        if (size <= 0) return;

        for (int i = 0; i < size; i++)
        {
            if (id != null) Map += id;
            else Map += '.';
        }
    }

    public void CompactData()
    {
        while (FindGap(Map) > 0)
        {
            Map = MoveDataBlockToGap(Map);
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

    public long GetChecksum()
    {
        long total = 0;

        for (var i = 0; i < Map.Length; i++)
        {
            var number = Map[i];
            if (number != '.')
            {
                total += i * uint.Parse(number.ToString());
            }
        }

        return total;
    }
}