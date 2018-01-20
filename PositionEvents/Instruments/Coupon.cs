using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using PositionEvents.Specifications;

namespace PositionEvents.Instruments
{
    public class Coupon : IInstrument
    {
        public IssueId BondIssueId { get; set; }
        public CurrencyAmount Notional { get; set; }
        public double Rate { get; set; }
        public double YearFraction { get; set; }
        public ZonedDateTime AccrualStart { get; set; }
        public ZonedDateTime DetachmentDate { get; set; }
        public ZonedDateTime PaymentDate { get; set; }

        public string Description => $"{BondIssueId.CUSIP}|{PaymentDate.Year}-{PaymentDate.Month}-{PaymentDate.Day}";
    }
}
