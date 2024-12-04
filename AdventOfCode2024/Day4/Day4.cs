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
                        if (MatchesWord(wordsearch, i, j, word)) total++;
                    }
                }
            }

            return total;
        }

        private bool MatchesWord(char[][] wordsearch, int lineIndex, int letterIndex, string word)
        {
            if (IsHorizontalMatch(wordsearch, lineIndex, letterIndex, word)) return true;
            if (IsVerticalMatch(wordsearch, lineIndex, letterIndex, word)) return true;
            if (IsDiagonalMatch(wordsearch, lineIndex, letterIndex, word)) return true;

            return false;
        }

        private bool IsHorizontalMatch(char[][] wordsearch, int lineIndex, int letterIndex, string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (wordsearch[lineIndex].Length <= letterIndex + i) return false;
                if (wordsearch[lineIndex][letterIndex + i] != word[i]) return false;
            }

            return true;
        }
        
        private bool IsVerticalMatch(char[][] wordsearch, int lineIndex, int letterIndex, string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (wordsearch.Length <= lineIndex + i) return false;
                if (wordsearch[lineIndex + i][letterIndex] != word[i]) return false;
            }

            return true;
        }
        
        private bool IsDiagonalMatch(char[][] wordsearch, int lineIndex, int letterIndex, string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (wordsearch.Length <= i + lineIndex || wordsearch[i + lineIndex].Length <= i + letterIndex) return false;
                if (wordsearch[i + lineIndex][i + letterIndex] != word[i]) return false;
            }

            return true;
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