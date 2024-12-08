using AdventOfCode2024.Day6;
using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Day8
{
    public class Day8(bool useActual = false) : Challenge('8', useActual)
    {
        public Map Map;

        public override void LoadData()
        {
            Map = new Map((Data.Count, Data[0].Length));
            for (var i = 0; i < Data.Count; i++)
            {
                var line = Data[i];
                for (var j = 0; j < line.Length; j++)
                {
                    var character = line[j];
                    if (character != '.') Map.Antennae.Add(new Antenna(character, new Position(i, j)));
                }
            }
        }

        public override int Part1()
        {
            return Map.GetNumberOfAntinodes();
        }


        public override int Part2()
        {
            return 0;
        }
    }
}