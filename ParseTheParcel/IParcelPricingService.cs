using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParseTheParcel.Api;

namespace ParseTheParcel
{
    public interface IParcelPricingService
    {
        PricedParcel GetPricedParcel(Parcel parcel);
    }
}
