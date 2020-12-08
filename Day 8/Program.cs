using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] SourceCode = File.ReadAllLines("Code.txt");
            string[] backup = new string[SourceCode.Length];
            Array.Copy(SourceCode, backup, SourceCode.Length);
            List<int> executedCode = new List<int>();
            int Acc = 0;
            int PC = 0;
            int SwapPoint = -1;

            while (PC != SourceCode.Length)
            {
                

                if (executedCode.Contains(PC) || PC < 0 || PC> SourceCode.Length)
                {
                    if(PC<0)
                    {
                        Console.WriteLine("PC below 0. ACC = " + Acc);
                    }
                    else if (PC > SourceCode.Length)
                    {
                        Console.WriteLine("PC Above Code length. ACC = " + Acc);
                    }
                    else
                    {
                        Console.WriteLine("loop detected. ACC = " + Acc);
                    }
                    
                    Array.Copy(backup, SourceCode, SourceCode.Length);
                    Acc = 0;
                    executedCode.Clear();
                    PC = 0;
                    
                    bool foundSwap = false;
                    do
                    {
                        string OpToSwap = SourceCode[++SwapPoint].Substring(0, 3);
                        if (OpToSwap == "nop" || OpToSwap == "jmp")
                        {
                            foundSwap = true;
                    }
                    } while (!foundSwap);
                   if(SourceCode[SwapPoint].Substring(0, 3) == "nop")
                    {
                        SourceCode[SwapPoint] = "jmp" + SourceCode[SwapPoint].Substring(3);
                    }
                    else
                    {
                        SourceCode[SwapPoint] = "nop" + SourceCode[SwapPoint].Substring(3);
                    }
                }
                executedCode.Add(PC);
                int PCChange = 1;
                string instruction = SourceCode[PC];
                string op = instruction.Substring(0, 3);
                string sign = instruction.Substring(4, 1);
                int change = Convert.ToInt32(instruction.Substring(5));
                // Console.WriteLine(PC + ": " + instruction + ", ACC = " + Acc);

                switch (op)
                {
                    case "acc":
                        if(sign == "+")
                        {
                            Acc += change;
                        }
                        else
                        {
                            Acc -= change;
                        }
                        break;

                    case "jmp":
                        if (sign == "+")
                        {
                            PCChange = change;
                        }
                        else
                        {
                            PCChange = -change;
                        }
                        break;

                }

                PC += PCChange;
            }
            Console.WriteLine(Acc);
            Console.ReadLine();
        }
    }
}
