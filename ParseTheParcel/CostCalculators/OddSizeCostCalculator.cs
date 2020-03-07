using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParseTheParcel.Api;

namespace ParseTheParcel
{
    public class OddSizeCostCalculator : IParcelCostCalculator
    {
        public decimal GetTotalCost(Parcel p, ParcelSettings ps)
        {
            return ps.BaseCost + p.Dimensions.Volume() / 10000000m;
        }
    }
}