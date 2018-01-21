using PositionEvents.Aggregates;
using PositionEvents.Pricing;
using PositionEvents.Utils;

namespace PositionEvents.Positions.Bonds
{
    public class BondCouponPayedHandler : PositionEventHandler<BondCouponPayed>
    {
        public BondCouponPayedHandler(ITimeProvider timeProvider, IMediator<PositionEvent> mediator) 
            : base(timeProvider, mediator)
        { }


        public override void Apply(PortfolioStore position, BondCouponPayed positionEvent)
        {
            var coupon = positionEvent.Coupon;
            var size = position.Get(coupon).Size;

            var cashflow = DiscountingBondCouponPricer.Default.Amount(coupon, (int)size);

            position.Add(cashflow);
            position.Remove(coupon, size);
        }
    }
}
