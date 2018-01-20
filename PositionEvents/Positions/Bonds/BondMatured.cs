using PositionEvents.Instruments;

namespace PositionEvents.Positions.Bonds
{
    public class BondMatured : IPositionEvent
    {
        public readonly Bond Bond;

        public BondMatured(Bond bond)
        {
            Bond = bond;
        }
    }
}
