using System.Text.RegularExpressions;
using AdventOfCode2024.Helpers;


namespace AdventOfCode2024.Day3
{
    public class Day3(bool useActual = false) : Challenge('3', useActual)
    {
        private string Program = "";
        Regex mulRegex = new Regex(@"mul\(([0-9]+),([0-9]+)\)");
        
        public override void LoadData()
        {
            foreach (var line in Data)
            {
                Program += line;
            }
        }
        public override int Part1()
        {
            int total = 0;

            total += FindMultiplyCommands(Program);

            return total;
        }

        private int FindMultiplyCommands(string program)
        {
            int total = 0;
            MatchCollection matches = mulRegex.Matches(program);
            for (int i = 0; i < matches.Count; i++)
            {
                var match = matches[i];
                total += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
            }

            return total;
        }
        
        
        private int FindMultiplyCommandsPart2(string program)
        {
            int total = 0;
            bool mulEnabled = true;

            MatchCollection mulMatches = mulRegex.Matches(program);
            MatchCollection dontMatches = new Regex(@"don't").Matches(program);
            MatchCollection doMatches = new Regex(@"do").Matches(program);
            for (int i = 0; i < mulMatches.Count; i++)
            {
                var match = mulMatches[i];
                if (IsDisabled(dontMatches, doMatches, match.Index))
                {
                    continue;
                }
                total += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
            }

            return total;
        }

        private bool IsDisabled(MatchCollection dontMatches, MatchCollection doMatches, int matchIndex)
        {
            var isDisabled = false;
            int dontIndex = 0;
            for (int i = 0; i < dontMatches.Count; i++)
            {

                if (matchIndex > dontMatches[i].Index)
                {
                    isDisabled = true;
                    dontIndex = dontMatches[i].Index;
                }

            }
            for (int j = 0; j < doMatches.Count; j++)
            {
                if (doMatches[j].Index > dontIndex && matchIndex > doMatches[j].Index)
                {
                    isDisabled = false;
                }
            }
            return isDisabled;
        }

        public override int Part2()
        {
            int total = 0;
            total += FindMultiplyCommandsPart2(Program);
            return total;
        }
    }
}