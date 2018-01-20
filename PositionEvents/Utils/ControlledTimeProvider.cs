using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;

namespace PositionEvents.Utils
{
    public class ControlledTimeProvider : ITimeProvider
    {
        private Instant instant;
        public Instant CurrentInstant => instant;

        public void SetInstant(Instant instant)
        {
            this.instant = instant;
        }
    }
}
