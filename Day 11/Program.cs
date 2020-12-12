using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Seats = File.ReadAllLines("Seats.txt");

            char[,] SeatArray = new char[Seats.Length, Seats[0].Length];
            char[,] SeatArrayB = new char[Seats.Length, Seats[0].Length];

            for (int rowCount = 0; rowCount < Seats.Length; rowCount++)
            {
                for (int columnCount = 0; columnCount < Seats[0].Length; columnCount++)
                {
                    SeatArrayB[rowCount, columnCount] = Seats[rowCount][columnCount];
                }
            }

           
            ShowSeats(SeatArrayB);
            do
            {
                Array.Copy(SeatArrayB, SeatArray, Seats.Length * Seats[0].Length);
                for (int rowCount = 0; rowCount < Seats.Length; rowCount++)
                {
                    for (int columnCount = 0; columnCount < Seats[0].Length; columnCount++)
                    {
                        switch (SeatArray[rowCount, columnCount])
                        {
                            case ('L'):
                                if (CountSeats(SeatArray, rowCount, columnCount, '#') == 0)
                                {
                                    SeatArrayB[rowCount, columnCount] = '#';
                                }
                                break;
                            case ('#'):
                                if (CountSeats(SeatArray, rowCount, columnCount, '#') > 4)
                                {
                                    SeatArrayB[rowCount, columnCount] = 'L';
                                }
                                break;
                        }
                    }
                }
                
               // ShowSeats(SeatArrayB);

            } while (!SameArray(SeatArray, SeatArrayB));

            int OccupiedCount = 0;
            for (int rowCount = 0; rowCount < Seats.Length; rowCount++)
            {
                for (int columnCount = 0; columnCount < Seats[0].Length; columnCount++)
                {
                    if (SeatArray[rowCount, columnCount] == '#')
                    {
                        OccupiedCount++;
                    }
                }
            }
            Console.WriteLine(OccupiedCount);
            Console.ReadLine();
        }

        private static bool SameArray(char[,] seatArray, char[,] seatArrayB)
        {
            for (int rowCount = 0; rowCount < seatArray.GetLength(0); rowCount++)
            {
                for (int columnCount = 0; columnCount < seatArray.GetLength(1); columnCount++)
                {
                   if(seatArray[rowCount, columnCount] != seatArrayB[rowCount, columnCount])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static void ShowSeats(char[,] seatArray)
        {
            for (int rowCount = 0; rowCount < seatArray.GetLength(0); rowCount++)
            {
                string row = "";
                for (int columnCount = 0; columnCount < seatArray.GetLength(1); columnCount++)
                {
                    row += seatArray[rowCount, columnCount];
                }
                Console.WriteLine(row);
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        [System.Diagnostics.DebuggerNonUserCode]
        private static char FindSeat(char[,] seatArray, int row, int column, int rowDiff, int colDiff)
        {
            try
            {
                while (true)
                {
                    row += rowDiff;
                    column += colDiff;

                    if(seatArray[row, column] == 'L' || seatArray[row, column] == '#')
                    {
                        return seatArray[row, column];
                    }
                }
            }
            catch (Exception e)
            {
                return ' ';
            }
        }
        private static int CountSeats(char[,] seatArray, int row, int column, char seat)
        {

            int count = 0;
            if (FindSeat(seatArray, row, column, -1, -1) == seat)
            {
                count++;
            }
            if (FindSeat(seatArray, row, column, -1, 0) == seat)
            {
                count++;
            }
            if (FindSeat(seatArray, row, column, -1, +1) == seat)
            {
                count++;
            }

            if (FindSeat(seatArray, row, column, 0, -1) == seat)
            {
                count++;
            }
            if (FindSeat(seatArray, row, column, 0, +1) == seat)
            {
                count++;
            }

            if (FindSeat(seatArray, row, column, +1, -1) == seat)
            {
                count++;
            }
            if (FindSeat(seatArray, row, column, +1, 0) == seat)
            {
                count++;
            }
            if (FindSeat(seatArray, row, column, +1, +1) == seat)
            {
                count++;
            }
            /*
            if (row > 0 && column > 0)
            {
                if (seatArray[row - 1, column - 1] == seat)
                {
                    count++;
                }
            }
            if(row > 0)
            {
                if (seatArray[row - 1, column] == seat)
                {
                    count++;
                }
            }
            if(row > 0 && column < seatArray.GetLength(1) - 1)
            {
                if (seatArray[row - 1, column + 1] == seat)
                {
                    count++;
                }
            }

            if (column > 0)
            {
                if (seatArray[row, column - 1] == seat)
                {
                    count++;
                }
            }

            if (column < seatArray.GetLength(1) - 1)
            { 
                if (seatArray[row, column + 1] == seat)
                {
                    count++;
                }
            }

            if (column > 0 && row < seatArray.GetLength(0) - 1)
            {
                if (seatArray[row + 1, column - 1] == seat)
                {
                    count++;
                }
            }
            if (row < seatArray.GetLength(0) - 1)
            {
                if (seatArray[row + 1, column] == seat)
                {
                    count++;
                }
            }
            if (column < seatArray.GetLength(1) -1 && row < seatArray.GetLength(0) - 1)
            {
                if (seatArray[row + 1, column + 1] == seat)
                {
                    count++;
                }
            }*/
            return count;
        }

       
    }
}
