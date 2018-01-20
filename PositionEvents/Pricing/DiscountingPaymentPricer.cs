using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionEvents.Instruments;
using PositionEvents.Specifications;

namespace PositionEvents.Pricing
{
    public class DiscountingPaymentPricer
    {
        private static DiscountingPaymentPricer defaultPricer = new DiscountingPaymentPricer();
        public static DiscountingPaymentPricer Default => defaultPricer;


        public CurrencyAmount Amount(CurrencyAmount notional, int lots)
        {
            return notional * lots;
        }
    }
}
