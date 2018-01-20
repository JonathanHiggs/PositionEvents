using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using PositionEvents.Specifications;

namespace PositionEvents.Instruments
{
    public class Payment : IInstrument
    {
        public Payment(Currency currency, double amount, ZonedDateTime paymentDate)
        {
            Currency = currency;
            Amount = amount;
            PaymentDate = paymentDate;
        }
        
        public Currency Currency { get; set; }
        public double Amount { get; set; }
        public ZonedDateTime PaymentDate { get; set; }

        public string Description => $"{Amount} {Currency.Name}";
    }
}
