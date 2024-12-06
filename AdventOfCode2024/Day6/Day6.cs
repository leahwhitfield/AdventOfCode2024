using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Day6
{
    public class Day6(bool useActual = false) : Challenge('6', useActual)
    {
        public LabMap LabMap;
        private Position startingPosition;

        public override void LoadData()
        {
            LabMap = new LabMap((Data.Count, Data[0].Length));
            for (var y = 0; y < Data.Count; y++)
            {
                var line = Data[y];
                for (var x = 0; x < line.Length; x++)
                {
                    var space = line[x];
                    var position = new Position(y, x);

                    if (space == '#')
                    {
                        LabMap.Obstacles.Add(position);
                        continue;
                    }

                    if (space != '.')
                    {
                        startingPosition = position;
                        LabMap.Guard = new Guard(position, DirectionMethods.GetDirection(space));
                    }
                }
            }
        }

        public override int Part1()
        {
            return LabMap.MoveGuard();
        }


        public override int Part2()
        {

            return 0;
        }
    }
}