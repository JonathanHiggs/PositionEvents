using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionEvents.Aggregates;
using PositionEvents.Utils;

namespace PositionEvents.Positions.Equities
{
    public class StockSoldHandler : PositionEventHandler<StockSold>
    {
        public StockSoldHandler(ITimeProvider timeProvider, IMediator<PositionEvent> mediator) 
            : base(timeProvider, mediator)
        { }

        public override void Apply(PortfolioStore position, StockSold positionEvent)
        {
            var equity = positionEvent.Equity;
            var price = positionEvent.Price;
            var lots = positionEvent.Lots;
            var revenue = price * lots;

            var trade = new TradeLine(
                TimeProvider.CurrentInstant.InUtc().Date,
                TimeProvider.CurrentInstant.InUtc().Date,
                position.Portfolio,
                equity,
                price,
                -lots
            );

            position.Add(trade);

            position.Add(revenue);
            position.Remove(equity, lots);
        }

        public override bool Validate(PortfolioStore position, StockSold positionEvent)
        {
            return position.Get(positionEvent.Equity).Size > positionEvent.Lots
                && base.Validate(position, positionEvent);
        }
    }
}
