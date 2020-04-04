namespace _02._Generic_Box_of_Integer
{
    using System;
    using System.Collections.Generic;

    class StarUp
    {
        static void Main(string[] args)
        {
            List<Box<int>> boxes = new List<Box<int>>();
            int n = int.Parse(Console.ReadLine());


            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(input);
                boxes.Add(box);
            }

            foreach (var boxIn in boxes)
            {
                Console.WriteLine(boxIn.ToString());
            }
        }
    }
}
