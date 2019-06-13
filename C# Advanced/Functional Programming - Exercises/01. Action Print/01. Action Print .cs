using System;
using System.Linq;

namespace  _01._Action_Print

{
    class ActionPrint
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();
            Action<string> print = item => Console.WriteLine(item);
            for (int i = 0; i < input.Length; i++)
            {
                print(input[i]);
            }
        }
    }
}
