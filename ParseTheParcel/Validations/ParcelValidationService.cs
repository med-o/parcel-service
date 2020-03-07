using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParseTheParcel.Api;

namespace ParseTheParcel
{
    public class ParcelValidationService : IParcelValidationService
    {
        private IList<IParcelValidationRule> _validationRules;

        public ParcelValidationService(IList<IParcelValidationRule> validationRules)
        {
            _validationRules = validationRules;
        }

        public bool IsValid(Parcel p, ParcelSettings ps)
        {
            return _validationRules.All(r => r.IsValid(p, ps));
        }
    }
}
