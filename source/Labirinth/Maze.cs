using System;

namespace Labirinth
{
    class Maze
    {
        public Location[,] Cells;
        public int Height;
        public int Width;

        // Constructor
        public Maze(int x_in, int y_in)
        {
            Height = y_in;
            Width = x_in;
            int x = x_in + 1;
            int y = y_in + 1;

            Cells = new Location[x, y];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Cells[i, j] = new Location();
                }
            }

            for (int i = 0; i < x; i++)
            {
                Cells[i, 0].up_wall = true;
                Cells[i, y - 1].up_wall = true;
            }

            for (int i = 0; i < y; i++)
            {
                Cells[0, i].left_wall = true;
                Cells[x - 1, i].left_wall = true;
            }
        }

        // Method to break a wall between [x, y] and [dx, dy] locations
        public void BreakWall(int x, int y, int dx, int dy)
        {
            if (dx == -1)
            {
                this.Cells[x, y].left_wall = false;
            }
            else
            {
                if (dx == 1)
                {
                    this.Cells[x + 1, y].left_wall = false;
                }
                else
                {
                    if (dy == -1)
                    {
                        this.Cells[x, y].up_wall = false;
                    }
                    else
                    {
                        this.Cells[x, y + 1].up_wall = false;
                    }
                }
            }
        }

        // Method to find out if ther's no wall between
        // location [x, y] and location [x + dx, y + dy]
        public bool CanGo(int x, int y, int dx, int dy)
        {
            if (dx == -1)
            {
                return !this.Cells[x, y].left_wall;
            }
            else
            {
                if (dx == 1)
                {
                    return !this.Cells[x + 1, y].left_wall;
                }
                else
                {
                    if (dy == -1)
                    {
                        return !this.Cells[x, y].up_wall;
                    }
                    else
                    {
                        return !this.Cells[x, y + 1].up_wall;
                    }
                }
            }
        }
   
        // Method to clear all names of locations
        public void ClearNames()
        {
            for (int x = 0; x < this.Width; x++)
            {
                for (int y = 0; y < this.Height; y++)
                {
                    this.Cells[x, y].name = "";
                }
            }
        }

    }
}
