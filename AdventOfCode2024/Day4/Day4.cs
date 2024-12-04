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
            if (CheckDirection(wordsearch, lineIndex, letterIndex, word, 0, 1))
            {
                matches++;
            }
            if (CheckDirection(wordsearch, lineIndex, letterIndex, word, 0, -1))
            {
                matches++;
            }

            return matches;
        }


        private int VerticalMatches(char[][] wordsearch, int lineIndex, int letterIndex, string word)
        {
            var matches = 0;
            if (CheckDirection(wordsearch, lineIndex, letterIndex, word, 1, 0))
            {
                matches++;
            }
            if (CheckDirection(wordsearch, lineIndex, letterIndex, word, -1, 0))
            {
                matches++;
            }

            return matches;
        }

        private int DiagonalMatches(char[][] wordsearch, int lineIndex, int letterIndex, string word)
        {
            var matches = 0;
            // down right
            if (CheckDirection(wordsearch, lineIndex, letterIndex, word, 1, 1))
            {
                matches++;
            }

            // up left
            if (CheckDirection(wordsearch, lineIndex, letterIndex, word, -1, -1))
            {
                matches++;
            }

            // up right
            if (CheckDirection(wordsearch, lineIndex, letterIndex, word, -1, 1))
            {
                matches++;
            }

            // down left
            if (CheckDirection(wordsearch, lineIndex, letterIndex, word, 1, -1))
            {
                matches++;
            }

            return matches;
        }

        public override int Part1()
        {
            return WordCount("XMAS", Wordsearch);
        }

        public override int Part2()
        {
            return 0;
        }
    }
}