using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParseTheParcel.Api;

namespace ParseTheParcel
{
    // NOTE : this could fetch settings from DB or anywhere else
    public class FakeParcelSettingsRepository : IParcelSettingsRepository
    {
        public IList<ParcelSettings> GetAllParcelSettings()
        {
            return new List<ParcelSettings>() { 
                new ParcelSettings()
                {
                    Type = ParcelType.Medium,
                    MaxDimensions = new ParcelDimensions() {
                        Length = 300,
                        Breadth = 400,
                        Height = 200,
                    },
                    MaxWeight = 25.0m,
                    BaseCost = 7.50m
                },
                new ParcelSettings()
                {
                    Type = ParcelType.Large,
                    MaxDimensions = new ParcelDimensions() {
                        Length = 400,
                        Breadth = 600,
                        Height = 250,
                    },
                    MaxWeight = 25.0m,
                    BaseCost = 8.50m
                },            
                new ParcelSettings()
                {
                    Type = ParcelType.Small,
                    MaxDimensions = new ParcelDimensions() {
                        Length = 200,
                        Breadth = 300,
                        Height = 150,
                    },
                    MaxWeight = 25.0m,
                    BaseCost = 5.00m
                },
                new ParcelSettings()
                {
                    Type = ParcelType.OddSize,
                    MaxDimensions = new ParcelDimensions() {
                        Length = 600,
                        Breadth = 600,
                        Height = 600,
                    },
                    MaxWeight = 25.0m,
                    BaseCost = 6.00m
                },
            };
        }
    }
}
