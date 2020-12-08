using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6
{
    class Program
    {
        struct survey
        {
            public int count;
            public Dictionary<char, int> responseCounts;
        }
        static void Main(string[] args)
        {
            List<survey> responses = new List<survey>(); 
            string[] SurveyData = File.ReadAllLines("Survey.txt");
            survey response = new survey();
            response.responseCounts = new Dictionary<char, int>();
            int countResponses = 0;
            foreach (string line in SurveyData)
            {
               
                if (line == "")
                {
                    response.count = countResponses++;
                    responses.Add(response);
                    response = new survey();
                    response.responseCounts = new Dictionary<char, int>();
                    countResponses = 0;
                }
                else
                {
                    countResponses++;
                    foreach (char letter in line)
                    {
                        if (!response.responseCounts.ContainsKey(letter))
                        {
                            response.responseCounts.Add(letter, 1);
                        }
                        else
                        {
                            response.responseCounts[letter] += 1;
                        }
                    }
                }
            }
            response.count = countResponses;
            responses.Add(response);
            int respponseCount = 0;

            foreach (survey resp in responses)
            {
                respponseCount += resp.responseCounts.Keys.Count;
            }

            Console.WriteLine(respponseCount);
            respponseCount = 0;
            foreach (survey resp in responses)
            {
                int validResponses = 0;
                foreach (char key in resp.responseCounts.Keys)
                {
                    if(resp.responseCounts[key] == resp.count)
                    {
                        validResponses++;
                    }
                }
                respponseCount += validResponses;
            }
            Console.WriteLine(respponseCount);
            Console.ReadLine();

        }
    }
}
