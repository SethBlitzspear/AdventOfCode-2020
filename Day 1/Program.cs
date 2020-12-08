using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Expenses = File.ReadAllLines("Expenses.txt");

            for (int expesesCount = 0; expesesCount < Expenses.Length - 1; expesesCount++)
            {
                for (int secondExpense = expesesCount; secondExpense < Expenses.Length; secondExpense++)
                {
                    int total = Convert.ToInt32(Expenses[expesesCount]) + Convert.ToInt32(Expenses[secondExpense]);
                    if(total == 2020)
                    {
                        Console.WriteLine(Convert.ToInt32(Expenses[expesesCount]) * Convert.ToInt32(Expenses[secondExpense]));
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
