using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] Map = File.ReadAllLines("Map.txt");
            int modFactor = Map[0].Length;


            int yPos = 0;
            UInt64 treeCount = 0;
            
            for (int xCount = 0; xCount < Map.Length; xCount++)
            {
              //  Console.WriteLine("checking " + xCount + "," + (yPos));

               
                if (Map[xCount][yPos] == '#')
                {
                    
                    treeCount++;
                }
                yPos = (yPos + 3) % modFactor;
            }
            Console.WriteLine(treeCount);
          //  Console.ReadLine();

            int[,] checks = { { 1, 1 }, { 3, 1 }, { 5, 1 }, { 7, 1 }, { 1, 2 } };
            yPos = 0;
            UInt64 treeMult = 1;
            int checkLength = checks.GetLength(0);
            for (int runCount = 0; runCount < checkLength; runCount++)
            {
                treeCount = 0;
                yPos = 0;
                int xChange = checks[runCount, 1];
                int yChange = checks[runCount, 0];
                Console.WriteLine("right + " + yChange + " down " + xChange);
                for (int xCount = 0; xCount < Map.Length; xCount+=xChange)
                {
                 // Console.WriteLine("checking " + xCount + "," + (yPos));


                    if (Map[xCount][yPos] == '#')
                    {
                        treeCount++;
                    }
                    yPos = (yPos + yChange) % modFactor;
                }
                treeMult *= treeCount;
                Console.WriteLine("tree count for run = " + treeCount);
            }
           
            Console.WriteLine(treeMult);
            Console.ReadLine();
        }
    }
}
