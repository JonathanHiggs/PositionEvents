using System;
using NodaTime;
using PositionEvents.Aggregates;
using PositionEvents.Positions.Bonds;
using PositionEvents.Positions.Equities;
using PositionEvents.Positions.Management;
using PositionEvents.Utils;

namespace PositionEvents.Positions
{
    public class Portfolio : Aggregate<PortfolioStore, PositionEvent>
    {
        public override IAggregateEventHandler<Aggregate<PortfolioStore, PositionEvent>, PortfolioStore, PositionEvent> GetHandler(PositionEvent aggregateEvent, ITimeProvider timeProvider, IMediator<PositionEvent> mediator)
        {
            if (aggregateEvent == null)
                throw new InvalidCastException();

            // Management
            if (aggregateEvent is PositionCreated)
                return new PositionCreatedHandler(timeProvider, mediator);

            // Bonds
            if (aggregateEvent is BondPurchased)
                return new BondPurchasedHandler(timeProvider, mediator);

            if (aggregateEvent is BondCouponDetached)
                return new BondCouponDetachedHandler(timeProvider, mediator);

            if (aggregateEvent is BondCouponPayed)
                return new BondCouponPayedHandler(timeProvider, mediator);

            if (aggregateEvent is BondMatured)
                return new BondMaturedHandler(timeProvider, mediator);

            // Equity
            if (aggregateEvent is StockPurchased)
                return new StockPurchasedHandler(timeProvider, mediator);

            if (aggregateEvent is StockSold)
                return new StockSoldHandler(timeProvider, mediator);

            throw new InvalidOperationException();
        }

        public static Portfolio Create(string portfolio)
        {
            return Create(portfolio, SystemClock.Instance.GetCurrentInstant());
        }

        public static Portfolio Create(string portfolio, Instant effective)
        {
            var agg = new Portfolio();
            agg.EventStore.AddEvent(new PositionCreated(portfolio), effective, effective);
            return agg;
        }
    }
}
