using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionEvents.Utils;

namespace PositionEvents.Positions.Management
{
    public class PositionClosedHandler : PositionEventHandler<PositionClosed>
    {
        public PositionClosedHandler(ITimeProvider timeProvider) 
            : base(timeProvider)
        { }

        public override void Apply(Positions position, PositionClosed positionEvent)
        {
            throw new NotImplementedException();
        }

        public override bool Validate(Positions position, PositionClosed positionEvent)
        {
            return !position.Any()
                && base.Validate(position, positionEvent);
        }
    }
}
