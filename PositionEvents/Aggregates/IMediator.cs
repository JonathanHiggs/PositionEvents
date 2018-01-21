using NodaTime;

namespace PositionEvents.Aggregates
{
    public interface IMediator<TEvent> where TEvent : AggregateEvent
    {
        void AddEvent(TEvent eventObj);
        void AddEvent(TEvent eventObj, Instant effective);
    }
}