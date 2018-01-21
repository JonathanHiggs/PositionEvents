using PositionEvents.Aggregates;

namespace PositionEvents.Positions.Management
{
    public class PositionClosed : PositionEvent
    {
        public PositionClosed()
            : base(EventMetadata.LowPriority)
        { }
    }
}
