using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionEvents.Instruments
{
    public class CouponSchedule
    {
        public readonly List<Coupon> Coupons;
        

        public CouponSchedule(IEnumerable<Coupon> coupons)
        {
            Coupons = coupons.ToList();
        }


        private static CouponSchedule empty = new CouponSchedule(new List<Coupon>(0));
        public static CouponSchedule Empty => empty;
    }
}
