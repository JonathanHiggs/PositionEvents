using PositionEvents.Instruments;
using PositionEvents.Specifications;

namespace PositionEvents.Positions.Bonds
{
    public class BondPurchased : IPositionEvent
    {
        public readonly Bond PurchasedBond;
        public readonly BondDirtyPrice Price;
        public readonly uint Lots;

        public BondPurchased(Bond bond, BondDirtyPrice price, uint lots)
        {
            PurchasedBond = bond;
            Price = price;
            Lots = lots;
        }
    }
}
