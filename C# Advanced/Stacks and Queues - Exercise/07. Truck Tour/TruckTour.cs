using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Truck_Tour
{
    class TruckTour

    {
        static void Main(string[] args)
        {
            PrintTruckTour();

        }

        private static void PrintTruckTour()
        {
            var numberPumps = int.Parse(Console.ReadLine());
            var queueKm = new Queue<int[]>();
            var couter = 0;
            for (int i = 0; i < numberPumps; i++)
            {
                var commanda = Console.ReadLine().Split().Select(int.Parse).ToArray();
                queueKm.Enqueue(commanda);
            }
            queueKm.Reverse();
            while (true)
            {
                var residue = 0;
                foreach (var item in queueKm)
                {
                    var lityr =item[0];
                    var km = item[1];
                    residue += lityr - km;
                    if (residue < 0)
                    {
                        queueKm.Enqueue(queueKm.Dequeue());
                        couter++;
                        break;
                    }
                }
                if (residue>=0)
                {
                    break;
                }
                
            }
            Console.WriteLine(couter);
        }
    }
}
