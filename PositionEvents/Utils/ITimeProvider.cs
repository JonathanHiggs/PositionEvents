using NodaTime;

namespace PositionEvents.Utils
{
    public interface ITimeProvider
    {
        Instant CurrentInstant { get; }
    }
}