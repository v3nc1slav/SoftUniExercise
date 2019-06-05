using System;
using System.IO;
using System.Linq;

namespace Streams__Files_and_Directories___Exercise
{
    class EvenLines
    {
        static void Main(string[] args)
        {
            string fileName = "text.txt";
            string outputName = "output.txt";
            var line = File.ReadAllLines(fileName);
            int counte = 0;
            foreach (var item in line)
            {
                int counterLetters = item.Count(char.IsLetter);
                int counterMarks = item.Count(char.IsPunctuation);

                File.AppendAllText(outputName,
                    $"Line {++counte}: {item} ({counterLetters}) ({counterMarks})" +
                    $"{Environment.NewLine}");
            }
        }
    }
}
