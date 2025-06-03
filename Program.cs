using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace wordleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();
            Console.WriteLine("welcome to Adam's wordle game!");
            while (true)
            {
                Console.WriteLine("enter the lentgh of the word you want to guess: ");
                int lengthOfWord = int.Parse(Console.ReadLine());

                CreateFileOfWords createFileOfWords = CreateFileOfWords.CreateInstance();
                createFileOfWords.CreateFileOfWordsByLength("AllEnglishWords.txt", "AllEnglishWordsByLength.txt", lengthOfWord); //create the file of word by lenght
                createFileOfWords.CreateFileOfWordsByLength("CommonEnglishWords.txt", "CommonEnglishWordsByLength.txt", lengthOfWord); //create the file of commom word by lenght
                string theTrueWord = createFileOfWords.ChooseRandomWord(); // The word that need to be guessed

                Console.WriteLine("enter the max num of guesses: ");
                int maxNumOfGuess = int.Parse(Console.ReadLine());


                StartGame(lengthOfWord, maxNumOfGuess, theTrueWord, "AllEnglishWordsByLength.txt");
            }


        }
        public static void StartGame(int lengthOfWord, int maxNumOfGuess, string theRealWord, string newFileOfWordsByLength)
        {
            int countOfGuesses = 0;
            string currentWordGuessed;
            GuessedWordHandler guessedWordHandler = new GuessedWordHandler(newFileOfWordsByLength);
            while(countOfGuesses != maxNumOfGuess)
            {
                Console.WriteLine("Guess the word: ");
                currentWordGuessed = Console.ReadLine();
                if (currentWordGuessed.Length != lengthOfWord)
                {
                    Console.Write("The word must contain only {0} letters. ", lengthOfWord);
                    continue;
                }
                if (guessedWordHandler.IsExists(currentWordGuessed))
                {
                    guessedWordHandler.ColorTheWord(currentWordGuessed, theRealWord);
                    Console.WriteLine();
                    countOfGuesses++;
                    if (currentWordGuessed == theRealWord)
                    {
                        Console.WriteLine("Correct! Good Job!");
                        Console.WriteLine("The num of guesses you guessed: " + countOfGuesses);
                        break;
                    }
                }
                else if (!guessedWordHandler.IsExists(currentWordGuessed))
                {
                    Console.Write("there is no such a word. ");
                    continue;
                }
                if(countOfGuesses == maxNumOfGuess)
                    Console.WriteLine("Oh no! You are out of gusses...  :(");
            }
            Console.WriteLine("The Word was: " + theRealWord);
        }
        
    }
}
