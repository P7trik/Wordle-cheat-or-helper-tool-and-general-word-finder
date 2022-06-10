using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordle
{

    static class DictionaryCheck
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

        public static void DeleteCopyOf5LetterWords()
        {
            File.Delete(@"..\..\5LetterWordsOnly.txt");
        }

        public static List<string> SearchTheDictionaryForTheWords(string LettersInPlace, string LettersNotInPlace, string LettersNotInWord)
        {
            List<string> GoodWords = new List<string>();
            StreamReader reader;

            if (File.Exists(@"..\..\5LetterWordsOnly.txt"))
            {
                reader = new StreamReader(new FileStream(@"..\..\5LetterWordsOnly.txt", FileMode.Open), Encoding.Default);
            }
            else
            {
                reader = new StreamReader(new FileStream(@"..\..\words_alpha.txt", FileMode.Open), Encoding.Default);
            }

            while (!reader.EndOfStream)
            {
                string word = reader.ReadLine();
                List<bool> Requirements = new List<bool>(); 
                int i = 0;
                
                while (i < word.Length && i < LettersInPlace.Length && !Requirements.Contains(false))
                {
                    if (LettersInPlace[i] != ' ')
                    {
                        if (LettersInPlace[i] == word[i])
                        {
                            Requirements.Add(true);
                        }
                        else
                        {
                            Requirements.Add(false);
                        }
                    }

                    i++;
                }

            }

            reader.Close();
            return GoodWords;
        }
    }
}
