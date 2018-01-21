using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionEvents.Aggregates
{
    public class EventLineComparer<T> : Comparer<EventLine<T>>
        where T : AggregateEvent
    {
        public override int Compare(EventLine<T> x, EventLine<T> y)
        {
            return x.CompareTo(y);
        }
    }
}
