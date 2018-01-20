using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionEvents.Aggregates;

namespace PositionEvents.Positions
{
    public interface IPositionEvent : IAggregateEvent
    { }
}
