using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionEvents.Aggregates;

namespace PositionEvents.Positions.Management
{
    public class PositionCreated : IPositionEvent
    {
        public string Portfolio { get; private set; }

        public PositionCreated(string portfolio)
        {
            Portfolio = portfolio;
        }
    }
}
