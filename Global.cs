using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MazeGen.Class;
using MazeGen.Class.Enum;

namespace MazeGen
{
    static class Global
    {
        public static Conf Conf = new Conf();
        public static Random Random = new Random();
        public static int Width;
        public static int Height;

        private static Direction[] AllDirection = { Direction.Top, Direction.Bottom, Direction.Left, Direction.Right };

        public static int area => Width * Height;

        public static Direction[] RandomizeDirection 
        { get
            {
                for (int i = 0; i < AllDirection.Length; i++)
                {
                    int index = Random.Next(AllDirection.Length);

                    Direction tmp = AllDirection[i];
                    AllDirection[i] = AllDirection[index];
                    AllDirection[index] = tmp;
                }
                return AllDirection;
            }
        }
        public static ImageSource ImageSourceFromBitmap(Bitmap bmp)
        {
            var handle = bmp.GetHbitmap();
            ImageSource newSource = Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            return newSource;
        }
    }
}
