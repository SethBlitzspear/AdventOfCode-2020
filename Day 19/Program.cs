using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_19
{
    class Program
    {
        static int pre = 0;
        static Dictionary<string, string> rules = new Dictionary<string, string>();
        static string ruleA = "", ruleB = "";
        static void Main(string[] args)
        {
            string[] MessageData = File.ReadAllLines("Messages.txt");

            List<string> messages = new List<string>();

            foreach (string line in MessageData)
            {
                
                if (line != "" && (line[0] == 'a' || line[0] == 'b'))
                {
                    messages.Add(line);
                }
                else if (line != "")
                {
                    rules.Add(line.Split(':')[0], line.Split(':')[1]);
                    if (line.Split(':')[1][2] == 'a')
                    {
                        ruleA = line.Split(':')[0];
                    }
                    if (line.Split(':')[1][2] == 'b')
                    {
                        ruleB = line.Split(':')[0];
                    }
                }

            }
            int acceptCount = 0;

            foreach (string message in messages)
            {
                string newMessage = "";
                if (AcceptMessage(message, rules["0"], out newMessage, true))
                {
                    if (newMessage == "")
                    {
                        acceptCount++;
                        Console.WriteLine("Accepted " + message);
                    }
                    else
                    {
                        Console.WriteLine("Rejected " + message + " as " + newMessage + " left over");
                    }
                }
                else
                {
                    Console.WriteLine("Rejected " + message);
                }
            }
            Console.WriteLine(acceptCount);
            rules["8"] = "42 | 42 8";
            rules["11"] = "42 31 | 42 11 31";

             acceptCount = 0;

            foreach (string message in messages)
            {
                string newMessage = "";
                if (AcceptMessage(message, rules["0"],  out newMessage, true))
                {
                    if (newMessage == "")
                    {
                        acceptCount++;
                        Console.WriteLine("Accepted " + message);
                    }
                    else
                    {
                        Console.WriteLine("Rejected " + message + " as " + newMessage + " left over");
                    }
                }
                else
                {
                    Console.WriteLine("Rejected " + message);
                }
            }
            Console.WriteLine(acceptCount);
            Console.ReadLine();
        }
         static void Display(string message)
        {
            string displayMessage = "";
            for (int preAdd = 0; preAdd<pre; preAdd++)
			{
                displayMessage += ".";
			}
            displayMessage += message;
            Console.WriteLine(displayMessage);
        }

        private static bool AcceptMessage(string message, string rule, out string newMessage, bool fromFront)
        {
            pre++;
            newMessage = message;
            Display("trying " + message + " with " + rule + (fromFront?" Forwards":" Backwards"));
            string[] localRules = rule.Split('|');
            bool ret = false;


            foreach (string tryRulesRaw in localRules)
            {
                
                if (!ret)
                {
                    Display("Option " + message + " with " + tryRulesRaw);
                    newMessage = message;
                    string loopMessage = message;
                    bool tryrules = true;

                    string tryRule = tryRulesRaw.Trim();
                    string[] subRules = tryRule.Split(' ');
                    int[] order;
                    if(subRules.Length == 2)
                    {
                        if (fromFront)
                        {
                            order = new int[] { 0, 1};
                        }
                        else
                            {
                            order = new int[] { 1, 0 };
                        }
                    }
                    else if (subRules.Length == 3)
                    {
                        if (fromFront)
                        {
                            order = new int[] { 0, 1, 2 };
                        }
                        else
                        {
                            order = new int[] {2, 1, 0 };
                        }
                    }
                    else
                    {
                        order = new int[] { 0 };
                    }

                    foreach (int ruleCount in order)
                    {
                        string subRule = subRules[ruleCount];
                        Display("Applying Rule " + subRule + " on " + newMessage);
                        if (tryrules)
                        {
                            if (newMessage == "")
                            {
                                Display("run out of message!");
                                tryrules = false;
                            }
                            else
                            {
                                if (subRule == ruleA)
                                {
                                    if (newMessage[fromFront?0:newMessage.Length - 1] == 'a')
                                    {
                                        newMessage = newMessage.Substring(fromFront?1:0, newMessage.Length - 1);
                                    }
                                    else
                                    {
                                        Display("failing as message " + newMessage + " doesn't start with an a");
                                        tryrules = false;
                                    }
                                }
                                else if (subRule == ruleB)
                                {
                                    if (newMessage[fromFront ? 0 : newMessage.Length - 1] == 'b')
                                    {
                                        newMessage = newMessage.Substring(fromFront ? 1 : 0, newMessage.Length - 1);
                                    }
                                    else
                                    {
                                        Display("failing as message " + newMessage + " doesn't start with a b");
                                        tryrules = false;
                                    }
                                }
                                else
                                {
                                    string passRule = rules[subRule];
                                    Display("Rule " + subRule + " -> " + passRule);
                                    string backMessage = "";
                                    bool direction = (ruleCount == 2 && order.Length == 3) ? false : fromFront;
                                    if (AcceptMessage(newMessage, passRule, out backMessage, true))
                                    {
                                        newMessage = backMessage;
                                    }
                                    else
                                    {
                                        tryrules = false;
                                        Display("Rule " + passRule + " failed " + newMessage);
                                    }
                                }
                            }
                        }
                    }


                    if (tryrules)
                    {
                        Display("This one works");
                        ret = true;
                    }


                }
                else
                {

                    Display("Skipping " + tryRulesRaw + " as previous worked");
                }
            }
            pre--;
            if(!ret)
            {

                newMessage = message;
            }
            return ret;
        }
    }
}

