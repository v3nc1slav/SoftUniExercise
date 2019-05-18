using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Simple_Text_Editor
{
    class SimpleTextEditor 
    {
        static void Main(string[] args)
        {
            PrintSimpleTextEditor();
        }

        private static void PrintSimpleTextEditor()
        {
            var number = int.Parse(Console.ReadLine());
            var save = new Stack<string>();
            var input = string.Empty;
            for (int i = 0; i < number; i++)
            {
                var commanda = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var numberCommanda = int.Parse(commanda[0]);
                if (numberCommanda==1)
                {
                    save.Push(input);
                    var text = commanda[1];
                    for (int j = 0; j < text.Length; j++)
                    {
                        input += text[j];
                    }
                }
                else if (numberCommanda==2)
                {
                    var text = commanda[1];
                    var index = int.Parse(text);
                        save.Push(input);
                        for (int j = 0; j < index; j++)
                        {
                            input = input.Remove(input.Length-1);
                        }
                }
                else if (numberCommanda == 3)
                {
                    var text = commanda[1];
                    var index = int.Parse(text);
                    {
                        var output = input[index-1];
                        Console.WriteLine(output);
                    }
                }
                else if (numberCommanda == 4)
                {
                    input = save.Pop(); 
                    
                }
            }
        }
    }
}
