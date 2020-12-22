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
                    
                    if (RawData[0, charCount] == '#')
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
                    
                    if (RawData[charCount, 9] == '#')
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
                    
                    if (RawData[9, charCount] == '#')
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
                   
                    if (RawData[charCount, 0] == '#')
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

                    if (RawData[0, charCount] == '#')
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

                    if (RawData[charCount, 9] == '#')
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

                    if (RawData[9, charCount] == '#')
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

                    if (RawData[charCount, 0] == '#')
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

       
        public char[,] RawData { get => data; set => data = value; }
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

        internal char GetData(int row, int col)
        {
            int temp;
            switch (State)
            {
                case TileState.TopisTop:
                    break;
                case TileState.RightisTop:
                    for (int i = 0; i < 3; i++)
                    {
                        temp = row;
                        row = col - ((col - 4) * 2) - 1; 
                        col = temp;
                    }
                    break;
                case TileState.BottomisTop:
                    for (int i = 0; i < 2; i++)
                    {
                        temp = row;
                        row = col - ((col - 4) * 2) - 1;
                        col = temp;
                    }
                    break;
                case TileState.LeftisTop:
                    for (int i = 0; i < 1; i++)
                    {
                        temp = row;
                        row = col - ((col - 4) * 2) - 1;
                        col = temp;
                    }
                    break;
                case TileState.TopFlipisTop:
                    col = col - ((col - 4) * 2);
                    break;
                case TileState.RightFlipisTop:
                    temp = row;
                    for (int i = 0; i < 1; i++)
                    {
                        row = col - ((col - 4) * 2) - 1;
                        col = temp;
                    }
                    col = col - ((col - 4) * 2) - 1;
                    break;
                case TileState.BottomFlipisTop:
                    for (int i = 0; i < 2; i++)
                    {
                        temp = row;
                        row = col - ((col - 4) * 2) - 1;
                        col = temp;
                    }
                    col = col - ((col - 4) * 2) - 1;
                    break;
                case TileState.LeftFlipisTop:
                    for (int i = 0; i < 3; i++)
                    {
                        temp = row;
                        row = col - ((col - 4) * 2) - 1;
                        col = temp;
                    }
                    col = col - ((col - 4) * 2) - 1;
                    break;
            }
            return RawData[row + 1, col + 1];
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
                if (line == "")
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
                else if (line.Substring(0, 4) == "Tile")
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
            int row = 0, col = 0;
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
                            //int col, row;
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

            char[,] seaImage = new char[8 * imageDim, 8 * imageDim];

            for (int imgRow = 0; imgRow < imageDim; imgRow++)
            {
                for (int imgCol = 0; imgCol < imageDim; imgCol++)
                {
                    row = imgRow * 8;
                    col = imgCol * 8;
                    for (int r = 0; r < 8; r++)
                    {
                        for (int c = 0; c < 8; c++)
                        {
                            seaImage[row + r, col + c] = image[imgRow, imgCol].GetData(r, c);
                        }
                    }
                }
            }

           // PrintMap(seaImage, TileState.TopisTop);
            int monsterCount = 0;
            for (int checkState = 0; checkState < 8; checkState++)
            {
                PrintMap(seaImage, (TileState)checkState);
                Console.WriteLine();
                for (int rowCount = 1; rowCount < 8 * imageDim - 2; rowCount++)
                {
                    for (int colCount = 0; colCount < 8 * imageDim - 20; colCount++)
                    {
                        if (seaImage[getRow(rowCount, colCount, (TileState)checkState, 4 * imageDim), getCol(rowCount, colCount, (TileState)checkState, 4 * imageDim)] == '#')
                        {
                            int[] rowchange = { 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, -1, 0, 0 };
                            int[] colchange = { 1, 4, 5, 6, 7, 10, 11, 12, 13, 16, 17, 18, 18, 19 };
                            bool foundOne = true;
                            for (int tailCheck = 0; tailCheck < 14; tailCheck++)
                            {
                                if (seaImage[getRow(rowCount + rowchange[tailCheck], colCount + colchange[tailCheck], (TileState)checkState, 4 * imageDim), getCol(rowCount + rowchange[tailCheck], colCount + colchange[tailCheck], (TileState)checkState, 4 * imageDim)] != '#')
                                {
                                    tailCheck = 14;
                                    foundOne = false;
                                }

                            }
                            if (foundOne)
                            {
                                monsterCount++;
                            }
                        }

                    }
                }
            }
            int hashCount = 0;
            for (int rowCount = 0; rowCount < 8 * imageDim; rowCount++)
            {
                for (int colCount = 0; colCount < 8 * imageDim; colCount++)
                {
                    if(seaImage[rowCount, colCount] == '#')
                    {
                        hashCount++;
                    }
                }
            }
            Console.WriteLine((hashCount - 15 * monsterCount));
            Console.ReadLine();
        }

        private static void PrintMap( char[,] seaImage, TileState state)
        {
            int dim = seaImage.GetLength(0);
            for (int r = 0; r < dim; r++)
            {
                string line = "";
                for (int c = 0; c < dim; c++)
                {
                    line += seaImage[getRow(r, c, state, dim/2), getCol(r, c, state, dim/2)];
                }
                Console.WriteLine(line);
            }
        }

        private static int getCol(int row, int col, TileState checkState, int dim)
        {
            int temp;
            switch (checkState)
            {
                case TileState.TopisTop:
                    break;
                case TileState.RightisTop:
                    for (int i = 0; i < 3; i++)
                    {
                        temp = row;
                        row = col - ((col - dim) * 2) - 1;
                        col = temp;
                    }
                    break;
                case TileState.BottomisTop:
                    for (int i = 0; i < 2; i++)
                    {
                        temp = row;
                        row = col - ((col - dim) * 2) - 1;
                        col = temp;
                    }
                    break;
                case TileState.LeftisTop:
                    for (int i = 0; i < 1; i++)
                    {
                        temp = row;
                        row = col - ((col - dim) * 2) - 1;
                        col = temp;
                    }
                    break;
                case TileState.TopFlipisTop:
                    col = col - ((col - dim) * 2) - 1;
                    break;
                case TileState.RightFlipisTop:
                    temp = row;
                    for (int i = 0; i < 1; i++)
                    {
                        row = col - ((col - dim) * 2) - 1;
                        col = temp;
                    }
                    col = col - ((col - dim) * 2) - 1;
                    break;
                case TileState.BottomFlipisTop:
                    for (int i = 0; i < 2; i++)
                    {
                        temp = row;
                        row = col - ((col - dim) * 2) - 1;
                        col = temp;
                    }
                    col = col - ((col - dim) * 2) - 1;
                    break;
                case TileState.LeftFlipisTop:
                    for (int i = 0; i < 3; i++)
                    {
                        temp = row;
                        row = col - ((col - dim) * 2) - 1;
                        col = temp;
                    }
                    col = col - ((col - dim) * 2) - 1;
                    break;
            }
            return col;
        }

        private static int getRow(int row, int col, TileState checkState, int dim)
        {
            int temp;
            switch (checkState)
            {
                case TileState.TopisTop:
                    break;
                case TileState.RightisTop:
                    for (int i = 0; i < 3; i++)
                    {
                        temp = row;
                        row = col - ((col - dim) * 2) - 1;
                        col = temp;
                    }
                    break;
                case TileState.BottomisTop:
                    for (int i = 0; i < 2; i++)
                    {
                        temp = row;
                        row = col - ((col - dim) * 2) - 1;
                        col = temp;
                    }
                    break;
                case TileState.LeftisTop:
                    for (int i = 0; i < 1; i++)
                    {
                        temp = row;
                        row = col - ((col - dim) * 2) - 1;
                        col = temp;
                    }
                    break;
                case TileState.TopFlipisTop:
                    col = col - ((col - dim) * 2) - 1;
                    break;
                case TileState.RightFlipisTop:
                    temp = row;
                    for (int i = 0; i < 1; i++)
                    {
                        row = col - ((col - dim) * 2) - 1;
                        col = temp;
                    }
                    col = col - ((col - dim) * 2) - 1;
                    break;
                case TileState.BottomFlipisTop:
                    for (int i = 0; i < 2; i++)
                    {
                        temp = row;
                        row = col - ((col - dim) * 2) - 1;
                        col = temp;
                    }
                    col = col - ((col - dim) * 2) - 1;
                    break;
                case TileState.LeftFlipisTop:
                    for (int i = 0; i < 3; i++)
                    {
                        temp = row;
                        row = col - ((col - dim) * 2) - 1;
                        col = temp;
                    }
                    col = col - ((col - dim) * 2) - 1;
                    break;
            }
            return row;
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
