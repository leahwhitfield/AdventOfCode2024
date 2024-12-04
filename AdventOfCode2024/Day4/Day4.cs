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
            var matches = 0;
            var potentialVerticalMatch = true;
            var potentialHorizontalMatch = true;
            var potentialDiagonalMatch = true;
            for (int i = 0; i < word.Length; i++)
            {
                if (potentialVerticalMatch && !CheckVertical(wordsearch, lineIndex, letterIndex, word, i))
                {
                    if (!CheckVertical(wordsearch, lineIndex, letterIndex, word, -i))
                    {
                        potentialVerticalMatch = false;
                    }
                }

                if (potentialHorizontalMatch && !CheckHorizontal(wordsearch, lineIndex, letterIndex, word, i))
                {
                    if (!CheckHorizontal(wordsearch, lineIndex, letterIndex, word, -i))
                    {
                        potentialHorizontalMatch = false;
                    }
                }

                if (potentialDiagonalMatch && !CheckDiagonal(wordsearch, lineIndex, letterIndex, word, i))
                {
                    if (!CheckDiagonal(wordsearch, lineIndex, letterIndex, word, -i))
                    {
                        potentialDiagonalMatch = false;
                    }
                }
            }

            return potentialVerticalMatch ? 1 : 0 + (potentialHorizontalMatch ? 1 : 0) + (potentialDiagonalMatch ? 1 : 0);
        }


        private static bool CheckHorizontal(char[][] wordsearch, int lineIndex, int letterIndex, string word, int i)
        {
            if (wordsearch[lineIndex].Length <= letterIndex + i || letterIndex + i < 0) return false;
            return wordsearch[lineIndex][letterIndex + i] == word[Math.Abs(i)];
        }


        private static bool CheckVertical(char[][] wordsearch, int lineIndex, int letterIndex, string word, int i)
        {
            if (wordsearch.Length <= lineIndex + i || lineIndex + i < 0 ||
                wordsearch[lineIndex + i].Length <= letterIndex) return false;
            if (wordsearch[lineIndex + i][letterIndex] != word[Math.Abs(i)]) return false;
            return true;
        }

        private static bool CheckDiagonal(char[][] wordsearch, int lineIndex, int letterIndex, string word, int i)
        {
            if (!(lineIndex + i < 0 || letterIndex + i < 0 || wordsearch.Length <= i + lineIndex ||
                  wordsearch[i + lineIndex].Length <= i + letterIndex))
            {
                if (wordsearch[i + lineIndex][i + letterIndex] == word[Math.Abs(i)]) return true;
            }

            if (!(lineIndex + i < 0 || letterIndex - i < 0 || wordsearch.Length <= i + lineIndex ||
                  letterIndex + i < 0))
            {
                if (wordsearch[i + lineIndex][letterIndex - i] == word[Math.Abs(i)]) return true;
            }

            if (letterIndex + i < 0 || lineIndex - i < 0 || wordsearch.Length <= lineIndex - i || lineIndex + i < 0 ||
                letterIndex + i >= wordsearch[lineIndex - i].Length) return false;
            return wordsearch[lineIndex - i][i + letterIndex] == word[Math.Abs(i)];
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