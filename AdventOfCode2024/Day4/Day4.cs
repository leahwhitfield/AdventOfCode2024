using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Day4
{
    public class Day4(bool useActual = false) : Challenge('4', useActual)
    {
        public char[][] Wordsearch { get; private set; }

        public override void LoadData()
        {
            Wordsearch = new char[Data.Count][];
            for (int i = 0; i < Data.Count; i++)
            {
                Wordsearch[i] = Data[i].ToCharArray();
            }
        }

        public int WordCount(string word, char[][] wordsearch)
        {
            int total = 0;
            for (int i = 0; i < wordsearch.Length; i++)
            {
                var line = wordsearch[i];
                for (var j = 0; j < line.Length; j++)
                {
                    var letter = line[j];
                    if (letter == word[0])
                    {
                        total += WordMatches(wordsearch, i, j, word);
                    }
                }
            }

            return total;
        }

        private int WordMatches(char[][] wordsearch, int lineIndex, int letterIndex, string word)
        {
            return VerticalMatches(wordsearch, lineIndex, letterIndex, word) +
                   HorizontalMatches(wordsearch, lineIndex, letterIndex, word) +
                   DiagonalMatches(wordsearch, lineIndex, letterIndex, word);
        }

        private bool CheckDirection(char[][] wordsearch, int lineIndex, int letterIndex, string word, int lineIncrease,
            int letterIncrease)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (letterIndex + i * letterIncrease < 0 ||
                    wordsearch.Length <= lineIndex + i * lineIncrease ||
                    lineIndex + i * lineIncrease < 0 ||
                    letterIndex + i * letterIncrease >= wordsearch[lineIndex + i * lineIncrease].Length) return false;

                if (wordsearch[lineIndex + (i * lineIncrease)][letterIndex + (i * letterIncrease)] !=
                    word[Math.Abs(i)]) return false;
            }

            return true;
        }


        private int HorizontalMatches(char[][] wordsearch, int lineIndex, int letterIndex, string word)
        {
            var matches = 0;
            if (HorizontalRightMatch(wordsearch, lineIndex, letterIndex, word)) matches++;
            if (HorizontalLeftMatch(wordsearch, lineIndex, letterIndex, word)) matches++;

            return matches;
        }


        private int VerticalMatches(char[][] wordsearch, int lineIndex, int letterIndex, string word)
        {
            var matches = 0;
            if (VerticalUpMatch(wordsearch, lineIndex, letterIndex, word)) matches++;
            if (VerticalDownMatch(wordsearch, lineIndex, letterIndex, word)) matches++;

            return matches;
        }

        private bool HorizontalRightMatch(char[][] wordsearch, int lineIndex, int letterIndex, string word)
        {
            return CheckDirection(wordsearch, lineIndex, letterIndex, word, 0, 1);
        }

        private bool HorizontalLeftMatch(char[][] wordsearch, int lineIndex, int letterIndex, string word)
        {
            return CheckDirection(wordsearch, lineIndex, letterIndex, word, 0, -1);
        }

        private bool VerticalUpMatch(char[][] wordsearch, int lineIndex, int letterIndex, string word)
        {
            return CheckDirection(wordsearch, lineIndex, letterIndex, word, 1, 0);
        }

        private bool VerticalDownMatch(char[][] wordsearch, int lineIndex, int letterIndex, string word)
        {
            return CheckDirection(wordsearch, lineIndex, letterIndex, word, -1, 0);
        }

        private bool DownRightMatch(char[][] wordsearch, int lineIndex, int letterIndex, string word)
        {
            return CheckDirection(wordsearch, lineIndex, letterIndex, word, 1, 1);
        }

        private bool DownLeftMatch(char[][] wordsearch, int lineIndex, int letterIndex, string word)
        {
            return CheckDirection(wordsearch, lineIndex, letterIndex, word, 1, -1);
        }

        private bool UpLeftMatch(char[][] wordsearch, int lineIndex, int letterIndex, string word)
        {
            return CheckDirection(wordsearch, lineIndex, letterIndex, word, -1, -1);
        }

        private bool UpRightMatch(char[][] wordsearch, int lineIndex, int letterIndex, string word)
        {
            return CheckDirection(wordsearch, lineIndex, letterIndex, word, -1, 1);
        }

        private int DiagonalMatches(char[][] wordsearch, int lineIndex, int letterIndex, string word)
        {
            var matches = 0;

            if (DownRightMatch(wordsearch, lineIndex, letterIndex, word)) matches++;

            if (UpLeftMatch(wordsearch, lineIndex, letterIndex, word)) matches++;

            if (UpRightMatch(wordsearch, lineIndex, letterIndex, word)) matches++;

            if (DownLeftMatch(wordsearch, lineIndex, letterIndex, word)) matches++;

            return matches;
        }

        public int FindCrosses(string word, char[][] wordsearch)
        {
            var total = 0;
            List<int[]> matchIndices = [];
            for (int i = 0; i < wordsearch.Length; i++)
            {
                var line = wordsearch[i];
                for (var j = 0; j < line.Length; j++)
                {
                    var letter = line[j];
                    if (letter != word[0]) continue;
                    if (UpLeftMatch(wordsearch, i, j, word))
                    {
                        int[] indices = [i - 1, j - 1];
                        if (matchIndices.Any(x => x[0] == indices[0] && x[1] == indices[1])) total++;
                        else
                        {
                            matchIndices.Add(indices);
                        }
                    }
                    if (UpRightMatch(wordsearch, i, j, word))
                    {
                        int[] indices = [i - 1, j + 1];
                        if (matchIndices.Any(x => x[0] == indices[0] && x[1] == indices[1])) total++;
                        else
                        {
                            matchIndices.Add(indices);
                        }
                    }
                    if (DownLeftMatch(wordsearch, i, j, word))
                    {
                        int[] indices = [i + 1, j - 1];
                        if (matchIndices.Any(x => x[0] == indices[0] && x[1] == indices[1])) total++;
                        else
                        {
                            matchIndices.Add(indices);
                        }
                    }

                    if (!DownRightMatch(wordsearch, i, j, word)) continue;
                    {
                        int[] indices = [i + 1, j + 1];
                        if (matchIndices.Any(x => x[0] == indices[0] && x[1] == indices[1])) total++;
                        else
                        {
                            matchIndices.Add(indices);
                        }
                    }
                }
            }

            return total;
        }

        public override int Part1()
        {
            return WordCount("XMAS", Wordsearch);
        }

        public override int Part2()
        {
            return FindCrosses("MAS", Wordsearch);
        }
    }
}