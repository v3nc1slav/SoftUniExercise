using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Padawan_Equipment
{
    public class Program
    {
        public static void Main()
        {
            double startMoney = double.Parse(Console.ReadLine());
            double students = double.Parse(Console.ReadLine());
            double lightsabers = double.Parse(Console.ReadLine());
            double belts = double.Parse(Console.ReadLine());
            double robes = double.Parse(Console.ReadLine());
            double newRobes = Math.Truncate(students / 6);
            double newStudents = Math.Ceiling((students * 1.10));
            double finalMoney = (newStudents * lightsabers) + (students * belts) + ((students - newRobes) * robes);
            double difference = Math.Abs(startMoney - finalMoney);
            if (startMoney >= finalMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {finalMoney:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {difference:F2}lv more.");
            }
        }
    }
}