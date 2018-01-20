using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using PositionEvents.Instruments;
using PositionEvents.Positions.Bonds;
using PositionEvents.Positions.Equities;
using PositionEvents.Specifications;

namespace PositionEvents.Positions
{
    public static class PositionHelpers
    {
        public static void Purchase(this PositionAggregate aggregate, IInstrument instrument, double price, Currency currency, uint lots)
        {
            var effective = SystemClock.Instance.GetCurrentInstant();
            aggregate.Purchase(instrument, price, currency, lots, effective);
        }

        public static void Purchase(this PositionAggregate aggregate, IInstrument instrument, double price, Currency currency, uint lots, Instant effective)
        {
            if (instrument is Bond)
            {
                var bond = instrument as Bond;
                aggregate.EventStore.AddEvent(new BondPurchased(bond, new BondDirtyPrice(price), lots), effective);
            }
            else if (instrument is Equity)
            {
                var equity = instrument as Equity;
                var caPrice = new CurrencyAmount(currency, price);
                aggregate.EventStore.AddEvent(new StockPurchased(equity, caPrice, lots), effective);
            }
        }
    }
}
