using NodaTime;

namespace PositionEvents.Aggregates
{
    public class AggregateEventLine<TEvent>
        where TEvent : IAggregateEvent
    {
        public Instant Raised { get; private set; }
        public Instant Effective { get; private set; }
        public TEvent Event { get; private set; }

        public AggregateEventLine(TEvent eventObject, Instant raised, Instant effective)
        {
            Raised = raised;
            Effective = effective;
            Event = eventObject;
        }
    }
}