/*Display("");
                    Display("Trying " + loopMessage + " with "  + tryRuleRaw);
                    string tryRule = tryRuleRaw.Trim();
                    string[] subRules = tryRule.Split(' ');
                    int numRules = subRules.Length;

                    if (numRules == 2)
                    {
                        if (loopMessage.Length == 1)
                        {
                            Display("Not enough message for 2 rules");
                            tryrules = false;
                        }
                        else
                        {
                            if (subRules[0] == ruleA || subRules[0] == ruleB)
                            {
                                if (subRules[0] == ruleA && loopMessage[0] != 'a')
                                {
                                    tryrules = false;
                                    Display("failing as message " + loopMessage + " doesn't start with an a");
                                }
                                else if (subRules[0] == ruleB && loopMessage[0] != 'b')
                                {
                                    tryrules = false;
                                    Display("failing as message " + loopMessage + " doesn't start with a b");
                                }
                                else
                                {
                                    Display("first character " + loopMessage[0] + " matches rule " + subRules[0]);
                                }
                                loopMessage = loopMessage.Substring(1, loopMessage.Length - 1);
                              
                            }
                             if (subRules[1] == ruleA || subRules[1] == ruleB)
                            {
                                if (subRules[1] == ruleA && loopMessage[loopMessage.Length - 1] != 'a')
                                {
                                    tryrules = false;
                                    Display("failing as message " + loopMessage + " doesn't end with an a");
                                }
                                else if (subRules[1] == ruleB && loopMessage[loopMessage.Length - 1] != 'b')
                                {
                                    tryrules = false;
                                    Display("failing as message " + loopMessage + " doesn't end with a b");
                                }
                                else
                                {
                                    Display("last character " + loopMessage[loopMessage.Length - 1] + " matches rule " + subRules[1]);
                                }
                                loopMessage = loopMessage.Substring(0, loopMessage.Length - 1);
                                
                            }
                            if(tryrules)
                            {
                                if ((subRules[0] == ruleA || subRules[0] == ruleB) && (subRules[1] == ruleA || subRules[1] == ruleB))
                                {
                                    if (loopMessage.Length > 0)
                                    {
                                        Display("Message " + loopMessage + " left with no rules!");
                                        tryrules = false;
                                    }
                                    else
                                    {
                                        Display("All message accounted for.. Success!!!");
                                    }
                                }
                                else
                                {
                                    if (subRules[0] == ruleA || subRules[0] == ruleB)
                                    {
                                        string passRule = rules[subRules[1]];
                                        Display("Rule " + subRules[1] + " -> " + passRule);
                                        tryrules = AcceptMessage(loopMessage, passRule);
                                    }
                                    else if (subRules[1] == ruleA || subRules[1] == ruleB)
                                    {
                                        string passRule = rules[subRules[0]];
                                        Display("Rule " + subRules[0] + " -> " + passRule);
                                        tryrules = AcceptMessage(loopMessage, passRule);
                                    }
                                    else
                                    {


                                        if (loopMessage.Length % 2 == 0)
                                        {
                                            Display("Splitting " + loopMessage);
                                            string passRule = rules[subRules[0]];
                                            Display("Rule " + subRules[0] + " -> " + passRule);
                                            tryrules = AcceptMessage(message.Substring(0, loopMessage.Length / 2), passRule);
                                            if (tryrules)
                                            {
                                                passRule = rules[subRules[1]];
                                                Display("Rule " + subRules[1] + " -> " + passRule);
                                                tryrules = AcceptMessage(loopMessage.Substring(loopMessage.Length / 2, loopMessage.Length / 2), passRule);
                                            }
                                            else
                                            {
                                                Display("Not trying rule " + subRules[1] + " as Rule " + subRules[0] + " failed");
                                            }
                                        }
                                        else
                                        {
                                            Display("Can't equally split message");
                                            tryrules = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (numRules == 1)
                    {
                        if (subRules[0] == ruleA || subRules[0] == ruleB)
                        {
                            if (subRules[0] == ruleA && loopMessage[0] != 'a')
                            {
                                tryrules = false;
                                Display("failing as message " + loopMessage + " isn't an a");
                            }
                            else if (subRules[0] == ruleB && loopMessage[0] != 'b')
                            {
                                tryrules = false;
                                Display("failing as message " + loopMessage + " isn't a b");
                            }
                            else
                            {
                                Display("Base case match!");
                            }
                            
                        }
                        else
                        {
                            string passRule = rules[subRules[0]];
                            Display("Rule " + subRules[0] + " -> " + passRule);
                            tryrules = AcceptMessage(loopMessage, passRule);

                        }
                    }
                    else
                    {
                        Display("Not one or two rules???");
                        tryrules = false;
                    }
                    /*

                    int countA = subRules.Count(x => x == ruleA);
                    int countB = subRules.Count(x => x == ruleB);
                    int balance = message.Length - countA - countB;
                    int startPos = 0;
                    int ruleCount = 0;
                    int subLength = 0;
                    bool tryrules = true;
                    
                    if (numRules > countA + countB)
                    {
                        if (balance % (numRules - countA - countB) != 0)
                        {
                            fail = true;
                            Display("failing as balance is " + balance + " numRules is " + numRules + " A&B rules is " + (countA + countB));
                        }
                        subLength = balance / (numRules - countA - countB);
                    }

                    if (balance != 0 && subLength == 0)
                    {
                        Display("Balance is " + balance + " yet sublength is 0");
                        fail = true;
                    }

                    if (!fail)
                    {

                        while (startPos < message.Length && tryrules)
                        {
                            if (subRules[ruleCount] == ruleA)
                            {
                                if (message[startPos++] != 'a')
                                {
                                    Display("no a found as " + (startPos - 1) + " in " + message);
                                    tryrules = false;
                                }
                            }
                            else if (subRules[ruleCount] == ruleB)
                            {
                                if (message[startPos++] != 'b')
                                {
                                    Display("no b found as " + (startPos - 1) + " in " + message);
                                    tryrules = false;
                                }
                            }
                            else
                            {
                                string subMessage = message.Substring(startPos, subLength);
                                string passRule = rules[subRules[ruleCount]];
                                Display("Rule " + subRules[ruleCount] + " -> " + passRule);
                                if (!AcceptMessage(subMessage, passRule))
                                {
                                    tryrules = false;


                                }
                                startPos += subLength;

                            }

                            ruleCount++;



                        }
                    }
                    else
                    {
                        tryrules = false;
                    }*/

