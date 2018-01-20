using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionEvents.Specifications
{
    public struct IssueId
    {
        public readonly string CUSIP;
        
        public IssueId(string cusip)
        {
            CUSIP = cusip;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is IssueId))
                return false;

            var id = (IssueId)obj;
            return CUSIP == id.CUSIP;
        }

        public override int GetHashCode()
        {
            var hashCode = -1404439085;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CUSIP);
            return hashCode;
        }

        public static bool operator==(IssueId lhs, IssueId rhs)
        {
            return lhs.CUSIP == rhs.CUSIP;
        }

        public static bool operator!=(IssueId lhs, IssueId rhs)
        {
            return !(lhs == rhs);
        }
    }
}
