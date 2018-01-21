using PositionEvents.Instruments;

namespace PositionEvents.Positions.Bonds
{
    public class BondCouponPayed : PositionEvent
    {
        public readonly Coupon Coupon;
        public readonly int Lots;

        public BondCouponPayed(Coupon coupon, int lots)
        {
            Lots = lots;
            Coupon = coupon;
        }
    }
}
