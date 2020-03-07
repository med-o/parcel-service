using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ParseTheParcel.Api;

namespace ParseTheParcel
{
    public class PricedParcelCostComparer : IPricedParcelComparer
    {
        public int Compare(PricedParcel x, PricedParcel y)
        {
            return x.Cost > y.Cost
                ? 1
                : x.Cost < y.Cost
                    ? -1
                    : 0;
        }
    }
}
