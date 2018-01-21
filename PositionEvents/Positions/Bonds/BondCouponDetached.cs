using PositionEvents.Instruments;

namespace PositionEvents.Positions.Bonds
{
    public class BondCouponDetached : PositionEvent
    {
        public readonly Bond Bond;
        public readonly Coupon Coupon;

        public BondCouponDetached(Bond bond, Coupon coupon)
        {
            Bond = bond;
            Coupon = coupon;
        }
    }
}
