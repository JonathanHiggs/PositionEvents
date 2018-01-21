using PositionEvents.Aggregates;
using PositionEvents.Utils;

namespace PositionEvents.Positions
{
    public abstract class PositionEventHandler<TEvent> : AggregateEventHandler<Aggregate<PortfolioStore, PositionEvent>, PortfolioStore, PositionEvent>
        where TEvent : PositionEvent
    {
        public PositionEventHandler(ITimeProvider timeProvider, IMediator<PositionEvent> mediator)
            : base(timeProvider, mediator)
        { }

        public override void Apply(PortfolioStore state, PositionEvent eventObj)
        {
            Apply(state, (TEvent)eventObj);
        }

        public override bool Validate(PortfolioStore state, PositionEvent eventObj)
        {
            return Validate(state, (TEvent)eventObj);
        }

        public abstract void Apply(PortfolioStore position, TEvent positionEvent);

        public virtual bool Validate(PortfolioStore position, TEvent positionEvent)
        {
            return position.Initialized;
        }
    }
}
