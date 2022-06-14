using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordle
{
    public static class DictionaryCheck
    {
        public static void CreateCopyOf5LetterWords()
        {
            StreamReader reader = new StreamReader(new FileStream(@"..\..\words_alpha.txt", FileMode.Open), Encoding.Default);
            StreamWriter writer = new StreamWriter(new FileStream(@"..\..\5LetterWordsOnly.txt", FileMode.Create), Encoding.Default);

            while (!reader.EndOfStream)
            {
                string word = reader.ReadLine();

                if (word.Length == 5)
                {
                    writer.WriteLine(word);
                }
            }
            writer.Close();
            reader.Close();
        }

        public static List<string> test()
        {
            List<string> GoodWords = new List<string>();
            StreamReader reader = new StreamReader(new FileStream(@"..\..\5LetterWordsOnly.txt", FileMode.Open), Encoding.Default);

            while (!reader.EndOfStream)
            {
                GoodWords.Add(reader.ReadLine());
            }
            reader.Close();

            return GoodWords;
        }

        public static List<string> WordleSearch(string LettersInPlace, List<List<string>> LettersNotInPlace, string LettersNotInWord)
        {
            List<string> GoodWords = new List<string>();
            StreamReader reader = new StreamReader(new FileStream(@"..\..\5LetterWordsOnly.txt", FileMode.Open), Encoding.Default);

            while (!reader.EndOfStream)
            {
                string SearchedWord = reader.ReadLine();

                if (ThereAreNoBadLettersInTheWord(SearchedWord, LettersNotInWord) && LettersInPlaceMatch(SearchedWord, LettersInPlace) && LettersNotInPlaceMatch(SearchedWord, LettersNotInPlace))
                {
                    GoodWords.Add(SearchedWord);
                }
            }

            if (GoodWords.Count == 0)
            {
                GoodWords.Add("There were no words found, with the specified details.");
            }

            reader.Close();
            return GoodWords;
        }

        private static bool LettersNotInPlaceMatch(string searchedWord, List<List<string>> lettersNotInPlace)
        {
            for (int i = 0; i < searchedWord.Length; i++)
            {
                int j = 0;
                while (j < lettersNotInPlace.Count)
                {
                    if (lettersNotInPlace[j].Count > 0)
                    {
                        if (i==j)
                        {
                            int k = 0;
                            while (k < lettersNotInPlace[j].Count)
                            {
                                if (lettersNotInPlace[j][k].ToLower() == searchedWord[i].ToString().ToLower())
                                {
                                    return false;
                                }

                                k++;
                            }
                        }
                        else
                        {
                            int k = 0;
                            while (k < lettersNotInPlace[j].Count)
                            {
                                if (!searchedWord.Contains(lettersNotInPlace[j][k]))
                                {
                                    return false;
                                }
                                k++;
                            }
                        }
                    }

                    j++;
                }
            }

            return true;
        }

        private static bool LettersInPlaceMatch(string searchedWord, string lettersInPlace)
        {
            for (int i = 0; i < lettersInPlace.Length; i++)
            {
                if (lettersInPlace[i] != ' ' && searchedWord[i] != lettersInPlace[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ThereAreNoBadLettersInTheWord(string searchedWord, string lettersNotInWord)
        {
            if (lettersNotInWord.Length > 0)
            {
                int i = 0;
                while (i < searchedWord.Length && !lettersNotInWord.Contains(searchedWord[i]))
                {
                    i++;
                }

                return i == searchedWord.Length;
            }
            else
            {
                return true;
            }
        }

        /*public static bool IsThisAWord(string word)
        {
            StreamReader reader = new StreamReader(new FileStream(@"..\..\5LetterWordsOnly.txt", FileMode.Open), Encoding.Default);

            bool FoundIT = false;

            while (!reader.EndOfStream && !FoundIT)
            {
                FoundIT = reader.ReadLine() == word;
            }

            return !reader.EndOfStream;
        }*/
    }
}
