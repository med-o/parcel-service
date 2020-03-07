using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParseTheParcel.Api;

namespace ParseTheParcel
{
    public static class ParcelValidationRules
    {
        public static bool WeightsLess(this Parcel parcel, ParcelSettings settings)
        {
            return parcel.Weight <= settings.MaxWeight;
        }

        public static bool FitsInto(this Parcel parcel, ParcelSettings settings)
        {
            return parcel.Dimensions.Length <= settings.Dimensions.Length
                && parcel.Dimensions.Breadth <= settings.Dimensions.Breadth
                && parcel.Dimensions.Height <= settings.Dimensions.Height;
        }
    }
}
