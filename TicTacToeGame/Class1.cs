using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacTocGame
{
    public class TicTacObject
    {
        public int UserIndex { get; set; }
        public bool Checked { get; set; }
        public int X_Min { get; set; }
        public int Y_Min { get; set; }
        public int X_Max { get; set; }
        public int Y_Max { get; set; }

    }
}
