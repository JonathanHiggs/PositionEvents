using PositionEvents.Utils;

namespace PositionEvents.Positions.Bonds
{
    public class BondCouponDetachedHandler : PositionEventHandler<BondCouponDetached>
    {
        public BondCouponDetachedHandler(ITimeProvider timeProvider) 
            : base(timeProvider)
        { }


        public override void Apply(Positions position, BondCouponDetached positionEvent)
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
