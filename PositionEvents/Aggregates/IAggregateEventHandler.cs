using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionEvents.Aggregates
{
    public interface IAggregateEventHandler<TAggregate, TState, TEvent>
        where TAggregate : Aggregate<TState, TEvent>
        where TEvent : IAggregateEvent
        where TState : class, new()
    {
        Mediator<TAggregate, TState, TEvent> Mediator { get; }

        bool Validate(TState state, TEvent eventObj);
        void Apply(TState state, TEvent eventObj);
    }
}
