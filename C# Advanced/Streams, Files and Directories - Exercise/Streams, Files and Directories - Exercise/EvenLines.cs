using System;
using System.IO;
using System.Linq;

namespace Streams__Files_and_Directories___Exercise
{
    class EvenLines
    {
        static void Main(string[] args)
        {
            string path = "New folder";
            string fileName = "text.txt";
            string filePath = Path.Combine(path, fileName);
            int counter = 0;
            using (var reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    var output = string.Empty;
                    var input = line.Split().ToArray().Reverse().ToList();
                    for (int i = 0; i < input.Count; i++)
                    {
                        var ch = input[i].ToCharArray().ToList(); ;
                        for (int j = 0; j < ch.Count(); j++)
                        {
                            if (ch[j] == '.'
                                || ch[j] == '-'
                                || ch[j] == ','
                                || ch[j] == '!'
                                || ch[j] == '?')
                            {
                                ch[j] = '@';

                            }
                            output += ch[j];
                        }
                        output += " ";
                    }
                    if (counter % 2 == 0)
                    {
                        Console.WriteLine(string.Join(" ", output));
                    }
                    counter++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}
