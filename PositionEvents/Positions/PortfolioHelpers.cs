using System;

using NodaTime;

using PositionEvents.Instruments;
using PositionEvents.Positions.Bonds;
using PositionEvents.Positions.Equities;
using PositionEvents.Specifications;

namespace PositionEvents.Positions
{
    public static class PortfolioHelpers
    {
        public static Portfolio Purchase(this Portfolio portfolio, IInstrument instrument, double price, Currency currency, uint lots)
        {
            var effective = SystemClock.Instance.GetCurrentInstant();
            portfolio.Purchase(instrument, price, currency, lots, effective);
            return portfolio;
        }

        public static Portfolio Purchase(this Portfolio portfolio, IInstrument instrument, double price, Currency currency, uint lots, Instant effective)
        {
            return Purchase(portfolio, instrument, price, currency, lots, effective, effective);
        }

        public static Portfolio Purchase(this Portfolio portfolio, IInstrument instrument, double price, Currency currency, uint lots, Instant effective, Instant raised)
        {
            if (instrument is Bond)
            {
                var bond = instrument as Bond;
                portfolio.EventStore.AddEvent(new BondPurchased(bond, new BondDirtyPrice(price), lots), raised, effective);
            }
            else if (instrument is Equity)
            {
                var equity = instrument as Equity;
                var caPrice = new CurrencyAmount(currency, price);
                portfolio.EventStore.AddEvent(new StockPurchased(equity, caPrice, lots), raised, effective);
            }
            return portfolio;
        }
        
        public static void ToCSV(this PortfolioStore position, string header)
        {
            Console.WriteLine(header);
            Console.WriteLine("Instrument,Portfolio,Size");
            foreach (var line in position.Lines)
            {
                Console.WriteLine($"{line.Instrument.Description},{position.Portfolio},{line.Size.Size}");
            }
            Console.WriteLine();
            Console.WriteLine("TradeDate,SettleDate,Portfolio,Instrument,Price,Currency,Size");
            foreach(var trade in position.Trades)
            {
                Console.WriteLine($"{trade.TradeDate},{trade.SettleDate},{trade.Portfolio},{trade.Instrument.Description},{trade.Price.Amount},{trade.Price.Currency},{trade.Size}");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
