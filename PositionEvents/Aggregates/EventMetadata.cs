using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionEvents.Aggregates
{
    public class EventMetadata
    {
        public readonly EventPriority Priority;
        
        public EventMetadata(EventPriority priority)
        {
            Priority = priority;
        }

        private static EventMetadata highPriority = new EventMetadata(EventPriority.High);
        public static EventMetadata HighPriority => highPriority;

        private static EventMetadata defaultMetadata = new EventMetadata(EventPriority.Default);
        public static EventMetadata Default => defaultMetadata;

        private static EventMetadata lowPriority = new EventMetadata(EventPriority.Low);
        public static EventMetadata LowPriority => lowPriority;
    }
}
