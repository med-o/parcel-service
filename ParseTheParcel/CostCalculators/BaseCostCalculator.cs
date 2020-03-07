using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParseTheParcel.Api;

namespace ParseTheParcel
{
    public class BaseCostCalculator : IParcelCostCalculator
    {
        public decimal GetTotalCost(Parcel p, ParcelSettings ps)
        {
            return ps.BaseCost;
        }
    }
}