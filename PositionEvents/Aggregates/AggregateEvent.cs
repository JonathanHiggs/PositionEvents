using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionEvents.Aggregates
{
    public abstract class AggregateEvent : IAggregateEvent
    {
        public readonly EventMetadata Metadata;


        public AggregateEvent()
            : this(EventMetadata.Default)
        { }

        public AggregateEvent(EventMetadata metadata)
        {
            Metadata = metadata;
        }
    }
}
