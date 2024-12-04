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


        private static int HorizontalMatches(char[][] wordsearch, int lineIndex, int letterIndex, string word)
        {
            var matches = 1;
            for (int i = 0; i < word.Length; i++)
            {
                if (wordsearch[lineIndex].Length <= letterIndex + i || letterIndex + i < 0)
                {
                    matches--;
                    break;
                }

                if (wordsearch[lineIndex][letterIndex + i] != word[Math.Abs(i)])
                {
                    matches--;
                    break;
                }
            }

            matches++;

            for (int i = 0; i > -word.Length; i--)
            {
                if (wordsearch[lineIndex].Length <= letterIndex + i || letterIndex + i < 0)
                {
                    matches--;
                    break;
                }

                if (wordsearch[lineIndex][letterIndex + i] != word[Math.Abs(i)])
                {
                    matches--;
                    break;
                }
            }

            return matches;
        }


        private static int VerticalMatches(char[][] wordsearch, int lineIndex, int letterIndex, string word)
        {
            var matches = 1;
            for (int i = 0; i < word.Length; i++)
            {
                if (wordsearch.Length <= lineIndex + i || lineIndex + i < 0 ||
                    wordsearch[lineIndex + i].Length <= letterIndex)
                {
                    matches--;
                    break;
                }

                if (wordsearch[lineIndex + i][letterIndex] != word[Math.Abs(i)])
                {
                    matches--;
                    break;
                }
            }

            matches++;

            for (int i = 0; i > -word.Length; i--)
            {
                if (wordsearch.Length <= lineIndex + i || lineIndex + i < 0 ||
                    wordsearch[lineIndex + i].Length <= letterIndex)
                {
                    matches--;
                    break;
                }

                if (wordsearch[lineIndex + i][letterIndex] != word[Math.Abs(i)])
                {
                    matches--;
                    break;
                }
            }

            return matches;
        }

        private static int DiagonalMatches(char[][] wordsearch, int lineIndex, int letterIndex, string word)
        {
            var matches = 1;
            // down right
            for (int i = 0; i < word.Length; i++)
            {
                if (lineIndex + i < 0 || letterIndex + i < 0 || wordsearch.Length <= i + lineIndex ||
                      wordsearch[i + lineIndex].Length <= i + letterIndex)
                {
                    matches--;
                    break;
                }

                if (wordsearch[i + lineIndex][i + letterIndex] != word[Math.Abs(i)])
                {
                    matches--;
                    break;
                }
            }

            matches++;
            // up left
            for (int i = 0; i < word.Length; i++)
            {
                if (lineIndex + i < 0 || letterIndex - i < 0 || wordsearch.Length <= i + lineIndex ||
                      letterIndex + i < 0)
                {
                    matches--;
                    break;
                }

                if (wordsearch[i + lineIndex][letterIndex - i] != word[Math.Abs(i)])
                {
                    matches--;
                    break;
                }
            }

            matches++;
            // up right
            for (int i = 0; i < word.Length; i++)
            {
                if (letterIndex + i < 0 || lineIndex - i < 0 || wordsearch.Length <= lineIndex - i ||
                lineIndex + i < 0 ||
                letterIndex + i >= wordsearch[lineIndex - i].Length)
                {
                    matches--;
                    break;
                }

                if (wordsearch[lineIndex - i][i + letterIndex] != word[Math.Abs(i)])
                {
                    matches--;
                    break;
                }
            }

            matches++;
            
            // down left
            for (int i = 0; i < word.Length; i++)
            {
                if (letterIndex - i < 0 || lineIndex - i < 0 || wordsearch.Length <= lineIndex - i ||
                    lineIndex - i < 0 ||
                    letterIndex - i >= wordsearch[lineIndex - i].Length)
                {
                    matches--;
                    break;
                }

                if (wordsearch[lineIndex - i][letterIndex - i] != word[Math.Abs(i)])
                {
                    matches--;
                    break;
                }
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