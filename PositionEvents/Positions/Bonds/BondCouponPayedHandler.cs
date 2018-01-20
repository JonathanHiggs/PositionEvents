using PositionEvents.Pricing;
using PositionEvents.Utils;

namespace PositionEvents.Positions.Bonds
{
    public class BondCouponPayedHandler : PositionEventHandler<BondCouponPayed>
    {
        public BondCouponPayedHandler(ITimeProvider timeProvider) 
            : base(timeProvider)
        { }


        public override void Apply(Positions position, BondCouponPayed positionEvent)
        {
            var coupon = positionEvent.Coupon;
            var size = position.Get(coupon).Size;

            var cashflow = DiscountingBondCouponPricer.Default.Amount(coupon, (int)size);

            position.Add(cashflow);
            position.Remove(coupon, size);
        }
    }
}
