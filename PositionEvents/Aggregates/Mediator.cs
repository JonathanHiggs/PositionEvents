using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using PositionEvents.Utils;

namespace PositionEvents.Aggregates
{
    public class Mediator<TAggregate, TState, TEvent>
        where TAggregate : Aggregate<TState, TEvent>
        where TState : class, new()
        where TEvent : IAggregateEvent
    {
        private AggregateEventStore<TAggregate, TState, TEvent> events;


        public Mediator(ITimeProvider timeProvider)
        {
            events = new AggregateEventStore<TAggregate, TState, TEvent>(timeProvider);
        }


        public void AddEvent(TEvent eventObj)
        {
            events.AddEvent(eventObj);
        }

        public void AddEvent(TEvent eventObj, Instant effective)
        {
            events.AddEvent(eventObj, effective);
        }

        public IEnumerable<AggregateEventLine<TEvent>> AllEvents()
        {
            return events.All();
        }
    }
}
