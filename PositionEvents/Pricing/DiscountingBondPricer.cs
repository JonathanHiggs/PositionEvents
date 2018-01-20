using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionEvents.Instruments;
using PositionEvents.Specifications;

namespace PositionEvents.Pricing
{
    public class DiscountingBondPricer
    {
        private static DiscountingBondPricer defaultPricer = new DiscountingBondPricer();
        public static DiscountingBondPricer Default = defaultPricer;


        public CurrencyAmount SettlementCost(Bond bond, BondDirtyPrice dirtyPrice, uint lots)
        {
            var amount = bond.Notional.Amount * dirtyPrice.Value / 100.0 * lots;
            return new CurrencyAmount(bond.Notional.Currency, amount);
        }
    }
}
