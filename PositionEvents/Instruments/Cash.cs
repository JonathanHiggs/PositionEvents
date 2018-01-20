using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionEvents.Specifications;

namespace PositionEvents.Instruments
{
    public class Cash : IInstrument
    {
        public Currency Currency { get; set; }
        public string Description => Currency.Name;
        
        public Cash(Currency currency)
        {
            Currency = currency;
        }

        public static Cash From(Currency currency)
        {
            return new Cash(currency);
        }

        public static Cash From(CurrencyAmount currencyAmount)
        {
            return new Cash(currencyAmount.Currency);
        }


        public override int GetHashCode()
        {
            return Currency.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var cash = obj as Cash;
            return cash != null
                && Currency.Equals(cash.Currency);
        }
    }
}
