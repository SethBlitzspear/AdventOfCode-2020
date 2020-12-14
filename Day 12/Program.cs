using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_12
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Directions = File.ReadAllLines("Directions.txt");
            int dir = 90;
            int north = 0, south = 0, east = 0, west = 0;

            foreach (string direction in Directions)
            {
                char com = direction[0];
                int mag = Convert.ToInt32(direction.Substring(1, direction.Length - 1));

                switch(com)
                {
                    case 'N':
                        north += mag;
                        break;
                    case 'E':
                        east += mag;
                        break;
                    case 'S':
                        south += mag;
                        break;
                    case 'W':
                        west += mag;
                        break;

                    case 'R':
                        dir += mag;
                        dir = dir % 360;
                        
                        break;
                    case 'L':
                        dir -= mag;
                        dir = dir % 360;
                        if (dir == -90)
                        {
                            dir = 270;
                        }
                        if (dir == -180)
                        {
                            dir = 180;
                        }
                        if (dir == -270)
                        {
                            dir = 90;
                        }
                        break;

                    case 'F':
                        switch(dir)
                        {
                            case 0:
                                north += mag;
                                break;
                            case 90:
                                east += mag;
                                break;
                            case 180:
                                south += mag;
                                break;
                            case 270:
                                west += mag;
                                break;


                        }

                        break;
                }
            }
            int manhattan = Math.Abs(north - south) + Math.Abs(east - west);
            Console.WriteLine(manhattan);



            int WayNorth = 1, WayEast = 10;
            north = west = east = south = 0;
            dir = 1;
            
            foreach (string direction in Directions)
            {
                char com = direction[0];
                int mag = Convert.ToInt32(direction.Substring(1, direction.Length - 1));

                switch (com)
                {
                    case 'N':
                        WayNorth += mag;
                        break;
                    case 'E':
                        WayEast += mag;
                        break;
                    case 'S':
                        WayNorth -= mag;
                        break;
                    case 'W':
                        WayEast -= mag;
                        break;

                    case 'R':
                       while (mag > 0)
                        {
                            int ShipDifNorth = WayNorth - north;
                            int ShipDifEast = WayEast - east;
                            
                                    WayNorth = north - ShipDifEast;
                                    WayEast = east + ShipDifNorth;
                                    
                                    

                            
                            if(dir++ == 5)
                            {
                                dir = 1;
                            }
                            mag-=90;
                        }

                        break;
                    case 'L':
                        while (mag > 0)
                        {
                            int ShipDifNorth = WayNorth - north;
                            int ShipDifEast = WayEast - east;

                            WayNorth = north + ShipDifEast;
                            WayEast = east - ShipDifNorth;




                            if(dir-- == 0)
                            {
                                dir = 4;
                            }
                            mag-=90;
                        }
                        break;

                    case 'F':
                        int diffNorth = WayNorth - north;
                        north += (mag * diffNorth);
                        WayNorth += (mag * diffNorth);

                        int diffEast = WayEast - east;
                        east += (mag * diffEast);
                        WayEast += (mag * diffEast);

                        break;
                }
            }
            int manhattan2 = Math.Abs(north) + Math.Abs(east);
            Console.WriteLine(manhattan2);
            Console.ReadLine();
        }
    }
}
