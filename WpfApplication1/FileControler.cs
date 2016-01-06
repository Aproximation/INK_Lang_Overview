using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class FileControler
    {
        public int rowsNumber = 0;
        public int charsNumber = 0;
        public int whiteCharsNumber = 0;
        public string longestWord = "";

        public FileControler(Stream stream)
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                while (sr.Peek() >= 0)
                {
                    var line = sr.ReadLine();
                    FindLongestWord(line);
                    whiteCharsNumber += CountWhiteChars(line); //line.Count(Char.IsWhiteSpace)
                    charsNumber += line.Count();
                    rowsNumber++;   //rows counter
                }
            }
        }

        //private void CountWords(string line)
        //{
            
        //}
                
        private int CountWhiteChars(string line)
        {
            var counter = 0;
            foreach (var c in line)
            {
                if (Char.IsWhiteSpace(c))
                {
                    counter++;
                }
            }
            return counter;
        }

        private void FindLongestWord(string line)
        {
            var splitted = line.Split(' ');
            foreach (var word in splitted)
            {
                if (word.Count() > longestWord.Count())
                {
                    longestWord = word;
                }
            }
        }
    }
}
