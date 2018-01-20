using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using PositionEvents.Instruments;
using PositionEvents.Specifications;

namespace PositionEvents.Positions
{
    public class Positions
    {
        private Dictionary<IInstrument, PositionSize> contents = new Dictionary<IInstrument, PositionSize>();

        public bool Initialized { get; set; } = false;
        public bool Closed { get; set; } = false;
        public string Portfolio { get; set; } = String.Empty;
        public Instant CreatedAt { get; set; }


        public IEnumerable<PositionLine> Lines => contents.Select(kvp => new PositionLine { Instrument = kvp.Key, Size = kvp.Value });


        public void Add(IInstrument instrument, double amount)
        {
            var total = amount;
            if (contents.TryGetValue(instrument, out var line))
                total += line.Size;

            contents[instrument] = new PositionSize { Size = total };

            if (contents[instrument].CanRemove())
                contents.Remove(instrument);
        }

        public void Add(CurrencyAmount currencyAmount)
        {
            Add(Cash.From(currencyAmount), currencyAmount.Amount);
        }


        public bool Any()
        {
            return contents.Any();
        }
        
        public bool Any(IInstrument instrument)
        {
            return contents.ContainsKey(instrument);
        }


        public PositionSize Get(IInstrument instrument)
        {
            if (!contents.TryGetValue(instrument, out var line))
                return PositionSize.Empty;

            return line;
        }


        public void Remove(IInstrument instrument, double amount)
        {
            var total = -amount;
            if (contents.TryGetValue(instrument, out var line))
                total += line.Size;
            
            contents[instrument] = new PositionSize { Size = total };

            if (contents[instrument].CanRemove())
                contents.Remove(instrument);
        }

        public void Remove(CurrencyAmount currencyAmount)
        {
            Remove(Cash.From(currencyAmount), currencyAmount.Amount);
        }
    }
}
