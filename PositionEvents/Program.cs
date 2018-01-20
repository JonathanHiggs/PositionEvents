using System;
using System.Collections.Generic;
using NodaTime;

using PositionEvents.Instruments;
using PositionEvents.Positions;
using PositionEvents.Positions.Bonds;
using PositionEvents.Positions.Management;
using PositionEvents.Specifications;
using PositionEvents.Utils;

namespace PositionEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            var bond = GetBond();
            var position = PositionAggregate.Create("TestPortfolio", DT(2018, 1, 18).ToInstant());

            position.Purchase(bond, 100.0, Currency.USD, 20);

            var t1 = SystemClock.Instance.GetCurrentInstant();

            position.Purchase(bond, 98.50, Currency.USD, 10, DT(2018, 1, 19).ToInstant()); // Backdated
            
            var t2 = SystemClock.Instance.GetCurrentInstant();
            
            ToCSV(position.StateAt(t1, DT(2018, 1, 22).ToInstant()));
            ToCSV(position.StateAt(t2, DT(2018, 5, 22).ToInstant()));
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

        public static ZonedDateTime DT(int year, int month, int day)
        {
            return (new LocalDate(year, month, day)).AtStartOfDayInZone(DateTimeZone.Utc);
        }

        public static void ToCSV(Positions.Positions position)
        {
            Console.WriteLine("Instrument,Portfolio,Size");
            foreach (var line in position.Lines)
            {
                Console.WriteLine($"{line.Instrument.Description},{position.Portfolio},{line.Size.Size}");
            }
            Console.WriteLine();
        }
    }
}
