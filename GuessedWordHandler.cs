using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace wordleGame
{
    public class GuessedWordHandler
    {
        private HashSet<string> _words;
        public GuessedWordHandler(string filePath) 
        {
            _words = new HashSet<string>();
            CreateHashTableOfWords(filePath);
        }
        private void CreateHashTableOfWords(string filePath)
        {
            StreamReader streamReader = CreateStream.CreateStreamReader(filePath);
            string currentWord;
            while ((currentWord = streamReader.ReadLine()) != null)
            {
                _words.Add(currentWord);
            }
            streamReader.Dispose();
        }
        public bool IsExists(string word)
        {
            //the function will check in the tree of exitsing word if there is a word like the guessed word
            return _words.Contains(word);
        }
        public void ColorTheWord(string currentWordGuessed, string theRealWord)
        {
            /*function that will color the every letter.
             * grey - letter does not exist. 
             * yellow - letter exists but not in the right place.
             * green - letter exists and it's in the right place.
             */

            for (int i = 0; i < currentWordGuessed.Length; i++)
            {
                if (!theRealWord.Contains(currentWordGuessed[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(currentWordGuessed[i] + " ");
                }
                else if (currentWordGuessed[i] == theRealWord[i])
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(currentWordGuessed[i] + " ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(currentWordGuessed[i] + " ");
                }
            }
            Console.ResetColor();
        }
    }
}
