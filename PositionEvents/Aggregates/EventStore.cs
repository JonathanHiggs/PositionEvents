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
    public class EventStore<TAggregate, TState, TEvent>
        where TAggregate : Aggregate<TState, TEvent>
        where TState : class, new()
        where TEvent : AggregateEvent
    {
        private ITimeProvider timeProvider;
        private SortedList<EventLine<TEvent>, EventLine<TEvent>> events = new SortedList<EventLine<TEvent>, EventLine<TEvent>>(EventLineComparer<TEvent>.Default);


        public EventStore(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider;
        }


        public void AddEvent(TEvent aggregateEvent)
        {
            var now = timeProvider.CurrentInstant;
            var line = new EventLine<TEvent>(aggregateEvent, now, now);
            events.Add(line, line);
        }


        public void AddEvent(TEvent aggregateEvent, Instant effective)
        {
            var now = timeProvider.CurrentInstant;
            var line = new EventLine<TEvent>(aggregateEvent, now, effective);
            events.Add(line, line);
        }


        public void AddEvent(TEvent aggregateEvent, Instant raised, Instant effective)
        {
            var line = new EventLine<TEvent>(aggregateEvent, raised, effective);
            events.Add(line, line);
        }


        public IEnumerable<EventLine<TEvent>> All()
        {
            return events.Values;
        }


        public void Clear()
        {
            events.Clear();
        }
    }
}
