using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGen.Class
{
    class Conf
    {
        private int _cellSize;

        public int CellSize { get => _cellSize; set => _cellSize = value; }

        public Conf()
        {
            this.CellSize = 2;
        }
    }
}
