using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionEvents.Aggregates;
using PositionEvents.Utils;

namespace PositionEvents.Positions.Equities
{
    public class StockPurchasedHandler : PositionEventHandler<StockPurchased>
    {
        public StockPurchasedHandler(ITimeProvider timeProvider, IMediator<PositionEvent> mediator) 
            : base(timeProvider, mediator)
        { }

        public override void Apply(PortfolioStore position, StockPurchased positionEvent)
        {
            var equity = positionEvent.Equity;
            var price = positionEvent.Price;
            var lots = positionEvent.Lots;
            var cost = price * lots;

            var trade = new TradeLine(
                TimeProvider.CurrentInstant.InUtc().Date,
                TimeProvider.CurrentInstant.InUtc().Date,
                position.Portfolio,
                equity,
                price,
                lots
            );

            position.Add(trade);
            position.Add(equity, lots);
            position.Remove(cost);
        }
    }
}
