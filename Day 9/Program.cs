using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_9
{
    class Program
    {
        static void Main(string[] args)
        {
            UInt64 keyNumber = 0;
            int preambleLength = 25;
            string[] NumberStrings = File.ReadAllLines("Numbers.txt");
            UInt64[] Numbers = new UInt64[NumberStrings.Length];
            for (int numberCount = 0; numberCount < Numbers.Length; numberCount++)
            {
                Numbers[numberCount] = Convert.ToUInt64(NumberStrings[numberCount]);
            }

            for (int validCheck = preambleLength; validCheck < Numbers.Length; validCheck++)
            {
              //  Console.WriteLine("Find for  " + Numbers[validCheck]);
                bool isValid = false;
                for (int firstSum = validCheck - 1; firstSum > validCheck - preambleLength; firstSum--)
                {
                   // Console.WriteLine("   Checking " + Numbers[firstSum]);
                    for (int secondSum = firstSum - 1; secondSum > validCheck - preambleLength - 1; secondSum--)
                    {
                       // Console.WriteLine("      Checking " + Numbers[secondSum]);
                        if (Numbers[firstSum] + Numbers[secondSum] == Numbers[validCheck])
                        {
                            isValid = true;
                        }
                    }

                }
                if(!isValid)
                {
                    Console.WriteLine(Numbers[validCheck]);
                    keyNumber = Numbers[validCheck];

                    validCheck = Numbers.Length;
                    
                }

            }

            for (int keyCount = 0; keyCount < Numbers.Length; keyCount++)
            {
                UInt64 keySum = 0;
                int keySumFinder = keyCount + 1;

                while (keySum < keyNumber)
                {
                    keySum += Numbers[keySumFinder++];
                   // Console.WriteLine(keySum);
                }
                Console.WriteLine();
                if (keySum == keyNumber)
                {
                    UInt64 min = Numbers[keyCount + 1];
                    UInt64 max = Numbers[keyCount + 1];

                    for (int numCount = keyCount + 1; numCount < keySumFinder; numCount++)
                    {
                        if (Numbers[numCount] > max)
                        {
                            max = Numbers[numCount];
                        }
                        if (Numbers[numCount] < min)
                        {
                            min = Numbers[numCount];
                        }

                    }
                    UInt64 theKey = min + max;
                    Console.WriteLine(theKey);
                    Console.ReadLine();

                }

            }
            Console.ReadLine();

        }
    }
}
