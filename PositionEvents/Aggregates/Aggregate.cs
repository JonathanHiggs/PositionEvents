using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using PositionEvents.Utils;

namespace PositionEvents.Aggregates
{
    public abstract class Aggregate<TStore, TEvent> 
        where TStore : class, new()
        where TEvent : IAggregateEvent
    {
        private readonly AggregateEventStore<Aggregate<TStore, TEvent>, TStore, TEvent> eventStore = new AggregateEventStore<Aggregate<TStore, TEvent>, TStore, TEvent>(new TimeProvider());
        

        public AggregateEventStore<Aggregate<TStore, TEvent>, TStore, TEvent> EventStore => eventStore;

        
        public TStore StateAt(Instant instant)
        {
            return StateAt(instant, instant);
        }


        public TStore StateAt(Instant instant, Instant forcast)
        {
            var state = new TStore();
            var timeProvider = new ControlledTimeProvider();
            var eventQueue = new AggregateEventQueue<TEvent>(eventStore.All().Where(l => l.Raised <= instant));

            AggregateEventLine<TEvent> current;
            while (eventQueue.TryPop(out current) && current.Effective <= forcast)
            {
                timeProvider.SetInstant(current.Effective);

                var handler = GetHandler(current.Event, timeProvider);

                if (!handler.Validate(state, current.Event))
                    throw new InvalidOperationException();

                handler.Apply(state, current.Event);

                // Merge event stores
                eventQueue.AddRange(handler.Mediator.AllEvents());
            }

            return state;
        }


        public abstract IAggregateEventHandler<Aggregate<TStore, TEvent>, TStore, TEvent> GetHandler(TEvent aggregateEvent, ITimeProvider timeProvider);
    }
}
