using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGen.Class.Enum;

namespace MazeGen.Class
{
    static class Generator
    {
        private static bool[,] _map;

        public static bool[,] Map { get => _map != null ? _map : throw new Exception("Generator.Map isn't instantiate. Please run Generator.Maze before"); }

        public static void Maze()
        {
            Global.Width = Global.Width / Global.Conf.CellSize;
            Global.Height = Global.Height / Global.Conf.CellSize;

            Global.Width = Global.Width % 2 == 0 ? Global.Width - 1 : Global.Width;
            Global.Height = Global.Height % 2 == 0 ? Global.Height - 1 : Global.Height;
            _map = new bool[Global.Width, Global.Height];

            _map = GenMaze(_map, 1, 1);
            int enter = Global.Random.Next(Global.Width - 2) + 1;
            enter = enter % 2 == 0 ? enter - 1 : enter;
            int exit = Global.Random.Next(Global.Width - 2) + 1;
            exit = exit % 2 == 0 ? exit - 1 : exit;

            _map[enter, 0] = true;
            _map[exit, Global.Height - 1] = true;
        }
        public static Bitmap GetMazeImage()
        {
            Bitmap bmp = new Bitmap(Global.Width * Global.Conf.CellSize, Global.Height * Global.Conf.CellSize);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                for (int x = 0; x < Global.Width; x++)
                {
                    for (int y = 0; y < Global.Height; y++)
                    {
                        Color c;
                        if (Map[x, y])
                            c = Color.LightSlateGray;
                        else
                            c = Color.Black;
                        g.FillRectangle(new SolidBrush(c),
                            x * Global.Conf.CellSize,
                            y * Global.Conf.CellSize,
                            Global.Conf.CellSize,
                            Global.Conf.CellSize);
                    }
                }
            }

            return bmp;
        }

        private static bool[,] GenMaze(bool[,] map, int x, int y)
        {
            Direction[] RandDirection = Global.RandomizeDirection;
            map[x, y] = true;
            foreach(Direction d in RandDirection)
            {
                switch(d)
                {
                    case Direction.Top:
                        if (y - 2 > 0 && !map[x, y - 2])
                        {
                            map[x, y - 1] = true;
                            map = GenMaze(map, x, y - 2);
                        }
                        break;
                    case Direction.Bottom:
                        if (y + 2 < Global.Height - 1 && !map[x, y + 2])
                        {
                            map[x, y + 1] = true;
                            map = GenMaze(map, x, y + 2);
                        }
                        break;
                    case Direction.Left:
                        if (x - 2 > 0 && !map[x - 2, y])
                        {
                            map[x - 1, y] = true;
                            map = GenMaze(map, x - 2, y);
                        }
                        break;
                    case Direction.Right:
                        if (x + 2 < Global.Width - 1 && !map[x + 2, y])
                        {
                            map[x + 1, y] = true;
                            map = GenMaze(map, x + 2, y);
                        }
                        break;
                }
            }
            return map;
        }
    }
}
