﻿using PositionEvents.Instruments;

namespace PositionEvents.Positions.Bonds
{
    public class BondMatured : PositionEvent
    {
        public readonly Bond Bond;

        public BondMatured(Bond bond)
        {
            Bond = bond;
        }
    }
}
