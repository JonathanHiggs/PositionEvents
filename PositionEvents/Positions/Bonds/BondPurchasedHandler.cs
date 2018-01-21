using PositionEvents.Aggregates;
using PositionEvents.Pricing;
using PositionEvents.Specifications;
using PositionEvents.Utils;

namespace PositionEvents.Positions.Bonds
{
    public class BondPurchasedHandler : PositionEventHandler<BondPurchased>
    {
        public BondPurchasedHandler(ITimeProvider timeProvider, IMediator<PositionEvent> mediator) 
            : base(timeProvider, mediator)
        { }


        public override void Apply(PortfolioStore position, BondPurchased positionEvent)
        {
            var bond = positionEvent.PurchasedBond;
            var lots = positionEvent.Lots;
            var price = positionEvent.Price;
            var cost = DiscountingBondPricer.Default.SettlementCost(bond, price, lots);

            var newBondPosition = !position.Any(bond);
            
            // Apply immediately
            position.Add(new TradeLine(
                TimeProvider.CurrentInstant.InUtc().Date,
                TimeProvider.CurrentInstant.InUtc().Date,
                position.Portfolio,
                bond,
                new CurrencyAmount(bond.Notional.Currency, price.Value),
                lots
            ));

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
