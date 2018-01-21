using System;
using System.Diagnostics;
using NodaTime;

namespace PositionEvents.Aggregates
{
    [DebuggerDisplay("Event = {Event.GetType().Name}")]
    public class EventLine<TEvent> : IComparable<EventLine<TEvent>>
        where TEvent : AggregateEvent
    {
        public Instant Raised { get; private set; }
        public Instant Effective { get; private set; }
        public TEvent Event { get; private set; }

        public EventLine(TEvent eventObject, Instant raised, Instant effective)
        {
            Raised = raised;
            Effective = effective;
            Event = eventObject;
        }

        public int CompareTo(EventLine<TEvent> other)
        {
            var effectiveComparison = Effective.CompareTo(other.Effective);
            if (effectiveComparison != 0)
                return effectiveComparison;

            var raisedComparison = Raised.CompareTo(other.Raised);
            if (raisedComparison != 0)
                return raisedComparison;

            var priorityComparison = Event.Metadata.Priority.CompareTo(other.Event.Metadata.Priority);
            if (priorityComparison != 0)
                return priorityComparison;

            // Hopefully never get here
            return 0;
        }
    }
}
