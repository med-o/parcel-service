using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParseTheParcel.Api;

namespace ParseTheParcel
{
    public class ParcelSizeValidationRule : IParcelValidationRule
    {
        public bool IsValid(Parcel p, ParcelSettings ps)
        {
            return p.FitsIntoWhenRotated(ps);
        }
    }
}
