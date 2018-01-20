using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionEvents.Specifications
{
    public struct CurrencyAmount
    {
        public Currency Currency { get; private set; }
        public double Amount { get; private set; }
        
        public CurrencyAmount(Currency currency, double amount)
        {
            Currency = currency;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{Amount} {Currency}";
        }

        public static CurrencyAmount operator+(CurrencyAmount lhs, CurrencyAmount rhs)
        {
            if (lhs.Currency != rhs.Currency)
                throw new ArithmeticException();

            return new CurrencyAmount(lhs.Currency, lhs.Amount + rhs.Amount);
        }

        public static CurrencyAmount operator-(CurrencyAmount lhs, CurrencyAmount rhs)
        {
            if (lhs.Currency != rhs.Currency)
                throw new ArithmeticException();

            return new CurrencyAmount(lhs.Currency, lhs.Amount - rhs.Amount);
        }

        public static CurrencyAmount operator*(CurrencyAmount lhs, CurrencyAmount rhs)
        {
            if (lhs.Currency != rhs.Currency)
                throw new ArgumentNullException();

            return new CurrencyAmount(lhs.Currency, lhs.Amount * rhs.Amount);
        }

        public static CurrencyAmount operator*(CurrencyAmount lhs, double rhs)
        {
            return new CurrencyAmount(lhs.Currency, lhs.Amount * rhs);
        }

        public static CurrencyAmount operator/(CurrencyAmount lhs, double rhs)
        {
            return new CurrencyAmount(lhs.Currency, lhs.Amount / rhs);
        }
    }
}
