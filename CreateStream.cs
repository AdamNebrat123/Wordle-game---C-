using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordleGame
{
    public static class CreateStream
    {
        public static StreamReader CreateStreamReader(string filePath)
        {
            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            if (File.Exists(filePath))
            {
                StreamReader reader = new StreamReader(filePath);
                return reader;
            }
            throw new Exception("File does not exist.");
        }
        public static StreamWriter CreateStreamWriter(string filePath, bool isAppendMode)
        {
            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            if (File.Exists(filePath))
            {
                StreamWriter writer = new StreamWriter(filePath, isAppendMode);
                return writer;
            }
            throw new Exception("File does not exist.");

        }
    }
}
