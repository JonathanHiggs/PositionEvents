using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;

namespace PositionEvents.Aggregates
{
    public class EventQueue<TEvent>
        where TEvent : AggregateEvent
    {
        private readonly SortedList<EventLine<TEvent>, EventLine<TEvent>> events;


        public EventQueue(IEnumerable<EventLine<TEvent>> events)
        {
            this.events = new SortedList<EventLine<TEvent>, EventLine<TEvent>>(
                events.ToDictionary(l => l, l => l), EventLineComparer<TEvent>.Default);
        }


        public void Add(EventLine<TEvent> aggregateEvent)
        {
            events.Add(aggregateEvent, aggregateEvent);
        }


        public void AddRange(IEnumerable<EventLine<TEvent>> aggregateEvents)
        {
            foreach (var aggregateEvent in aggregateEvents)
            {
                events.Add(aggregateEvent, aggregateEvent);
            }
        }


        public EventLine<TEvent> Pop()
        {
            var aggregateEvent = events.Values[0];
            events.RemoveAt(0);

            return aggregateEvent;
        }


        public bool TryPop(out EventLine<TEvent> aggregateEvent)
        {
            if (!events.Any())
            {
                aggregateEvent = default(EventLine<TEvent>);
                return false;
            }

            aggregateEvent = Pop();
            return true;
        }
    }
}
