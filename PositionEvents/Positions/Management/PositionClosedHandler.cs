using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionEvents.Aggregates;
using PositionEvents.Utils;

namespace PositionEvents.Positions.Management
{
    public class PositionClosedHandler : PositionEventHandler<PositionClosed>
    {
        public PositionClosedHandler(ITimeProvider timeProvider, IMediator<PositionEvent> mediator) 
            : base(timeProvider, mediator)
        { }

        public override void Apply(PortfolioStore position, PositionClosed positionEvent)
        {
            throw new NotImplementedException();
        }

        public override bool Validate(PortfolioStore position, PositionClosed positionEvent)
        {
            return !position.Any()
                && base.Validate(position, positionEvent);
        }
    }
}
