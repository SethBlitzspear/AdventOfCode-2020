using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_20
{
    public enum TileState
    {
        TopisTop = 0,
        LeftisTop = 1,
        BottomisTop = 2,
        RightisTop = 3,
        TopFlipisTop = 4,
        LeftFlipisTop = 5,
        BottomFlipisTop = 6,
        RightFlipisTop = 7,
    }
    public class Tile
    {
        char[,] data = new char[10, 10];
        int id;
        int addPos = 0;
        int joinCount = 0;
        TileState state = TileState.TopisTop;
       
       

        public int RawTop
        {
            get
            {
                int top = 0;
                int ornum = 512;
                for (int charCount = 0; charCount < 10; charCount++)
                {
                    
                    if (Data[0, charCount] == '#')
                    {
                        top |= ornum;
                    }
                    ornum /= 2;
                }
                return top;
            }
        }
        public int RawRight
        {
            get
            {
                int right = 0;
                int ornum = 512;
                for (int charCount = 0; charCount < 10; charCount++)
                {
                    
                    if (Data[charCount, 9] == '#')
                    {
                        right |= ornum;
                    }
                    ornum /= 2;
                }
                return right;
            }
        }

        public int RawBottom
        {
            get
            {
                int bottom = 0;
                int ornum = 1;
                for (int charCount = 0; charCount < 10; charCount++)
                {
                    
                    if (Data[9, charCount] == '#')
                    {
                        bottom |= ornum;
                    }
                    ornum *= 2;
                }
                return bottom;
            }
        }

        public int RawLeft
        {
            get
            {
                int left = 0;
                int ornum = 1;
                for (int charCount = 0; charCount < 10; charCount++)
                {
                   
                    if (Data[charCount, 0] == '#')
                    {
                        left |= ornum;
                    }
                    ornum *= 2;
                }
                return left;
            }
        }

        public int RawTopFlip
        {
            get
            {
                int top = 0;
                int ornum = 1;
                for (int charCount = 0; charCount < 10; charCount++)
                {

                    if (Data[0, charCount] == '#')
                    {
                        top |= ornum;
                    }
                    ornum *= 2;
                }
                return top;
            }
        }
        public int RawRightFlip
        {
            get
            {
                int right = 0;
                int ornum = 1;
                for (int charCount = 0; charCount < 10; charCount++)
                {

                    if (Data[charCount, 9] == '#')
                    {
                        right |= ornum;
                    }
                    ornum *= 2;
                }
                return right;
            }
        }

        public int RawBottomFlip
        {
            get
            {
                int bottom = 0;
                int ornum = 512;
                for (int charCount = 0; charCount < 10; charCount++)
                {

                    if (Data[9, charCount] == '#')
                    {
                        bottom |= ornum;
                    }
                    ornum /= 2;
                }
                return bottom;
            }
        }

        public int RawLeftFlip
        {
            get
            {
                int left = 0;
                int ornum = 512;
                for (int charCount = 0; charCount < 10; charCount++)
                {

                    if (Data[charCount, 0] == '#')
                    {
                        left |= ornum;
                    }
                    ornum /= 2;
                }
                return left;
            }
        }

        public int Top
        {
            get
            {
                switch(State)
                {
                    case TileState.TopisTop:
                        return RawTop;
                    case TileState.RightisTop:
                        return RawRight;
                    case TileState.BottomisTop:
                        return RawBottom;
                    case TileState.LeftisTop:
                        return RawLeft;
                    case TileState.TopFlipisTop:
                        return RawTopFlip;
                    case TileState.RightFlipisTop:
                        return RawRightFlip;
                    case TileState.BottomFlipisTop:
                        return RawBottomFlip;
                    case TileState.LeftFlipisTop:
                        return RawLeftFlip;
                }

                return RawTop;
            }
        }
        public int Right
        {
            get
            {
                switch (State)
                {
                    case TileState.TopisTop:
                        return RawRight;
                    case TileState.RightisTop:
                        return RawBottom;
                    case TileState.BottomisTop:
                        return RawLeft;
                    case TileState.LeftisTop:
                        return RawTop;
                    case TileState.TopFlipisTop:
                        return RawLeftFlip;
                    case TileState.RightFlipisTop:
                        return RawTopFlip;
                    case TileState.BottomFlipisTop:
                        return RawRightFlip;
                    case TileState.LeftFlipisTop:
                        return RawBottomFlip;
                }

                return RawTop;
            }
        }
        public int Bottom
        {
            get
            {
                switch (State)
                {
                    case TileState.TopisTop:
                        return RawBottom;
                    case TileState.RightisTop:
                        return RawLeft;
                    case TileState.BottomisTop:
                        return RawTop;
                    case TileState.LeftisTop:
                        return RawRight;
                    case TileState.TopFlipisTop:
                        return RawBottomFlip;
                    case TileState.RightFlipisTop:
                        return RawLeftFlip;
                    case TileState.BottomFlipisTop:
                        return RawTopFlip;
                    case TileState.LeftFlipisTop:
                        return RawRightFlip;
                }

                return RawTop;
            }
        }
        public int Left
        {
            get
            {
                switch (State)
                {
                    case TileState.TopisTop:
                        return RawLeft;
                    case TileState.RightisTop:
                        return RawTop;
                    case TileState.BottomisTop:
                        return RawRight;
                    case TileState.LeftisTop:
                        return RawBottom;
                    case TileState.TopFlipisTop:
                        return RawRightFlip;
                    case TileState.RightFlipisTop:
                        return RawBottomFlip;
                    case TileState.BottomFlipisTop:
                        return RawLeftFlip;
                    case TileState.LeftFlipisTop:
                        return RawTopFlip;
                }

                return RawTop;
            }
        }
        public char[,] Data { get => data; set => data = value; }
        public int Id { get => id; set => id = value; }
        public int JoinCount { get => joinCount; set => joinCount = value; }
        public TileState State { get => state; set => state = value; }

        public void AddLine(string line)
        {
            for (int charCount = 0; charCount < 10; charCount++)
            {
                data[addPos, charCount] = line[charCount];
            }
            addPos++;
        }

        public void RotateTop(int join)
        {
            if (join == RawTop)
            {
                State = TileState.TopFlipisTop;
            }
            else if(join == RawRight)
            {
                State = TileState.RightFlipisTop;
            }
            else if (join == RawBottom)
            {
                State = TileState.BottomFlipisTop;
            }
            else if (join == RawLeft)
            {
                State = TileState.LeftFlipisTop;
            }
            else if (join == RawTopFlip)
            {
                State = TileState.TopisTop;
            }
            else if (join == RawLeftFlip)
            {
                State = TileState.LeftisTop;
            }
            else if (join == RawBottomFlip)
            {
                State = TileState.BottomisTop;
            }
            else if (join == RawRightFlip)
            {
                State = TileState.RightisTop;
            }
        }
        public void RotateLeft(int join)
        {
            if (join == RawLeft)
            {
                State = TileState.BottomFlipisTop;
            }
            else if (join == RawTop)
            {
                State = TileState.LeftFlipisTop;
            }
            else if (join == RawRight)
            {
                State = TileState.TopFlipisTop;
            }
            else if (join == RawBottom)
            {
                State = TileState.RightFlipisTop;
            }
            else if (join == RawLeftFlip)
            {
                State = TileState.TopisTop;
            }
            else if (join == RawTopFlip)
            {
                State = TileState.RightisTop;
            }
            else if (join == RawRightFlip)
            {
                State = TileState.BottomisTop;
            }
            else if (join == RawBottomFlip)
            {
                State = TileState.LeftisTop;
            }
        }

        internal void CheckJoins(Dictionary<int, List<Tile>> joins)
        {
            if (joins[RawTop].Count > 1)
            {
                JoinCount++;
            }
            if (joins[RawBottom].Count > 1)
            {
                JoinCount++;
            }
            if (joins[RawRight].Count > 1)
            {
                JoinCount++;
            }
            if (joins[RawLeft].Count > 1)
            {
                JoinCount++;
            }

            if (joins[RawTopFlip].Count > 1)
            {
                JoinCount++;
            }
            if (joins[RawBottomFlip].Count > 1)
            {
                JoinCount++;
            }
            if (joins[RawRightFlip].Count > 1)
            {
                JoinCount++;
            }
            if (joins[RawLeftFlip].Count > 1)
            {
                JoinCount++;
            }
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Tile[,] image;
            List<Tile> Tiles = new List<Tile>();
            string[] TileData = File.ReadAllLines("Tiles.txt");
            Dictionary<int, List<Tile>> joins = new Dictionary<int, List<Tile>>();
            Tile currentTile = null;
            foreach (string line in TileData)
            {
                if(line == "")
                {
                    Tiles.Add(currentTile);
                    AddJoin(joins, currentTile, currentTile.RawTop);
                    AddJoin(joins, currentTile, currentTile.RawBottom);
                    AddJoin(joins, currentTile, currentTile.RawRight);
                    AddJoin(joins, currentTile, currentTile.RawLeft);
                    AddJoin(joins, currentTile, currentTile.RawTopFlip);
                    AddJoin(joins, currentTile, currentTile.RawBottomFlip);
                    AddJoin(joins, currentTile, currentTile.RawRightFlip);
                    AddJoin(joins, currentTile, currentTile.RawLeftFlip);
                }
                else if(line.Substring(0, 4) == "Tile")
                {
                    currentTile = new Tile();
                    currentTile.Id = Convert.ToInt32(line.Substring(5, 4));
                    
                }
                else
                {
                    currentTile.AddLine(line);
                }

            }
            Tiles.Add(currentTile);
            AddJoin(joins, currentTile, currentTile.RawTop);
            AddJoin(joins, currentTile, currentTile.RawBottom);
            AddJoin(joins, currentTile, currentTile.RawRight);
            AddJoin(joins, currentTile, currentTile.RawLeft);
            AddJoin(joins, currentTile, currentTile.RawTopFlip);
            AddJoin(joins, currentTile, currentTile.RawBottomFlip);
            AddJoin(joins, currentTile, currentTile.RawRightFlip);
            AddJoin(joins, currentTile, currentTile.RawLeftFlip);
            foreach (Tile tile in Tiles)
            {
                tile.CheckJoins(joins);
            }
            int imageDim = (int)Math.Sqrt(Tiles.Count);
            image = new Tile[imageDim, imageDim];
            List<Tile> usedTiles;
            bool foundSolution = false;
            foreach (Tile tile in Tiles)
            {
                if (!foundSolution)
                {
                    for (int state = 0; state < 8; state++)
                    {
                        tile.State = (TileState)state;
                        image = new Tile[imageDim, imageDim];
                        usedTiles = new List<Tile>();
                        image[0, 0] = tile;
                        bool thisWorks = true;
                        int tilePosID = 1;
                        while (thisWorks && tilePosID < Tiles.Count)
                        {
                            int col, row;
                            row = Math.DivRem(tilePosID, imageDim, out col);
                            if (row > 0)
                            {
                                if (joins[image[row - 1, col].Bottom] != null && joins[image[row - 1, col].Bottom].Count > 1)
                                {
                                    if (usedTiles.Contains(joins[image[row - 1, col].Bottom][0]) && usedTiles.Contains(joins[image[row - 1, col].Bottom][1]))
                                    {
                                        thisWorks = false;
                                    }
                                    else
                                    {
                                        Tile newTile;
                                        if (image[row - 1, col] == joins[image[row - 1, col].Bottom][0])
                                        {
                                            newTile = joins[image[row - 1, col].Bottom][1];
                                        }
                                        else
                                        {
                                            newTile = joins[image[row - 1, col].Bottom][0];
                                        }
                                        newTile.RotateTop(image[row - 1, col].Bottom);
                                        image[row, col] = newTile;
                                        usedTiles.Add(tile);
                                        /*if (col > 0)
                                        {
                                            if (image[row, col - 1].Right != image[row, col].Left)
                                            {
                                                thisWorks = false;
                                            }
                                        }*/
                                    }
                                }
                                else
                                {
                                    thisWorks = false;
                                }

                            }
                            else
                            {
                                if (joins[image[row, col - 1].Right] != null && joins[image[row, col - 1].Right].Count > 1)
                                {
                                    if (usedTiles.Contains(joins[image[row, col - 1].Right][0]) && usedTiles.Contains(joins[image[row, col - 1].Right][1]))
                                    {
                                        thisWorks = false;
                                    }
                                    else
                                    {
                                        Tile newTile;
                                        if (image[row, col - 1] == joins[image[row, col - 1].Right][0])
                                        {
                                            newTile = joins[image[row, col - 1].Right][1];
                                        }
                                        else
                                        {
                                            newTile = joins[image[row, col - 1].Right][0];
                                        }
                                        newTile.RotateLeft(image[row, col - 1].Right);
                                        image[row, col] = newTile;
                                        usedTiles.Add(tile);
                                    }
                                }
                                else
                                {
                                    thisWorks = false;
                                }
                            }
                            tilePosID++;
                            
                        }
                        if (thisWorks)
                        {
                            state = 8;
                            foundSolution = true;
                        }
                    }
                }

            }
            UInt64 IDCheck = (UInt64)image[0, 0].Id * (UInt64)image[imageDim - 1, 0].Id * (UInt64)image[0, imageDim - 1].Id * (UInt64)image[imageDim - 1, imageDim - 1].Id;
            Console.WriteLine(IDCheck);
            Console.ReadLine();
        }

        private static void AddJoin(Dictionary<int, List<Tile>> joins, Tile currentTile, int pos)
        {
            if (joins.ContainsKey(pos))
            {
                joins[pos].Add(currentTile);
            }
            else
            {
                List<Tile> joinTiles = new List<Tile>();
                joinTiles.Add(currentTile);
                joins.Add(pos, joinTiles);
            }
        }
    }
}
