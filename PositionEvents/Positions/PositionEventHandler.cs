using PositionEvents.Aggregates;
using PositionEvents.Utils;

namespace PositionEvents.Positions
{
    public abstract class PositionEventHandler<TEvent> : AggregateEventHandler<Aggregate<Positions, IPositionEvent>, Positions, IPositionEvent>
        where TEvent : IPositionEvent
    {
        public PositionEventHandler(ITimeProvider timeProvider)
            : base(timeProvider)
        { }

        public override void Apply(Positions state, IPositionEvent eventObj)
        {
            Apply(state, (TEvent)eventObj);
        }

        public override bool Validate(Positions state, IPositionEvent eventObj)
        {
            return Validate(state, (TEvent)eventObj);
        }

        public abstract void Apply(Positions position, TEvent positionEvent);

        public virtual bool Validate(Positions position, TEvent positionEvent)
        {
            return position.Initialized;
        }
    }
}
