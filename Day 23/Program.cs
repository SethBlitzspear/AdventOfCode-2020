using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_23
{
    class Program
    {

        public class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }

        public static Node currentCup = null, lastCup = null, firstCup = null;

        static void AddNode(int val)
        {
            if(currentCup == null)
            {
                currentCup = new Node() { Value = val };
                lastCup = currentCup;
                firstCup = currentCup;
            }
            else
            {
                lastCup.Next = new Node { Value = val };
                lastCup = lastCup.Next;
                lastCup.Next = firstCup;
            }
        }
        static void Main(string[] args)
        {
            bool pt2 = true;
            bool tenrounds = false;

            int rounds, maxCup;
            if (pt2)
            {
                maxCup = 1000000;
                rounds = 10000000;
            }
            else
            {
                maxCup = 9;
                rounds = 100;
            }
            if(tenrounds)
            {
                rounds = 10;
            }
            string RawCups = "198753462";

            DateTime now = DateTime.Now;
            

            foreach (char cup in RawCups)
            {
                
                AddNode(Convert.ToInt32(cup.ToString()));
            }
            if (pt2)
            {
                for (int extraCups = 10; extraCups <= 1000000; extraCups++)
                {
                    AddNode(extraCups);
                }
            }
            Dictionary<int, Node> ListIndex = new Dictionary<int, Node>();
            Node addCup = firstCup;
            ListIndex.Add(addCup.Value, addCup);
            
                for (int addCount = 1; addCount < maxCup; addCount++)
                {
                    addCup = addCup.Next;
                    ListIndex.Add(addCup.Value, addCup);
                }
            
         

            List<Node> removedCups = new List<Node>();
            removedCups.Capacity = 3;
            for (int moveCount = 0; moveCount < rounds; moveCount++)
            {
                int currentCupval = currentCup.Value;
                Node writeCup = firstCup;
                if (!pt2)
                {
                    Console.WriteLine(" -- Move " + (moveCount + 1) + " --");
                    Console.Write("Cups: ");
                    for (int writeCount = 0; writeCount < maxCup; writeCount++)
                    {
                        Console.Write(writeCup.Value + " ");
                        writeCup = writeCup.Next;
                    }
                    Console.WriteLine();
                    Console.WriteLine("current cup = " + currentCupval);
                }
                for (int removeCount = 0; removeCount < 3; removeCount++)
                {
                  
                   if(currentCup.Next == null)
                    {
                        removedCups.Add(firstCup);
                        firstCup = firstCup.Next;
                    }
                    else
                    {
                        removedCups.Add(currentCup.Next);
                        currentCup.Next = currentCup.Next.Next;

                    }
                }
                if (!pt2)
                {
                    Console.Write("Pick Up: ");
                    foreach (Node cup in removedCups)
                    {
                        Console.Write(cup.Value + " "); ;
                    }
                    Console.WriteLine();
                }
                int Destination = currentCupval;
                do
                {
                    if (--Destination == 0)
                    {
                        Destination = maxCup;
                    }
                } while (removedCups.FindIndex(x => x.Value == Destination) != -1);

                Node DestinationLocation = ListIndex[Destination];
                if (!pt2)
                {
                    Console.WriteLine("Destination: " + Destination);
                }
                for (int removeCount = 0; removeCount < 3; removeCount++)
                {
                    removedCups[removeCount].Next = DestinationLocation.Next;
                    DestinationLocation.Next = removedCups[removeCount];
                    DestinationLocation = removedCups[removeCount];

                }
                removedCups.Clear();
                currentCup = currentCup.Next;
                if (!pt2)
                {
                    Console.WriteLine();
                }
            }

            Node find1 = ListIndex[1];
            if (!pt2)
            {
                for (int answerCount = 0; answerCount < 8; answerCount++)
                {
                    find1 = find1.Next;
                    Console.Write(find1.Value);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(find1.Next.Value);
                Console.WriteLine(find1.Next.Next.Value);
                UInt64 answer = (UInt64)find1.Next.Value * (UInt64)find1.Next.Next.Value;
                Console.WriteLine(answer);
            }
            Console.WriteLine((DateTime.Now.Ticks - now.Ticks) / 10000);
            
            Console.ReadLine();

        }
    }
}
