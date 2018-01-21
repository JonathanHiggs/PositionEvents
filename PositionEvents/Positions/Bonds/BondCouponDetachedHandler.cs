using PositionEvents.Aggregates;
using PositionEvents.Utils;

namespace PositionEvents.Positions.Bonds
{
    public class BondCouponDetachedHandler : PositionEventHandler<BondCouponDetached>
    {
        public BondCouponDetachedHandler(ITimeProvider timeProvider, IMediator<PositionEvent> mediator)
            : base(timeProvider, mediator)
        { }


        public override void Apply(PortfolioStore position, BondCouponDetached positionEvent)
        {
            var coupon = positionEvent.Coupon;
            var positionSize = position.Get(positionEvent.Bond);

            position.Add(coupon, positionSize.Size);

            Mediator.AddEvent(
                new BondCouponPayed(coupon, (int)positionSize.Size),
                coupon.PaymentDate.ToInstant());
        }
    }
}
