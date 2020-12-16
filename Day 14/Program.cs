using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_14
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Masks = File.ReadAllLines("Masks.txt");

            UInt64[] RAM = new UInt64[99999];
            string Mask = "";
            UInt64 val = 0;
            UInt64 ANDBitMask = 0, ORBitMask = 0;
            foreach (string CommandLine in Masks)
            {
                string com = "";
                int loc = 0;
               
                if (CommandLine[1] == 'a')
                {
                    com = "mask";
                }
                else
                {
                    com = "mem";
                    loc = Convert.ToInt32(CommandLine.Split('[')[1].Split(']')[0]);
                    val = Convert.ToUInt64(CommandLine.Split(' ')[2]);
                }
                switch(com)
                {

                    case "mask":
                       
                            Mask = CommandLine.Split(' ')[2];
                            string ORMask = "", AndMask = "";
                            for (int bitCount = 0; bitCount < 36; bitCount++)
                            {
                                switch (Mask[bitCount])
                                {
                                case 'X':
                                        ORMask += "0";
                                        AndMask += "1";
                                        break;

                                    case '1':
                                        ORMask += "1";
                                        AndMask += "1";
                                        break;
                                    case '0':
                                        ORMask += "0";
                                        AndMask += "0";
                                        break;
                                }

                            }
                           ORBitMask = Convert.ToUInt64(ORMask, 2);
                        ANDBitMask = Convert.ToUInt64(AndMask, 2);
                        break;

                    case "mem":
                        
                        RAM[loc] = (val & ANDBitMask) | ORBitMask;
                        break;
                }

            }
            UInt64 Sum = 0;
            foreach  (UInt64 value in RAM)
            {
                Sum += value;
            }

            Console.WriteLine(Sum);
            Console.ReadLine();
        }
    }
}
