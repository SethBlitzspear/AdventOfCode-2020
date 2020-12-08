using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 0;
            string[] Seats = File.ReadAllLines("Seats.txt");

            string[] SeatArray = new string[1024];

            foreach (string seat in Seats)
            {
                int lower = 0, upper = 127;
                for (int charCount = 0; charCount < 7; charCount++)
                {
                    if (seat[charCount] == 'F')
                    {
                        upper = (int)Math.Floor(lower + (double)(upper - lower) / 2);
                    }
                    else
                    {
                        lower = (int)Math.Ceiling(lower + (double)(upper - lower) / 2);
                    }
                }
                int left = 0, right = 7;
                for (int charCount = 7; charCount < 10; charCount++)
                {
                    if (seat[charCount] == 'L')
                    {
                        right = (int)Math.Floor(left + (double)(right - left) / 2);
                    }
                    else
                    {
                        left = (int)Math.Ceiling(left + (double)(right - left) / 2);
                    }
                }
                int SeatID = lower * 8 + left;
                SeatArray[SeatID] = seat;

                if (SeatID > max)
                {
                    max = SeatID;
                }


            }
            Console.WriteLine(max);
           

            bool searching = false;
            for (int seatCount = 0; seatCount < SeatArray.Length; seatCount++)
            {
                if(searching)
                {
                    if (SeatArray[seatCount] == null)
                    {
                        Console.WriteLine(seatCount);
                        searching = false;
                    }
                }
                else
                {
                    if (SeatArray[seatCount] != null)
                    {
                        searching = true;
                    }
                }
               

            }
            Console.ReadLine();
        }
    }
}
