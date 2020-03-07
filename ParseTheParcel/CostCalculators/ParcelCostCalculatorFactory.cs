using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParseTheParcel.Api;

namespace ParseTheParcel
{
    public class ParcelCostCalculatorFactory : IParcelCostCalculatorFactory
    {
        public IParcelCostCalculator Get(ParcelSettings ps)
        {
            switch (ps.Type)
            {
                case ParcelType.OddSize:
                    return new OddSizeCostCalculator();
                default:
                    return new BaseCostCalculator();
            }
        }
    }
}
