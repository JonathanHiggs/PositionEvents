using PositionEvents.Aggregates;

namespace PositionEvents.Positions.Management
{
    public class PositionCreated : PositionEvent
    {
        public string Portfolio { get; private set; }

        public PositionCreated(string portfolio)
            : base(EventMetadata.HighPriority)
        {
            Portfolio = portfolio;
        }
    }
}
