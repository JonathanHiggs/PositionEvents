using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionEvents.Instruments;
using PositionEvents.Specifications;

namespace PositionEvents.Pricing
{
    public class DiscountingBondCouponPricer
    {
        private static DiscountingBondCouponPricer defaultPricer = new DiscountingBondCouponPricer();
        public static DiscountingBondCouponPricer Default => defaultPricer;


        public CurrencyAmount Amount(Coupon coupon, int lots)
        {
            return coupon.Notional * coupon.Rate * coupon.YearFraction * lots;
        }
    }
}
