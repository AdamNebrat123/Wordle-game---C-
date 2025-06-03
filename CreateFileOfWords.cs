using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordleGame
{
    public class CreateFileOfWords
    {
        private static CreateFileOfWords _instance = new CreateFileOfWords();
        private static int _count;
        private string newFileOfWordsByLength;
        private string _theWord;
        private int _lengthOfWord;
        private CreateFileOfWords() 
        {
        }
        public static CreateFileOfWords CreateInstance()
        {
            return _instance ;
        }
        public int GetCount()
        {
            return _count;
        }
        public string ChooseRandomWord()
        {
            StreamReader reader = CreateStream.CreateStreamReader(newFileOfWordsByLength);
            Random random = new Random();
            int randomPositionInFile = random.Next(0, _count) * (_lengthOfWord + 2);
            reader.BaseStream.Seek(randomPositionInFile, SeekOrigin.Begin);

            char[] buffer = new char[_lengthOfWord];
            reader.Read(buffer, 0, buffer.Length);
            Console.WriteLine();
            string word = new string(buffer, 0, buffer.Length);
            _theWord = word;
            reader.Dispose();
            return _theWord;
        }
        public void CreateFileOfWordsByLength(string AllEnglishWordsFilePath,string EnglishWordsByLengthFilePath, int length)
        {
            /*
             * the method CreateFileOfWordsByLength gets three paramters:
             * string AllEnglishWordsFilePath: a path to the file with all english words (NOT BY LENGTH)
             * string EnglishWordsByLengthFilePath: a path to the file with all english words with a specific length
             * int length: the specific length of the word that will be in EnglishWordsByLengthFilePath
             */
            _count = 0;
            newFileOfWordsByLength = EnglishWordsByLengthFilePath;
            _lengthOfWord = length;
            StreamReader reader = CreateStream.CreateStreamReader(AllEnglishWordsFilePath);
            StreamWriter writer = CreateStream.CreateStreamWriter(newFileOfWordsByLength, false);
            string currentLine ;
            while ((currentLine = reader.ReadLine()) != null) // Read line by line
            {
                if (currentLine.Length == _lengthOfWord) // Check if the line length is exactly 5
                {
                    writer.WriteLine(currentLine); // Write the valid line to destination file
                    _count++;
                }
            }
            reader.Dispose();
            writer.Dispose();
        }
    }
}
