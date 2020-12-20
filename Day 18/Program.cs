using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_18
{
    class Program
    {
        static int charPosition;
        static int depth = -1;
        static void Main(string[] args)
        {
            string[] Expressions = File.ReadAllLines("Maths.txt");

            UInt64 val, GrandTotal = 0;
            charPosition = 0;

            foreach (string expression in Expressions)
            {
                charPosition = 0;
                val = EvaluateExpression(expression);
                GrandTotal += val;
                Console.WriteLine(GrandTotal + " - " + val + " - " + expression);
              //  Console.ReadLine();
            }
            Console.WriteLine(GrandTotal);
            Console.ReadLine();
        }

        private static UInt64 EvaluateExpression(string expression)
        {
            depth += 1;
            string buf = "";
            for (int depthCount = 0; depthCount < depth; depthCount++)
            {
                buf += "   ";
            }
            UInt64 total = 0;
            UInt64 Operand1 = 0, Operand2 = 0;
            bool needOp2 = false, haveOp2 = false; ;
            char op = ' ';
            bool foundEnd = false;

            while (!foundEnd)
            {
                switch (expression[charPosition])
                {
                    case '(':
                        charPosition++;
                        if (needOp2)
                        {
//
                          //  Console.WriteLine(buf + "Goiing to expression");
                          Operand2 = EvaluateExpression(expression);
                            try
                            {
                                if (expression[charPosition + 2] == '+')
                                {
                                    Operand2 += Convert.ToUInt64(expression[charPosition + 4].ToString());
                                    charPosition += 4;
                                }
                            }
                            catch (Exception e)
                            {

                            }
                        //   Console.WriteLine(buf + "Back from expression");
                        //  Console.WriteLine(buf + "Setting oper 2 to " + Operand2);
                            haveOp2 = true;
                        }
                        else
                        {
                       //     Console.WriteLine(buf + "Goiing to expression");
                            Operand1 = EvaluateExpression(expression);
                      //      Console.WriteLine(buf + "Back from expression");
                       //    Console.WriteLine(buf + "Setting oper 1 to " + Operand1);
                            needOp2 = true;
                        }
                        charPosition--;

                        break;
                    case ')':
                        foundEnd = true;
                        break;
                    case '+':
                    case '*':
                        op = expression[charPosition];
                        break;

                    case ' ':
                        break;

                    default:
                        if (needOp2)
                        {
                            Operand2 = Convert.ToUInt64(expression[charPosition].ToString());
                            //   Console.WriteLine(buf + "Setting oper 2 to " + Operand2);
                            try
                            {
                                if (expression[charPosition + 2] == '+')
                                {
                                    Operand2 += Convert.ToUInt64(expression[charPosition + 4].ToString());
                                    charPosition += 4;
                                }
                            }
                            catch (Exception e)
                            {

                            }
                            haveOp2 = true;
                        }
                        else
                        {
                            Operand1 = Convert.ToUInt64(expression[charPosition].ToString());
                            //   Console.WriteLine(buf + "Setting oper 1 to " + Operand1);
                            needOp2 = true;
                        }
                        break;
                }
                if(haveOp2)
                {
                    switch(op)
                    {
                        case '+':
                            total = Operand1 + Operand2;
                            break;
                        case '*':
                            total = Operand1 * Operand2;
                            break;
                    }
                 //   Console.WriteLine(buf + Operand1 + " " + op + " " + Operand2 + " = " + total);
                    Operand1 = total;
                //   Console.WriteLine(buf + "Setting oper 1 to " + total);
                    needOp2 = true;
                    haveOp2 = false;
                }
                if (++charPosition >= expression.Length)
                {
                    foundEnd = true;
                }


            }
            depth -= 1;
            return total;
        }
    }
}