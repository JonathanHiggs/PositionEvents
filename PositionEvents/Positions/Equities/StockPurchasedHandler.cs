using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionEvents.Utils;

namespace PositionEvents.Positions.Equities
{
    public class StockPurchasedHandler : PositionEventHandler<StockPurchased>
    {
        public StockPurchasedHandler(ITimeProvider timeProvider) 
            : base(timeProvider)
        { }

        public override void Apply(Positions position, StockPurchased positionEvent)
        {
            var equity = positionEvent.Equity;
            var price = positionEvent.Price;
            var lots = positionEvent.Lots;
            var cost = price * lots;

            position.Add(equity, lots);
            position.Remove(cost);
        }
    }
}
