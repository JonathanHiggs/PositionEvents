using PositionEvents.Aggregates;
using PositionEvents.Instruments;
using PositionEvents.Pricing;
using PositionEvents.Utils;

namespace PositionEvents.Positions.Bonds
{
    public class BondMaturedHandler : PositionEventHandler<BondMatured>
    {
        public BondMaturedHandler(ITimeProvider timeProvider, IMediator<PositionEvent> mediator) 
            : base(timeProvider, mediator)
        { }


        public override void Apply(PortfolioStore position, BondMatured positionEvent)
        {
            var bond = positionEvent.Bond;
            var line = position.Get(bond);

            var value = DiscountingPaymentPricer.Default.Amount(bond.Notional, (int)line.Size);
            var payment = new Payment(value.Currency, value.Amount, bond.MaturityDate);

            position.Add(value);
            position.Remove(bond, line.Size);
        }
    }
}
