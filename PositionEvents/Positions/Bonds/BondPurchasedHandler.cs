using PositionEvents.Pricing;
using PositionEvents.Utils;

namespace PositionEvents.Positions.Bonds
{
    public class BondPurchasedHandler : PositionEventHandler<BondPurchased>
    {
        public BondPurchasedHandler(ITimeProvider timeProvider) 
            : base(timeProvider)
        { }


        public override void Apply(Positions position, BondPurchased positionEvent)
        {
            var bond = positionEvent.PurchasedBond;
            var lots = positionEvent.Lots;
            var price = positionEvent.Price;
            var cost = DiscountingBondPricer.Default.SettlementCost(bond, price, lots);

            var newBondPosition = !position.Any(bond);

            // Apply immediately
            position.Add(bond, lots);
            position.Remove(cost); // Should add settlelag

            // Only add future events if new position
            if (!newBondPosition)
                return;

            // Emit future events
            foreach (var coupon in bond.Coupons.Coupons)
            {
                Mediator.AddEvent(
                    new BondCouponDetached(bond, coupon),
                    coupon.DetachmentDate.ToInstant());
            }

            Mediator.AddEvent(new BondMatured(bond), bond.MaturityDate.ToInstant());
        }
    }
}
