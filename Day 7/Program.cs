using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7
{
    class Program
    {
        struct Bag
        {
            public int num;
            public string name;
        }
        static Dictionary<string, List<Bag>> BagDB = new Dictionary<string, List<Bag>>();

        static void Main(string[] args)
        {
            string[] Bags = File.ReadAllLines("Bags.txt");
            int BagCount = 0;
           

            foreach  (string bag in Bags)
            {
                int containPos = bag.IndexOf(" bags contain");
                string Bagname = bag.Substring(0, containPos);
                string[] BagArray = bag.Substring(containPos + 13).Split(',');
                List<Bag> BagList = new List<Bag>();
                if (BagArray[0] != " no other bags.")
                {
                    foreach (string item in BagArray)
                    { 
                        Bag luggage = new Bag();
                        luggage.num = Convert.ToInt32(item.Substring(1, 1));
                        if (item.Last() == 's')
                        {
                            luggage.name = item.Substring(3, item.Length - 8);

                        }
                        else if (item.Last() == 'g')
                        {
                            luggage.name = item.Substring(3, item.Length - 7);
                        }
                        else if (item.Last() == '.')
                        {
                            if (item[item.Length - 2] == 's')
                            {
                                luggage.name = item.Substring(3, item.Length - 9);
                            }
                            else
                            {
                                luggage.name = item.Substring(3, item.Length - 8);
                            }
                        }
                        BagList.Add(luggage);

                    }
                }

                BagDB.Add(Bagname, BagList);
            }

            foreach(string bag in BagDB.Keys)
            {
                if(bag != "shiny gold")
                if (ContainsBag(bag, "shiny gold"))
                {
                    BagCount++;
                }
            }

            Console.WriteLine(BagCount);

            BagCount = 0;
           
                BagCount += CountBag("shiny gold");
           
            Console.WriteLine(BagCount);
            Console.ReadLine();
        }

        private static int CountBag(string bag)
        {
            if(BagDB[bag].Count == 0)
            {
                return 1;
            }
            int BagCount = 0;
            foreach (Bag innerbag in BagDB[bag])
            {
                BagCount += innerbag.num * CountBag(innerbag.name); 
            }
            return BagCount + 1;
        }

        private static bool ContainsBag(string bag, string v)
        {
            if(bag == v)
            {
                return true;
            }
            foreach ( Bag innerbag in BagDB[bag])
            {
                if(ContainsBag(innerbag.name, v))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
