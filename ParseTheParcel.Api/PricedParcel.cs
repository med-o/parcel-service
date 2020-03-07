using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseTheParcel.Api
{
    /// <summary>
    /// Parcel with pricing information and settings
    /// </summary>
    public class PricedParcel
    {
        public PricedParcel(Parcel p, ParcelSettings ps, decimal cost)
        {
            Parcel = p ?? new Parcel();
            Settings = ps;
            Cost = cost;
        }

        /// <summary>
        /// Parcel in question
        /// </summary>
        public Parcel Parcel { get; private set; }

        /// <summary>
        /// Parcel settings like maximum weight etc
        /// </summary>
        public ParcelSettings Settings { get; private set; }

        /// <summary>
        /// Total cost of a parcel
        /// </summary>
        public decimal Cost { get; private set; }

        /// <summary>
        /// Type of the parcel
        /// </summary>
        public ParcelType Type {
            get { return Settings.Type; }
        }
    }
}
