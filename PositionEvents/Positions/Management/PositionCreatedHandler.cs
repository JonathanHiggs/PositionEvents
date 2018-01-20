using PositionEvents.Instruments;
using PositionEvents.Utils;

namespace PositionEvents.Positions.Management
{
    public class PositionCreatedHandler : PositionEventHandler<PositionCreated>
    {
        public PositionCreatedHandler(ITimeProvider timeProvider) 
            : base(timeProvider)
        { }


        public override void Apply(Positions position, PositionCreated positionEvent)
        {
            position.Portfolio = positionEvent.Portfolio;
            position.Initialized = true;
            position.CreatedAt = TimeProvider.CurrentInstant;
        }


        public override bool Validate(Positions position, PositionCreated positionEvent)
        {
            return position.Initialized == false;
        }
    }
}
