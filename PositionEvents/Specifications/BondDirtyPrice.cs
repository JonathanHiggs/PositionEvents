using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionEvents.Specifications
{
    public struct BondDirtyPrice
    {
        public readonly double Value;

        public BondDirtyPrice(double value)
        {
            Value = value;
        }
    }
}
