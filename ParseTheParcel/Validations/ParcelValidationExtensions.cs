using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParseTheParcel.Api;

namespace ParseTheParcel
{
    public static class ParcelValidationExtensions
    {
        public static bool WeightsLess(this Parcel parcel, ParcelSettings settings)
        {
            return parcel.Weight <= settings.MaxWeight;
        }

        public static bool FitsInto(this Parcel parcel, ParcelSettings settings)
        {
            return parcel.Dimensions.FitsInto(settings.MaxDimensions);
        }

        public static bool FitsIntoWhenRotated(this Parcel parcel, ParcelSettings settings)
        {
            return parcel.Dimensions.Rotate().FitsInto(settings.MaxDimensions.Rotate());
        }
    }
}
