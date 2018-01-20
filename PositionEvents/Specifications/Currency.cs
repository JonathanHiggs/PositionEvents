using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionEvents.Utils;

namespace PositionEvents.Specifications
{
    public class Currency : Enumeration
    {
        public static Currency USD = new Currency(1, "USD");
        public static Currency EUR = new Currency(2, "EUR");
        public static Currency GBP = new Currency(3, "GBP");

        protected Currency() { }

        public Currency(int id, string name)
            : base(id, name)
        { }

        public static IEnumerable<Currency> All()
        {
            return new[] { USD, EUR, GBP };
        }
    }
}
