using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Day5
{
    public class Day5(bool useActual = false) : Challenge('5', useActual)
    {
        public List<(int, int)> PageOrderingRules = [];
        public List<int[]> Updates = [];

        public override void LoadData()
        {
            foreach (var line in Data)
            {
                if (line.Contains('|'))
                {
                    var rules = line.Split("|");
                    PageOrderingRules.Add((int.Parse(rules[0]), int.Parse(rules[1])));
                }

                if (line.Contains(','))
                {
                    Updates.Add(line.Split(",").Select(int.Parse).ToArray());
                }
            }
        }

        private int GetMiddlePageNumber(int[] update)
        {
            return update[update.Length / 2];
        }

        public bool IsInCorrectOrder(int[] update)
        {
            for (var i = 0; i < update.Length; i++)
            {
                var pageNumber = update[i];
                foreach (var rule in PageOrderingRules.Where(rule =>
                             update.Contains(rule.Item1) && update.Contains(rule.Item2)))
                {
                    if (rule.Item1 == pageNumber)
                    {
                        if (!NumberIsBefore(i, rule.Item2, update)) return false;
                    }

                    if (rule.Item2 != pageNumber) continue;
                    if (!NumberIsAfter(i, rule.Item1, update)) return false;
                }
            }

            return true;
        }

        private bool NumberIsAfter(int pageNumberIndex, int secondNumber, int[] update)
        {
            for (int i = 0; i < pageNumberIndex + 1; i++)
            {
                if (update[i] == secondNumber) return true;
            }

            return false;
        }

        private bool NumberIsBefore(int pageNumberIndex, int secondNumber, int[] update)
        {
            for (int i = pageNumberIndex; i < update.Length; i++)
            {
                if (update[i] == secondNumber) return true;
            }

            return false;
        }

        public override int Part1()
        {
            int total = 0;
            foreach (var update in Updates)
            {
                if (IsInCorrectOrder(update)) total += GetMiddlePageNumber(update);
            }

            return total;
        }


        public override int Part2()
        {
            return (Updates.Select(update => new { update, orderedUpdate = OrderUpdate(update) })
                .Where(t => !t.orderedUpdate.SequenceEqual(t.update))
                .Select(t => GetMiddlePageNumber(t.orderedUpdate))).Sum();
        }

        public int[] OrderUpdate(int[] update, int startFrom = 0)
        {
            var orderedUpdate = new int[update.Length];
            update.CopyTo(orderedUpdate, 0);

            for (var i = startFrom; i < update.Length; i++)
            {
                var pageNumber = orderedUpdate[i];
                foreach (var rule in PageOrderingRules.Where(rule =>
                             update.Contains(rule.Item1) && update.Contains(rule.Item2)))
                {
                    if (rule.Item1 == pageNumber)
                    {
                        if (!NumberIsBefore(i, rule.Item2, orderedUpdate))
                        {
                            orderedUpdate[i] = rule.Item2;
                            orderedUpdate[Array.FindIndex(update, row => row == rule.Item2)] = pageNumber;
                            if (!IsInCorrectOrder(orderedUpdate))
                            {
                                orderedUpdate = OrderUpdate(orderedUpdate, i);
                            }

                            break;
                        }
                    }

                    if (rule.Item2 != pageNumber) continue;
                    {
                        if (NumberIsAfter(i, rule.Item1, orderedUpdate)) continue;
                        orderedUpdate[i] = rule.Item1;
                        orderedUpdate[Array.FindIndex(update, row => row == rule.Item1)] = pageNumber;
                        if (!IsInCorrectOrder(orderedUpdate))
                        {
                            orderedUpdate = OrderUpdate(orderedUpdate, i);
                        }

                        break;
                    }
                }
            }

            return orderedUpdate;
        }
    }
}