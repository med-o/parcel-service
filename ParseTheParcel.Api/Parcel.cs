using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTheParcel.Api
{
    /// <summary>
    /// Parcel model, most likely populated from the UI
    /// </summary>
    public class Parcel
    {
        /// <summary>
        /// Parcel dimensions
        /// </summary>
        public ParcelDimensions Dimensions { get; set; }

        /// <summary>
        /// Weight of the parcel in kg
        /// </summary>
        public decimal Weight { get; set; }

        // other properties for the parcel in question like address, name of sender etc
    }
}
