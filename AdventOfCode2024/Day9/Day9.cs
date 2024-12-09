using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Day9
{
    public class Day9(bool useActual = false) : BigChallenge('9', useActual)
    {
        public DiskMap DiskMap;

        public override void LoadData()
        {
            DiskMap = new DiskMap();
            foreach (var line in Data)
            {
                var diskMap = line.ToCharArray();
                for (var i = 0; i < line.Length; i++)
                {
                    var number = int.Parse(diskMap[i].ToString());
                    if (i % 2 == 0)
                    {
                        DiskMap.AddDiskSpace(number, i/2);
                    }
                    else
                    {
                        DiskMap.AddDiskSpace(number, null);
                    }
                }
            }
        }

        public override long Part1()
        {
            DiskMap.CompactData();
            return DiskMap.GetChecksum();
        }


        public override long Part2()
        {
            DiskMap.MoveFiles();
            return DiskMap.GetChecksum();
        }
    }
}