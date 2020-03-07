using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTheParcel.Api
{
    /// <summary>
    /// Parcel settings define allowed dimensions and weight for given parcel type
    /// </summary>
    public class ParcelSettings
    {
        public ParcelSettings()
        {
            MaxDimensions = new ParcelDimensions();
        }

        /// <summary>
        /// Type of the parcel
        /// </summary>
        public ParcelType Type { get; set; }

        /// <summary>
        /// Maximal parcel dimensions
        /// </summary>
        public ParcelDimensions MaxDimensions { get; set; }

        /// <summary>
        /// Maximal parcel weight
        /// </summary>
        public decimal MaxWeight { get; set; }

        /// <summary>
        /// Default cost associated with this parcel type
        /// </summary>
        public decimal BaseCost { get; set; }

        public override string ToString() 
        {
            return String.Format("Type: {0}, BaseCost: {1}, Maximum dimensions: [{2}x{3}x{4}]", 
                Type, BaseCost, MaxDimensions.Length, MaxDimensions.Breadth, MaxDimensions.Height);
        }
    }
}
