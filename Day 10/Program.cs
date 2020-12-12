using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Adapters = File.ReadAllLines("Adapters.txt");
            List<int> JoltAdapters = new List<int>();

            foreach (string adapter in Adapters)
            {
                JoltAdapters.Add(Convert.ToInt32(adapter));
            }

            JoltAdapters.Sort();
            int oneStep = 0, threeStep = 1;
            int currentJolt = 0;

            while(currentJolt < JoltAdapters.Count)
            {
                if(currentJolt ==  0)
                {
                    if (JoltAdapters[currentJolt] == 1)
                    {
                        oneStep++;
                    }
                    if (JoltAdapters[currentJolt] == 3)
                    {
                        threeStep++;
                    }
                }
                else
                {
                    if(JoltAdapters[currentJolt] - JoltAdapters[currentJolt - 1] == 1)
                    {
                        oneStep++;
                    }
                    if (JoltAdapters[currentJolt] - JoltAdapters[currentJolt - 1] == 3)
                    {
                        threeStep++;
                    }
                }
                currentJolt++;
            }
            Console.WriteLine(oneStep * threeStep);
            Console.ReadLine();
        }
    }
}
