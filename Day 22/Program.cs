using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_22
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> Player1, Player2, Hand1, Hand2; 
            string[] Cards = File.ReadAllLines("Cards.txt");

            Player1 = new Queue<int>();
            Player2 = new Queue<int>();

            Queue<int> ActiveHand = null;

            foreach (string line in Cards)
            {
                if (line == "Player 1:")
                {
                    ActiveHand = Player1;
                }
                else if (line == "Player 2:")
                {
                    ActiveHand = Player2;
                }
                else if(line != "")
                {
                    ActiveHand.Enqueue(Convert.ToInt32(line));
                }

            }

            Hand1 = new Queue<int>(Player1);
            Hand2 = new Queue<int>(Player2);

            while(Player1.Count > 0 && Player2.Count > 0)
            {
                int Player1Card = Player1.Dequeue();
                int Player2Card = Player2.Dequeue();

                if(Player1Card >  Player2Card)
                {
                    Player1.Enqueue(Player1Card);
                    Player1.Enqueue(Player2Card);
                }
                else
                {
                    Player2.Enqueue(Player2Card);
                    Player2.Enqueue(Player1Card);
                }
            }

            if (Player1.Count == 0)
            {
                ActiveHand = Player2;
            }
            else
            {
                ActiveHand = Player1;
            }

            int Multiplier = ActiveHand.Count;
            int total = 0;

            while (ActiveHand.Count != 0)
            {
                total += Multiplier-- * ActiveHand.Dequeue();
            }

            Console.WriteLine(total);

            Player1 = new Queue<int>(Hand1);
            Player2 = new Queue<int>(Hand2);

            if (RecursiveCombat(Player1, Player2))
            {
                ActiveHand = Player1;
            }
            else
            {
                ActiveHand = Player2;
            }

             Multiplier = ActiveHand.Count;
             total = 0;

            while (ActiveHand.Count != 0)
            {
                total += Multiplier-- * ActiveHand.Dequeue();
            }
            Console.WriteLine(total);
            Console.ReadLine();
        }

        private static bool RecursiveCombat(Queue<int> Player1, Queue<int> Player2)
        {
            List<string> hands = new List<string>();

            while (Player1.Count > 0 && Player2.Count > 0)
            {
                string hand = "";
                foreach (int item in Player1)
                {
                    hand += Convert.ToString(item);
                }
                foreach (int item in Player2)
                {
                    hand += Convert.ToString(item);
                }


             
                if (hands.Contains(hand))
                {
                    Player2.Clear();
                }
                else
                {
                    hands.Add(hand);
                    int Player1Card = Player1.Dequeue();
                    int Player2Card = Player2.Dequeue();

                    if (Player1.Count >= Player1Card && Player2.Count >= Player2Card)
                    {
                        Queue<int> Recurse1 = new Queue<int>();
                        Queue<int> Recurse2 = new Queue<int>();
                        int[] player1Cards = Player1.ToArray();
                        int[] player2Cards = Player2.ToArray();
                        for (int cardCount = 0; cardCount < Player1Card; cardCount++)
                        {
                            Recurse1.Enqueue(player1Cards[cardCount]);
                        }
                        for (int cardCount = 0; cardCount < Player2Card; cardCount++)
                        {
                            Recurse2.Enqueue(player2Cards[cardCount]);
                        }
                        if (RecursiveCombat(Recurse1, Recurse2))
                        {
                            Player1.Enqueue(Player1Card);
                            Player1.Enqueue(Player2Card);
                        }
                        else
                        {
                            Player2.Enqueue(Player2Card);
                            Player2.Enqueue(Player1Card);
                        }
                    }

                    else if (Player1Card > Player2Card)
                    {
                        Player1.Enqueue(Player1Card);
                        Player1.Enqueue(Player2Card);
                    }
                    else
                    {
                        Player2.Enqueue(Player2Card);
                        Player2.Enqueue(Player1Card);
                    }
                }
            }

            if (Player1.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
