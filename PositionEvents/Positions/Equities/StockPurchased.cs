using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionEvents.Instruments;
using PositionEvents.Specifications;

namespace PositionEvents.Positions.Equities
{
    public class StockPurchased : IPositionEvent
    {
        public readonly Equity Equity;
        public readonly CurrencyAmount Price;
        public readonly uint Lots;

        public StockPurchased(Equity equity, CurrencyAmount price, uint lots)
        {
            Equity = equity;
            Price = price;
            Lots = lots;
        }
    }
}
