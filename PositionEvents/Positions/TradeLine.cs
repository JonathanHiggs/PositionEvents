using NodaTime;
using PositionEvents.Instruments;
using PositionEvents.Specifications;

namespace PositionEvents.Positions
{
    public struct TradeLine
    {
        public readonly LocalDate TradeDate;
        public readonly LocalDate SettleDate;
        public readonly string Portfolio;
        public readonly IInstrument Instrument;
        public readonly CurrencyAmount Price;
        public readonly double Size;

        public TradeLine(LocalDate tradeDate, LocalDate settleDate, string portfolio, IInstrument instrument, CurrencyAmount price, double size)
        {
            TradeDate = tradeDate;
            SettleDate = settleDate;
            Portfolio = portfolio;
            Instrument = instrument;
            Price = price;
            Size = size;
        }
    }
}