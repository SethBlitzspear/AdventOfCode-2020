using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_15
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] StartingNumbers = File.ReadAllLines("Numbers.txt");
            Dictionary<string, int> game = new Dictionary<string, int>();

            string[] Numbers = StartingNumbers[0].Split(',');
            int turn = 1;
            string lastNumber = "";
            bool isNew = false;
            int lastGap = 0;
            foreach (string number in Numbers)
            {
                if(!game.ContainsKey(number))
                {
                    isNew = true;
                }
                else
                {
                    lastGap = turn - game[number];
                    isNew = false;
                }
                game.Add(number, turn++);
                lastNumber = number;
            }

            for (int gameCount = game.Count + 1; gameCount <= 2020; gameCount++)
            {
                string NewNum = "0";
                if(!isNew)
                {
                    NewNum = Convert.ToString(lastGap);
                }

                if (!game.ContainsKey(NewNum))
                {
                    isNew = true;
                }
                else
                {
                    lastGap = turn - game[NewNum];
                }
                if (game.ContainsKey(NewNum))
                {
                    game[NewNum] =  turn++;
                    isNew = false;
                }
                else
                {
                    game.Add(NewNum, turn++);
                    isNew = true;
                }
                lastNumber = NewNum;
            }

            Console.WriteLine(lastNumber);
            Console.ReadLine();
        }
    }
}
