using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;

namespace PositionEvents.Aggregates
{
    public class AggregateEventQueue<TEvent>
        where TEvent : IAggregateEvent
    {
        private readonly SortedList<Instant, AggregateEventLine<TEvent>> events;


        public AggregateEventQueue(IEnumerable<AggregateEventLine<TEvent>> events)
        {
            this.events = new SortedList<Instant, AggregateEventLine<TEvent>>(
                events.ToDictionary(l => l.Effective, l => l)
            );
        }


        public void Add(AggregateEventLine<TEvent> aggregateEvent)
        {
            events.Add(aggregateEvent.Effective, aggregateEvent);
        }


        public void AddRange(IEnumerable<AggregateEventLine<TEvent>> aggregateEvents)
        {
            foreach (var aggregateEvent in aggregateEvents)
            {
                events.Add(aggregateEvent.Effective, aggregateEvent);
            }
        }


        public AggregateEventLine<TEvent> Pop()
        {
            var aggregateEvent = events.First().Value;
            events.RemoveAt(0);

            return aggregateEvent;
        }


        public bool TryPop(out AggregateEventLine<TEvent> aggregateEvent)
        {
            if (!events.Any())
            {
                aggregateEvent = default(AggregateEventLine<TEvent>);
                return false;
            }

            aggregateEvent = Pop();
            return true;
        }
    }
}
