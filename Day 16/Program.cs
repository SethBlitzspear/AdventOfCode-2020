using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_16
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] TicketLines = File.ReadAllLines("Tickets.txt");
            int ticketLine = 0;

            Dictionary<string, string> TicketsCategories = new Dictionary<string, string>();

            while (TicketLines[ticketLine] != "your ticket:")
            {
                if (TicketLines[ticketLine] != "")
                {
                    string cat = TicketLines[ticketLine].Split(':')[0];
                    string restrictions = TicketLines[ticketLine].Split(':')[1].Substring(1);
                    TicketsCategories.Add(cat, restrictions);
                    
                }
                ticketLine++;
            }
            while (TicketLines[ticketLine] != "nearby tickets:")
            {
                ticketLine++;
            }
            ticketLine++;
            int errorrate = 0;
            while(ticketLine < TicketLines.Length)
            {
                string[] ticketNumbers = TicketLines[ticketLine].Split(',');
                for (int ticketItem = 0; ticketItem < ticketNumbers.Length; ticketItem++)
                {
                    if(!CheckTicketItem(TicketsCategories, ticketNumbers[ticketItem]))
                    {
                        errorrate += Convert.ToInt32(ticketNumbers[ticketItem]);
                    }
                }
                ticketLine++;
            }
            Console.WriteLine(errorrate);
            Console.ReadLine();
        }

        private static bool CheckTicketItem(Dictionary<string, string> ticketsCategories, string v)
        {
            int value = Convert.ToInt32(v);
            foreach (string key in ticketsCategories.Keys)
            {
                string[] requirements = ticketsCategories[key].Split(' ');
                int lowerBound = Convert.ToInt32(requirements[0].Split('-')[0]);
                int upperBound = Convert.ToInt32(requirements[0].Split('-')[1]);
                if(value>= lowerBound && value <= upperBound)
                {
                    return true;
                }
                lowerBound = Convert.ToInt32(requirements[2].Split('-')[0]);
                upperBound = Convert.ToInt32(requirements[2].Split('-')[1]);
                if (value >= lowerBound && value <= upperBound)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
