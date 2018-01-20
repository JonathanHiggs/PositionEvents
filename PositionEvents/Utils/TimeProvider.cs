using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;

namespace PositionEvents.Utils
{
    public class TimeProvider : ITimeProvider
    {
        public Instant CurrentInstant => SystemClock.Instance.GetCurrentInstant();
    }
}
