using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionEvents.Utils;

namespace PositionEvents.Positions.Equities
{
    public class StockSoldHandler : PositionEventHandler<StockSold>
    {
        public StockSoldHandler(ITimeProvider timeProvider) 
            : base(timeProvider)
        { }

        public override void Apply(Positions position, StockSold positionEvent)
        {
            var equity = positionEvent.Equity;
            var price = positionEvent.Price;
            var lots = positionEvent.Lots;
            var revenue = price * lots;

            position.Add(revenue);
            position.Remove(equity, lots);
        }

        public override bool Validate(Positions position, StockSold positionEvent)
        {
            return position.Get(positionEvent.Equity).Size > positionEvent.Lots
                && base.Validate(position, positionEvent);
        }
    }
}
