using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonInfo.Border_Control
{
    public class BorderControl : IRobots, ICitizens
    {
        List<string> ids = new List<string>();

        public void Control(string model, string id)
        {
            ids.Add(id);
        }

        public void Control(string name, string age, string id)
        {
            ids.Add(id);
        }

        public void Detained(string digitsOfFakeIds)
        {
            for (int i = 0; i < ids.Count; i++)
            {
                string detained = string.Empty;
                for (int j = ids[i].Length - digitsOfFakeIds.Length; j < ids[i].Length; j++)
                {
                    detained += ids[i][j];
                }

                if (digitsOfFakeIds==detained)
                {
                    Console.WriteLine($"{ids[i]}");
                }
            }
        }
    }
}
