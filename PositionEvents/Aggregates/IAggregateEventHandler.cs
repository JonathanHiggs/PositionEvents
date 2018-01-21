using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionEvents.Aggregates
{
    public interface IAggregateEventHandler<TAggregate, TState, TEvent>
        where TAggregate : Aggregate<TState, TEvent>
        where TEvent : AggregateEvent
        where TState : class, new()
    {
        IMediator<TEvent> Mediator { get; }

        bool Validate(TState state, TEvent eventObj);
        void Apply(TState state, TEvent eventObj);
    }
}
