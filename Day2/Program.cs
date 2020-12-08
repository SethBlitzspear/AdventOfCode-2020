using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            string[] passwords = File.ReadAllLines("passwords.txt");
            foreach (string password in passwords)
            {
                string lowerBoundString = password.Split('-')[0];
                string rest = password.Split('-')[1];
                string upperBoundString = rest.Split(' ')[0];
                char character = rest.Split(' ')[1][0];
                string userPass = rest.Split(' ')[2];


                int lowerBound = Convert.ToInt32(lowerBoundString);
                int upperBound = Convert.ToInt32(upperBoundString);

                int charCount = 0;
                foreach(char let in userPass)
                {
                    if (let == character)
                    {
                        charCount++;
                    }
                }

                if( charCount>= lowerBound && charCount <= upperBound)
                {
                    count++;
                }

            }

            Console.WriteLine(count);
            count = 0;
            foreach (string password in passwords)
            {
                string lowerBoundString = password.Split('-')[0];
                string rest = password.Split('-')[1];
                string upperBoundString = rest.Split(' ')[0];
                char character = rest.Split(' ')[1][0];
                string userPass = rest.Split(' ')[2];


                int lowerBound = Convert.ToInt32(lowerBoundString);
                int upperBound = Convert.ToInt32(upperBoundString);


                int characterCount = 0;
                if (userPass[lowerBound - 1] == character )
                {
                    characterCount++;
                }
                if (userPass[upperBound - 1] == character )
                {
                    characterCount++;
                }
                if(characterCount == 1)
                {
                    count++;
                }

            }

            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}
