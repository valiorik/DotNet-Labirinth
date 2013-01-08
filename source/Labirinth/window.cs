using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Labirinth
{
    public partial class Form1 : Form
    {
        private struct Point
        {
            public int x;
            public int y;
        }
        // size of cell to draw
        Point[] Path;
        private const int CellSize = 20;
        private Maze maze;
        private Pen pnRightFinger = new Pen(Color.Green, 3);
        private Pen pnLeftFinger = new Pen(Color.Black, 3);
        
        // Constructor
        public Form1()
        {
            InitializeComponent();
        }

        // method drawing maze at the picture box on the screen
        private void ShowMaze()
        {
            // preparing canvas
            Bitmap bmCanvas = new Bitmap(pbScreen.Width, pbScreen.Height);
            Graphics grhpImage = Graphics.FromImage(bmCanvas);
            grhpImage.Clear(Color.Black);

            // looking throw all maze
            for (int x = 0; x < maze.Width; x++)
            {
                for (int y = 0; y < maze.Height; y++)
                {
                    // if uper wall exists it is drawen
                    if (maze.Cells[x, y].up_wall)
                    {       
                        grhpImage.DrawLine(pnRightFinger, 
                            x * CellSize + CellSize,
                            y * CellSize + CellSize,
                            (x + 1) * CellSize + CellSize,
                            y * CellSize + CellSize);
                    }
                    
                    // if left wall exist it is drawn
                    if (maze.Cells[x, y].left_wall)
                    {       
                        grhpImage.DrawLine(pnRightFinger, 
                            x * CellSize + CellSize,
                            y * CellSize + CellSize,
                            x * CellSize + CellSize,
                            (y + 1) * CellSize + CellSize);
                    }

                    // writes the name of location on middle the cell
                    grhpImage.DrawString(maze.Cells[x, y].name, 
                        new Font("Arial", 12), 
                        Brushes.Green,
                        x * CellSize + CellSize + CellSize / 10, 
                        y * CellSize + CellSize + CellSize / 10);
                }
            }
            
            // drawing bottom wall for all maze
            grhpImage.DrawLine(pnRightFinger, 
                CellSize,
                maze.Height * CellSize + CellSize,
                maze.Width * CellSize + CellSize,
                maze.Height * CellSize + CellSize);
            
            // drawing roght wall for all maze
            grhpImage.DrawLine(pnRightFinger, 
                maze.Width * CellSize + CellSize,
                maze.Height * CellSize + CellSize,
                maze.Width * CellSize + CellSize,
                CellSize);

            // leaving entrances and exit
            grhpImage.DrawLine(pnLeftFinger,
                CellSize,
                CellSize,
                CellSize,
                2 * CellSize);
            grhpImage.DrawLine(pnLeftFinger,
                (maze.Width) * CellSize + CellSize,
                (maze.Height) * CellSize + CellSize,
                (maze.Width) * CellSize + CellSize,
                (maze.Height - 1) * CellSize + CellSize);

            // copying maze from canvas to picture box on the window
            pbScreen.Image = bmCanvas;
        }

        // then clicked new maze created and ways restributed
        private void button1_Click(object sender, EventArgs e)
        {
            maze = new Maze(Convert.ToInt32(nudX.Value), 
                Convert.ToInt32(nudY.Value));
            ShowMaze();
            btnCreateMaze.Enabled = false;
            Application.DoEvents();
            GenerateMaze();
            btnCreateMaze.Enabled = true;
            btnSolveMaze.Enabled = true;
        }

        // Prim's algorithm. Maze must be created, all walls set
        // and status of all locations have to be "Inside"
        private void GenerateMaze()
        {
            int[] dx = new int[4] {1, 0, -1, 0};  // shift cooficients
            int[] dy = new int[4] {0, -1, 0, 1};

            Random random = new Random();

            int xc;
            int yc;
            int x = random.Next(maze.Width);    // chose random location
            int y = random.Next(maze.Height);
            maze.Cells[x, y].status = 1;        // and mark it "Inside"

            // assigning "Border" to all neiborts
            for (int i = 0; i < 4; i++)
            {
                xc = x + dx[i];
                yc = y + dy[i];
                if (xc >= 0 && yc >= 0 && xc < maze.Width && yc < maze.Height)
                {
                    maze.Cells[xc, yc].status = 0;
                }
            }

            // main cicle, repeats until labirinth is build
            bool finished;
            do
            {
                finished = true;
                int counter = 0;

                // calculating cells with status "Border"
                for (x = 0; x < maze.Width; x++)
                {
                    for (y = 0; y < maze.Height; y++)
                    {
                        if (maze.Cells[x, y].status == 0)
                        {
                            counter++;
                        }
                    }
                }
                
                // choosing random one
                counter = random.Next(counter) + 1;
                int xloc = 0;
                int yloc = 0;
                for (x = 0; x < maze.Width; x++)
                {
                    for (y = 0; y < maze.Height; y++)
                    {
                        if (maze.Cells[x, y].status == 0)
                        {
                            counter--;
                            if (counter == 0)
                            {
                                xloc = x;
                                yloc = y;
                            }
                        }
                    }
                }
                // this random cell gets "Inside"
                maze.Cells[xloc, yloc].status = 1;

                counter = 0;
                for (int i = 0; i < 4; i++)
                {
                    xc = xloc + dx[i];
                    yc = yloc + dy[i];
                    if (xc >= 0 && yc >= 0 && xc < maze.Width && yc < maze.Height)
                    {
                        if (maze.Cells[xc, yc].status == 1)
                        {
                            // calculating "Inside" locations
                            counter++;
                        }
                        if (maze.Cells[xc, yc].status == -1)
                        {
                            // changing to "Border"
                             maze.Cells[xc, yc].status = 0;
                        }
                    }
                }

                // choosing random "Inside" location
                counter = random.Next(counter) + 1;
                for (int i = 0; i < 4; i++)
                {
                    xc = xloc + dx[i];
                    yc = yloc + dy[i];
                    if (xc >= 0 && yc >= 0 &&
                        xc < maze.Width &&
                        yc < maze.Height &&
                        maze.Cells[xc, yc].status == 1)
                    {
                        counter--;
                        if (counter == 0)
                        {
                            // destroying the wall between chossen location
                            // and current one
                            maze.BreakWall(xloc, yloc, dx[i], dy[i]);
                        }
                    }
                }

                // now searching for "Border" locations. if perhaps one is found
                // algorithm cicle will be runed once again
                for (x = 0; x < maze.Width; x++)
                {
                    for (y = 0; y < maze.Height; y++)
                    {
                        if (maze.Cells[x, y].status == 0)
                        {
                            finished = false;
                        }
                    }
                }

                // displaying current proccess on the screen
                ShowMaze();
                Application.DoEvents();

            } while (!finished);
        }

        // finds a way thought labirinth using recursion
        private void btnSolveMaze_Click(object sender, EventArgs e)
        {
            btnSolveMaze.Enabled = false;
            btnCreateMaze.Enabled = false;
            RecursiveSolve(0, 0, maze.Width - 1, maze.Height - 1);
            btnCreateMaze.Enabled = true;
        }

        // Labirinth recursive solve algorithm
        private void RecursiveSolve(int xs, int ys, int xf, int yf)
        {
            Path = new Point[maze.Height * maze.Width + 1];

            // if solution is found then marking it at maze and showing it
            if (Solve(xs, ys, xf, yf, 0))
            {
                int i = 0;
                while (Path[i].x != -1)
                //for (int i = 0; i < Path.Length - 2; i++)
                {
                    maze.Cells[Path[i].x, Path[i].y].name = "X";
                    i++;
                }
                ShowMaze();
            }
        }

        // recoursive part
        private bool Solve(int x, int y, int xf, int yf, int depth)
        {
            int[] dx = new int[4] { 1, 0, -1, 0 };  // shift cooficients
            int[] dy = new int[4] { 0, -1, 0, 1 };

            // Mark current location as "visited"
            maze.Cells[x, y].visited = true;
            // Add it to Path
            Path[depth].x = x;
            Path[depth].y = y;
            // Add mark [-1, -1] of Path finish
            Path[depth + 1].x = -1;
            Path[depth + 1].y = -1;

            // Shpwing progress at the picture box
            maze.ClearNames();
            int k = 0;
            while (Path[k].x != -1)
            {
                maze.Cells[Path[k].x, Path[k].y].name = "X";
                k++;
            }
            ShowMaze();
            Application.DoEvents();
            
            // if exit location is found..
            if (x == xf && y == yf)
            {
                return true;
            }

            // searching for free way
            for (int i = 0; i < 4; i++)
            {
                // if the way is clear we go that's way!
                if (maze.CanGo(x, y, dx[i], dy[i]) && 
                    !maze.Cells[x + dx[i], y + dy[i]].visited)
                {
                    if (Solve(x + dx[i], y + dy[i], xf, yf, depth + 1))
                    {
                        // if way out is found it's end of algorithm
                        return true;
                    }
                }
            }

            // if labirinth doesn't have any solutions..
            maze.Cells[x, y].visited = false;
            return false;
        }
    }
}