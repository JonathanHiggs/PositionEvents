using System.Collections.Generic;

using NodaTime;

using PositionEvents.Instruments;
using PositionEvents.Positions;
using PositionEvents.Specifications;

namespace PositionEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            var bond = GetBond();
            var position =
                Portfolio
                    .Create("TestPortfolio", At(2018, 1, 18, 16, 0))
                    .Purchase(bond, 100.0, Currency.USD, 20, At(2018, 1, 18, 16, 0))
                    .Purchase(bond, 98.50, Currency.USD, 10, At(2018, 1, 19, 12, 30))
                    .Purchase(bond, 99.250, Currency.USD, 10, At(2018, 1, 18, 16, 15), At(2018, 1, 21, 13, 0));

            var eod18 = At(2018, 1, 18, 16, 15);
            var eod19 = At(2018, 1, 19, 16, 15);
            var eod22 = At(2018, 1, 22, 16, 15);

            position.StateAt(eod18).ToCSV("EoD 18th");
            position.StateAt(eod18, eod19).ToCSV("EoD 19th forward from EoD 18th");
            position.StateAt(eod18, eod22).ToCSV("EoD 22nd forward from EoD 18th");

            position.StateAt(eod19, eod18).ToCSV("EoD 18th back from EoD 19th");
            position.StateAt(eod19).ToCSV("EoD 19th");
            position.StateAt(eod19, eod22).ToCSV("EoD 22nd forward from EoD 19th");

            position.StateAt(eod22, eod18).ToCSV("EoD 18th back from EoD 22nd");
            position.StateAt(eod22, eod19).ToCSV("EoD 19th back from EoD 22th");
            position.StateAt(eod22).ToCSV("EoD 22th");
        }

        public static Bond GetBond()
        {
            var issueId = new IssueId("9128283D0");
            var notional = new CurrencyAmount(Currency.USD, 100000.0);

            var coupon1 = new Coupon
            {
                AccrualStart = DT(2018, 1, 1),
                BondIssueId = issueId,
                DetachmentDate = DT(2018, 5, 29),
                Notional = notional,
                PaymentDate = DT(2018, 6, 1),
                Rate = 0.025,
                YearFraction = 0.5
            };

            var coupon2 = new Coupon
            {
                AccrualStart = DT(2018, 6, 1),
                BondIssueId = issueId,
                DetachmentDate = DT(2018, 12, 29),
                Notional = notional,
                PaymentDate = DT(2019, 1, 1),
                Rate = 0.025,
                YearFraction = 0.5
            };

            return new Bond
            {
                IssueId = issueId,
                IssueDate = DT(2018, 1, 1),
                MaturityDate = DT(2019, 1, 1),
                Notional = notional,
                Coupons = new CouponSchedule(new List<Coupon> { coupon1, coupon2 })
            };
        }

        public static Instant At(int year, int month, int day, int hour, int minute)
        {
            var ldt = new LocalDateTime(year, month, day, hour, minute);
            var tz = DateTimeZoneProviders.Bcl.GetSystemDefault();
            return ldt.InZoneLeniently(tz).ToInstant();
        }

        public static ZonedDateTime DT(int year, int month, int day)
        {
            return (new LocalDate(year, month, day)).AtStartOfDayInZone(DateTimeZone.Utc);
        }
    }
}
