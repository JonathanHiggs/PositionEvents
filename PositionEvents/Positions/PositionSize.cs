using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionEvents.Instruments;

namespace PositionEvents.Positions
{
    public struct PositionSize
    {
        public double Size;

        private static PositionSize empty = new PositionSize { Size = 0.0 };
        public static PositionSize Empty => empty;

        public bool CanRemove()
        {
            return Size == 0.0;
        }
    }
}
