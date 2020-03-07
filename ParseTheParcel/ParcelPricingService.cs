using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParseTheParcel.Api;

namespace ParseTheParcel
{
    public class ParcelPricingService : IParcelPricingService
    {
        private readonly IParcelSettingsRepository _parcelSettingsRepository;
        private readonly IPricedParcelComparer _pricedParcelCompaprer;
        private readonly IParcelValidationService _parcelValidationService;
        private readonly IParcelCostCalculatorFactory _parcelCostCalculatorFactory;

        public ParcelPricingService(
            IParcelSettingsRepository parcelSettingsRepository,
            IPricedParcelComparer parcelSettingsComparer,
            IParcelValidationService parcelValidationService,
            IParcelCostCalculatorFactory parcelCostCalculatorFactory
        )
        {
            _parcelSettingsRepository = parcelSettingsRepository;
            _pricedParcelCompaprer = parcelSettingsComparer;
            _parcelValidationService = parcelValidationService;
            _parcelCostCalculatorFactory = parcelCostCalculatorFactory;
        }

        public PricedParcel GetPricedParcel(Parcel parcel)
        {
            if (parcel == null)
            {
                throw new ArgumentException("Parcel needs to be supplied");
            }

            var pricedParcel = _parcelSettingsRepository
                .GetAllParcelSettings()
                .Where(ps => IsValid(parcel, ps))
                .Select(ps => GetPricedParcel(parcel, ps))
                .OrderBy(pp => pp, _pricedParcelCompaprer)
                .FirstOrDefault();

            return pricedParcel ?? GetDefaultPricedParcel(parcel);
        }

        private static PricedParcel GetDefaultPricedParcel(Parcel parcel)
        {
            var defaultSettings = new ParcelSettings()
            {
                Type = ParcelType.NotSpecified,
            };
            var defaultPricedParcel = new PricedParcel(parcel, defaultSettings, 0m);

            return defaultPricedParcel;
        }

        private PricedParcel GetPricedParcel(Parcel parcel, ParcelSettings ps)
        {
            var cost = _parcelCostCalculatorFactory
                .Get(ps)
                .GetTotalCost(parcel, ps);

            return new PricedParcel(parcel, ps, cost);
        }

        private bool IsValid(Parcel parcel, ParcelSettings ps)
        {
            return _parcelValidationService.IsValid(parcel, ps);
        }
    }
}
