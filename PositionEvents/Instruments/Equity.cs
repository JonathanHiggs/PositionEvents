using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionEvents.Instruments
{
    public class Equity : IInstrument
    {
        public string Name { get; set; }
        
        public string Description => Name;


        public override bool Equals(object obj)
        {
            var equity = obj as Equity;
            return obj != null
                && Name == equity.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}
