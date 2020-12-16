using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_13
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] BusTimetable = File.ReadAllLines("Bus.txt");
            UInt64 earliestTime = Convert.ToUInt64(BusTimetable[0]);
            string[] Busses = BusTimetable[1].Split(',');
            UInt64[] BusTimes = new UInt64[Busses.Length];
            UInt64 bestTime = 0;
            int bestBusID = 0;
            int maxBus = 0;
            int maxBusID = 0;
            for (int BusCount = 0; BusCount < Busses.Length; BusCount++)
            {
                if (Busses[BusCount] != "x")
                {
                    if(maxBus < Convert.ToInt32(Busses[BusCount]))
                    {
                        maxBus = Convert.ToInt32(Busses[BusCount]);
                        maxBusID = BusCount;
                    }
                    BusTimes[BusCount] = ((UInt64)(earliestTime / Convert.ToUInt64(Busses[BusCount])) - 1) * Convert.ToUInt64(Busses[BusCount]);
                }
            }
                for (int BusCount = 0; BusCount < Busses.Length; BusCount++)
            {
                UInt64 busTime = BusTimes[BusCount];
                string Bus = Busses[BusCount];
                if(Bus != "x")
                {
                    while (busTime < earliestTime)
                    {
                        busTime += Convert.ToUInt64(Bus);
                    }
                    if(bestTime == 0 || busTime < bestTime)
                    {
                        bestTime = busTime;
                        bestBusID = BusCount;
                    }
                }
                BusTimes[BusCount] = busTime;
            }
            Console.WriteLine((bestTime - earliestTime) * Convert.ToUInt64(Busses[bestBusID]));

            UInt64 MagicNumber = 0;
            UInt64 N = 1;
            List<int> tries = new List<int>();

            for (int BusCount = 0; BusCount < Busses.Length; BusCount++)
            {
                if (Busses[BusCount] != "x")
                {
                    N *= Convert.ToUInt64(Busses[BusCount]);
                }
                else
                {
                    tries.Add(BusCount);
                }
            }

            foreach (int attempt in tries)
            {
                for (int BusCount = 0; BusCount < Busses.Length; BusCount++)
                {
                    if (Busses[BusCount] != "x")
                    {
                        UInt64 n = Convert.ToUInt64(Busses[BusCount]);
                        UInt64 Ni = N / n;
                        UInt64 x = 1;
                        UInt64 b = BusCount < attempt ? (UInt64)(attempt - BusCount) : n - (UInt64)(BusCount - attempt);
                        while ((x * Ni) % n != 1)
                        {
                            x++;
                        }

                        MagicNumber += Ni * x * b;
                    }

                }
                Console.WriteLine((MagicNumber % N - (UInt64)attempt));
                Console.ReadLine();

            }




        }
    }
}
