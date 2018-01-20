using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using PositionEvents.Utils;

namespace PositionEvents.Aggregates
{
    public class AggregateEventStore<TAggregate, TState, TEvent>
        where TAggregate : Aggregate<TState, TEvent>
        where TState : class, new()
        where TEvent : IAggregateEvent
    {
        private ITimeProvider timeProvider;
        private List<AggregateEventLine<TEvent>> events = new List<AggregateEventLine<TEvent>>();


        public AggregateEventStore(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider;
        }


        public void AddEvent(TEvent aggregateEvent)
        {
            var now = timeProvider.CurrentInstant;
            events.Add(new AggregateEventLine<TEvent>(
                aggregateEvent, now, now));
        }


        public void AddEvent(TEvent aggregateEvent, Instant effective)
        {
            var now = timeProvider.CurrentInstant;
            events.Add(new AggregateEventLine<TEvent>(
                aggregateEvent, now, effective));
        }


        public void AddEvent(TEvent aggregateEvent, Instant raised, Instant effective)
        {
            events.Add(new AggregateEventLine<TEvent>(
                aggregateEvent, raised, effective));
        }


        public IEnumerable<AggregateEventLine<TEvent>> All()
        {
            return events;
        }
    }
}
