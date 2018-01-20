using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using PositionEvents.Specifications;

namespace PositionEvents.Instruments
{
    public class Bond : IInstrument
    {
        public IssueId IssueId { get; set; }
        public ZonedDateTime IssueDate { get; set; }
        public ZonedDateTime MaturityDate { get; set; }
        public CurrencyAmount Notional { get; set; }
        public CouponSchedule Coupons { get; set; }

        public string Description => IssueId.CUSIP;


        public override bool Equals(object obj)
        {
            var bond = obj as Bond;
            return obj != null
                && IssueId == bond.IssueId;
        }

        public override int GetHashCode()
        {
            return -749940667 + EqualityComparer<IssueId>.Default.GetHashCode(IssueId);
        }
    }
}
