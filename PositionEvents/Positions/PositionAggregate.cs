using System;
using NodaTime;
using PositionEvents.Aggregates;
using PositionEvents.Positions.Bonds;
using PositionEvents.Positions.Equities;
using PositionEvents.Positions.Management;
using PositionEvents.Utils;

namespace PositionEvents.Positions
{
    public class PositionAggregate : Aggregate<Positions, IPositionEvent>
    {
        public override IAggregateEventHandler<Aggregate<Positions, IPositionEvent>, Positions, IPositionEvent> GetHandler(IPositionEvent aggregateEvent, ITimeProvider timeProvider)
        {
            if (aggregateEvent == null)
                throw new InvalidCastException();

            // Management
            if (aggregateEvent is PositionCreated)
                return new PositionCreatedHandler(timeProvider);

            // Bonds
            if (aggregateEvent is BondPurchased)
                return new BondPurchasedHandler(timeProvider);

            if (aggregateEvent is BondCouponDetached)
                return new BondCouponDetachedHandler(timeProvider);

            if (aggregateEvent is BondCouponPayed)
                return new BondCouponPayedHandler(timeProvider);

            if (aggregateEvent is BondMatured)
                return new BondMaturedHandler(timeProvider);

            // Equity
            if (aggregateEvent is StockPurchased)
                return new StockPurchasedHandler(timeProvider);

            if (aggregateEvent is StockSold)
                return new StockSoldHandler(timeProvider);

            throw new InvalidOperationException();
        }

        public static PositionAggregate Create(string portfolio)
        {
            return Create(portfolio, SystemClock.Instance.GetCurrentInstant());
        }

        public static PositionAggregate Create(string portfolio, Instant effective)
        {
            var agg = new PositionAggregate();
            agg.EventStore.AddEvent(new PositionCreated(portfolio));
            return agg;
        }
    }
}
