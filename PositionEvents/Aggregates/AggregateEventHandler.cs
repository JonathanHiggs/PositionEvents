using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionEvents.Utils;

namespace PositionEvents.Aggregates
{
    public abstract class AggregateEventHandler<TAggregate, TState, TEvent> : IAggregateEventHandler<TAggregate, TState, TEvent>
        where TAggregate : Aggregate<TState, TEvent>
        where TEvent : IAggregateEvent
        where TState : class, new()
    {
        private readonly Mediator<TAggregate, TState, TEvent> mediator;
        private readonly ITimeProvider timeProvider;


        public AggregateEventHandler(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider;
            this.mediator = new Mediator<TAggregate, TState, TEvent>(timeProvider);
        }
        

        public Mediator<TAggregate, TState, TEvent> Mediator => mediator;


        public ITimeProvider TimeProvider => timeProvider;


        public abstract bool Validate(TState state, TEvent eventObj);

        public abstract void Apply(TState state, TEvent eventObj);
    }
}
