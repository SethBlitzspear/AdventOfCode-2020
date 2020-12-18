using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_17
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] ConwayCubes = File.ReadAllLines("Cubes.txt");
            int dimension = ConwayCubes[0].Length + 12;

            PartA(ConwayCubes, dimension);
            PartB(ConwayCubes, dimension);
        }

        private static void PartB(string[] ConwayCubes, int dimension)
        {
            char[,,,] Pocket = new char[dimension, dimension, dimension, dimension];
            char[,,,] NewPocket = new char[dimension, dimension, dimension, dimension];
            for (int xPos = 0; xPos < ConwayCubes.Length; xPos++)
            {
                for (int yPos = 0; yPos < ConwayCubes[0].Length; yPos++)
                {
                    Pocket[dimension / 2, dimension / 2,  xPos + 6, yPos + 6] = ConwayCubes[xPos][yPos];
                }
            }
            // ShowState(Pocket);
            for (int turn = 0; turn < 6; turn++)
            {
                for (int xPos = 0; xPos < dimension; xPos++)
                {
                    for (int yPos = 0; yPos < dimension; yPos++)
                    {
                        for (int zPos = 0; zPos < dimension; zPos++)
                        {
                            for (int wPos = 0; wPos < dimension; wPos++)
                            {
                                int aliveCount = countWSquares(Pocket, xPos, yPos, zPos, wPos);
                                if (Pocket[xPos, yPos, zPos, wPos] == '#')
                                {
                                    if (aliveCount == 2 || aliveCount == 3)
                                    {
                                        NewPocket[xPos, yPos, zPos, wPos] = '#';
                                    }
                                    else
                                    {
                                        NewPocket[xPos, yPos, zPos, wPos] = '.';
                                    }
                                }
                                else
                                {
                                    if (aliveCount == 3)
                                    {
                                        NewPocket[xPos, yPos, zPos, wPos] = '#';
                                    }
                                    else
                                    {
                                        NewPocket[xPos, yPos, zPos, wPos] = '.';
                                    }
                                }

                            }

                        }
                    }
                }
                Array.Copy(NewPocket, Pocket, dimension * dimension * dimension * dimension);
                // ShowState(Pocket);
            }

            int FinalAliveCount = 0;
            for (int xPos = 0; xPos < dimension; xPos++)
            {
                for (int yPos = 0; yPos < dimension; yPos++)
                {
                    for (int zPos = 0; zPos < dimension; zPos++)
                    {
                        for (int wPos = 0; wPos < dimension; wPos++)
                        {
                            if (Pocket[xPos, yPos, zPos, wPos] == '#')
                            {
                                FinalAliveCount++;
                            }
                        }
                       
                    }
                }
            }
            Console.WriteLine(FinalAliveCount);
            Console.ReadLine();
        }
        private static int countWSquares(char[,,,] pocket, int xPos, int yPos, int zPos, int wPos)
        {
            int aliveCount = 0;
            for (int xDiff = -1; xDiff < 2; xDiff++)
            {
                for (int yDiff = -1; yDiff < 2; yDiff++)
                {
                    for (int zDiff = -1; zDiff < 2; zDiff++)
                    {
                        for (int wDiff = -1; wDiff < 2; wDiff++)
                        {
                            if (!(xDiff == 0 && yDiff == 0 && zDiff == 0 && wDiff == 0))
                            {
                                if (checkWSquare(pocket, xPos + xDiff, yPos + yDiff, zPos + zDiff, wPos + wDiff))
                                {
                                    aliveCount++;
                                }
                            }
                        }
                       
                    }
                }
            }
            return aliveCount;
        }

        private static bool checkWSquare(char[,,,] pocket, int xPos, int yPos, int zPos, int wPos)
        {
            int dimension = pocket.GetLength(0);
            if (xPos >= 0 && xPos < dimension && yPos >= 0 && yPos < dimension && zPos >= 0 && zPos < dimension && wPos >= 0  && wPos < dimension)
            {
                if (pocket[xPos, yPos, zPos, wPos] == '#')
                {
                    return true;
                }
            }
            return false;
        }
        private static void PartA(string[] ConwayCubes, int dimension)
        {
            char[,,] Pocket = new char[dimension, dimension, dimension];
            char[,,] NewPocket = new char[dimension, dimension, dimension];
            for (int xPos = 0; xPos < ConwayCubes.Length; xPos++)
            {
                for (int yPos = 0; yPos < ConwayCubes[0].Length; yPos++)
                {
                    Pocket[dimension / 2, xPos + 6, yPos + 6] = ConwayCubes[xPos][yPos];
                }
            }
            // ShowState(Pocket);
            for (int turn = 0; turn < 6; turn++)
            {
                for (int xPos = 0; xPos < dimension; xPos++)
                {
                    for (int yPos = 0; yPos < dimension; yPos++)
                    {
                        for (int zPos = 0; zPos < dimension; zPos++)
                        {
                            int aliveCount = countSquares(Pocket, xPos, yPos, zPos);
                            if (Pocket[xPos, yPos, zPos] == '#')
                            {
                                if (aliveCount == 2 || aliveCount == 3)
                                {
                                    NewPocket[xPos, yPos, zPos] = '#';
                                }
                                else
                                {
                                    NewPocket[xPos, yPos, zPos] = '.';
                                }
                            }
                            else
                            {
                                if (aliveCount == 3)
                                {
                                    NewPocket[xPos, yPos, zPos] = '#';
                                }
                                else
                                {
                                    NewPocket[xPos, yPos, zPos] = '.';
                                }
                            }

                        }
                    }
                }
                Array.Copy(NewPocket, Pocket, dimension * dimension * dimension);
                // ShowState(Pocket);
            }

            int FinalAliveCount = 0;
            for (int xPos = 0; xPos < dimension; xPos++)
            {
                for (int yPos = 0; yPos < dimension; yPos++)
                {
                    for (int zPos = 0; zPos < dimension; zPos++)
                    {
                        if (Pocket[xPos, yPos, zPos] == '#')
                        {
                            FinalAliveCount++;
                        }
                    }
                }
            }
            Console.WriteLine(FinalAliveCount);
            Console.ReadLine();
        }

        private static void ShowState(char[,,] pocket)
        {
            int dimension = pocket.GetLength(0);
            for (int xPos = 0; xPos < dimension; xPos++)
            {
                Console.WriteLine("Slice " + xPos + " of " + dimension);
                for (int yPos = 0; yPos < dimension; yPos++)
                {
                    string line = "";
                    for (int zPos = 0; zPos < dimension; zPos++)
                    {
                        line += pocket[xPos, yPos, zPos];
                    }
                    Console.WriteLine(line);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        private static int countSquares(char[,,] pocket, int xPos, int yPos, int zPos)
        {
            int aliveCount = 0;
            for (int xDiff = -1; xDiff < 2; xDiff++)
            {
                for (int yDiff = -1; yDiff < 2; yDiff++)
                {
                    for (int zDiff = -1; zDiff < 2; zDiff++)
                    {
                        if (!(xDiff == 0 && yDiff == 0 && zDiff == 0))
                        {
                            if (checkSquare(pocket, xPos + xDiff, yPos + yDiff, zPos + zDiff))
                            {
                                aliveCount++;
                            }
                        }
                    }
                }
            }



            return aliveCount;
        }

        private static bool checkSquare(char[,,] pocket, int xPos, int yPos, int zPos)
        {
            int dimension = pocket.GetLength(0);
            if(xPos >=0 && xPos < dimension && yPos >= 0 && yPos < dimension && zPos >= 0 && zPos < dimension)
            {
                if(pocket[xPos, yPos, zPos] == '#')
                {
                    return true;
                }
            }
            return false;
        }
    }
}
