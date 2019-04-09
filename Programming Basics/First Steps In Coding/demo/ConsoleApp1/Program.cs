using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            PrintDictionary();
        }

        public static void PrintDictionary()
        {
            var dicctinary = new SortedDictionary<string, List<string>>();
            var list = new List<string>();
            while (true)
            {
                var commands = Console.ReadLine().Split(new string[] { "| " }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < commands.Length; i++)
                {
                    var command = commands[i].Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries);
                    if (command[0] == "End")
                    {
                        foreach (var item in dicctinary)
                        {
                            Console.WriteLine(item.Key);
                            foreach (var kvp in item.Value.OrderByDescending(x => x.Count()))
                            {
                                Console.WriteLine($" -{kvp}");
                            }
                        }
                                return;
                    }
                    else if (command[0]== "List")
                    {
                        foreach (var item in dicctinary)
                        {
                            Console.Write($"{item.Key} ") ;
                        }
                            return;
                    }
                    if (command.Length == 1)
                    {
                        list.Add(command[0]);
                    }
                    else if (dicctinary.ContainsKey(command[0]))
                    {
                        dicctinary[command[0]].Add(command[1]);
                    }
                    else
                    {
                        dicctinary.Add(command[0], new List<string>() { { command[1] } });
                    }
                }
                
            }
            
        }
    }
}
