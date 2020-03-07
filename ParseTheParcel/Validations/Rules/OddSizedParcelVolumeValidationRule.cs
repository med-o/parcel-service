using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParseTheParcel.Api;

namespace ParseTheParcel
{
    public class OddSizedParcelVolumeValidationRule : IParcelValidationRule
    {
        public bool IsValid(Parcel p, ParcelSettings ps)
        {
            return ps.Type.Equals(ParcelType.OddSize)
                ? p.Dimensions.Volume() <= 60000000
                : true;
        }
    }
}
