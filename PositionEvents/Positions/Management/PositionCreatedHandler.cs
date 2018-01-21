using PositionEvents.Aggregates;
using PositionEvents.Instruments;
using PositionEvents.Utils;

namespace PositionEvents.Positions.Management
{
    public class PositionCreatedHandler : PositionEventHandler<PositionCreated>
    {
        public PositionCreatedHandler(ITimeProvider timeProvider, IMediator<PositionEvent> mediator) 
            : base(timeProvider, mediator)
        { }


        public override void Apply(PortfolioStore position, PositionCreated positionEvent)
        {
            position.Portfolio = positionEvent.Portfolio;
            position.Initialized = true;
            position.CreatedAt = TimeProvider.CurrentInstant;
        }


        public override bool Validate(PortfolioStore position, PositionCreated positionEvent)
        {
            return position.Initialized == false;
        }
    }
}
