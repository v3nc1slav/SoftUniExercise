using System;
using System.Linq;
using PersonInfo.Border_Control;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            BorderControl borderControl = new BorderControl();

            var command = Console.ReadLine().Split().ToArray();
            while (command[0] != "End")
            {
                if (command.Length ==3)
                {
                    borderControl.Control(command[0],command[1],command[2]);
                }
                else if(command.Length == 2)
                {
                    borderControl.Control(command[0], command[1]);
                }
                command = Console.ReadLine().Split().ToArray();
            }
            borderControl.Detained(Console.ReadLine());
        }
    }
}
