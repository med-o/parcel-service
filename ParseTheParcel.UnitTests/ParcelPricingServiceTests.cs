using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParseTheParcel;
using ParseTheParcel.Api;

namespace ParseTheParcel.UnitTests
{
    public abstract class ParcelPricingServiceTests
    {
        protected PricedParcel Result { get; set; }

        protected Exception Exception { get; set; }
        
        protected IParcelPricingService GetObjectUnderTest()
        {
            var settingsRepo = new FakeParcelSettingsRepository();
            var orderingService = new PricedParcelCostComparer();
            var validationService = new ParcelValidationService(new List<IParcelValidationRule>()
            {
                new ParcelSizeValidationRule(),
                new ParcelWeightValidationRule(),
                new OddSizedParcelVolumeValidationRule(),
            });
            var parcelCostCalculatorFactory = new ParcelCostCalculatorFactory();
            var underTest = new ParcelPricingService(settingsRepo, orderingService, validationService, parcelCostCalculatorFactory);
            
            return underTest;
        }

        protected abstract Parcel GetQuery();

        protected abstract void VerifyResult();

        [TestMethod]
        public void Expected_priced_parcel_is_returned()
        {
            // arrange
            var underTest = GetObjectUnderTest();
            var parcel = GetQuery();

            // act
            try
            {
                Result = underTest.GetPricedParcel(parcel);
            }
            catch (Exception e)
            {
                Exception = e;
            }

            // assert
            VerifyResult();
        }
    }

    [TestClass]
    public class When_no_parcel_is_supplied : ParcelPricingServiceTests
    {
        protected override Parcel GetQuery()
        {
            return null;
        }

        protected override void VerifyResult()
        {
            Assert.IsNull(Result);
            Assert.IsNotNull(Exception);
            Assert.IsInstanceOfType(Exception, typeof(ArgumentException));
            Assert.AreEqual(Exception.Message, "Parcel needs to be supplied");
        }
    }

    [TestClass]
    public class When_small_parcel_is_supplied : ParcelPricingServiceTests 
    {
        protected override Parcel GetQuery() 
        {
            return new Parcel()
            {
                Dimensions = new ParcelDimensions()
                {
                    Length = 200,
                    Breadth = 300,
                    Height = 150
                },
                Weight = 25.0m,
            };
        }

        protected override void VerifyResult()
        {
            Assert.IsNull(Exception);
            Assert.IsNotNull(Result);
            Assert.IsNotNull(Result.Parcel);
            Assert.IsNotNull(Result.Settings);
            Assert.AreEqual(5.0m, Result.Cost);
            Assert.AreEqual(ParcelType.Small, Result.Type);
        }
    }

    [TestClass]
    public class When_medium_parcel_is_supplied : ParcelPricingServiceTests
    {
        protected override Parcel GetQuery()
        {
            return new Parcel()
            {
                Dimensions = new ParcelDimensions()
                {
                    Length = 300,
                    Breadth = 400,
                    Height = 200
                },
                Weight = 25.0m,
            };
        }

        protected override void VerifyResult()
        {
            Assert.IsNull(Exception);
            Assert.IsNotNull(Result);
            Assert.IsNotNull(Result.Parcel);
            Assert.IsNotNull(Result.Settings);
            Assert.AreEqual(7.5m, Result.Cost);
            Assert.AreEqual(ParcelType.Medium, Result.Type);
        }
    }

    [TestClass]
    public class When_large_parcel_is_supplied : ParcelPricingServiceTests
    {
        protected override Parcel GetQuery()
        {
            return new Parcel()
            {
                Dimensions = new ParcelDimensions()
                {
                    Length = 400,
                    Breadth = 600,
                    Height = 250
                },
                Weight = 25.0m,
            };
        }

        protected override void VerifyResult()
        {
            Assert.IsNull(Exception);
            Assert.IsNotNull(Result);
            Assert.IsNotNull(Result.Parcel);
            Assert.IsNotNull(Result.Settings);
            Assert.AreEqual(8.5m, Result.Cost);
            Assert.AreEqual(ParcelType.Large, Result.Type);
        }
    }

    [TestClass]
    public class When_oversized_parcel_is_supplied : ParcelPricingServiceTests
    {
        protected override Parcel GetQuery()
        {
            return new Parcel()
            {
                Dimensions = new ParcelDimensions()
                {
                    Length = 400,
                    Breadth = 600,
                    Height = 300
                },
                Weight = 25.0m,
            };
        }

        protected override void VerifyResult()
        {
            Assert.IsNull(Exception);
            Assert.IsNotNull(Result);
            Assert.IsNotNull(Result.Parcel);
            Assert.IsNotNull(Result.Settings);
            Assert.AreEqual(0m, Result.Cost);
            Assert.AreEqual(ParcelType.NotSpecified, Result.Type);
        }
    }

    [TestClass]
    public class When_overweight_parcel_is_supplied : ParcelPricingServiceTests
    {
        protected override Parcel GetQuery()
        {
            return new Parcel()
            {
                Dimensions = new ParcelDimensions()
                {
                    Length = 1,
                    Breadth = 1,
                    Height = 1
                },
                Weight = 30.0m,
            };
        }

        protected override void VerifyResult()
        {
            Assert.IsNull(Exception);
            Assert.IsNotNull(Result);
            Assert.IsNotNull(Result.Parcel);
            Assert.IsNotNull(Result.Settings);
            Assert.AreEqual(0m, Result.Cost);
            Assert.AreEqual(ParcelType.NotSpecified, Result.Type);
        }
    }

    [TestClass]
    public class When_small_parcel_which_needs_to_be_rotated_is_supplied : ParcelPricingServiceTests
    {
        protected override Parcel GetQuery()
        {
            return new Parcel()
            {
                Dimensions = new ParcelDimensions()
                {
                    Length = 300,
                    Breadth = 200,
                    Height = 150
                },
                Weight = 25.0m,
            };
        }

        protected override void VerifyResult()
        {
            Assert.IsNull(Exception);
            Assert.IsNotNull(Result);
            Assert.IsNotNull(Result.Parcel);
            Assert.IsNotNull(Result.Settings);
            Assert.AreEqual(5.0m, Result.Cost);
            Assert.AreEqual(ParcelType.Small, Result.Type);
        }
    }

    [TestClass]
    public class When_odd_size_parcel_is_supplied : ParcelPricingServiceTests
    {
        protected override Parcel GetQuery()
        {
            return new Parcel()
            {
                Dimensions = new ParcelDimensions()
                {
                    Length = 600,
                    Breadth = 200,
                    Height = 500
                },
                Weight = 25.0m,
            };
        }

        protected override void VerifyResult()
        {
            Assert.IsNull(Exception);
            Assert.IsNotNull(Result);
            Assert.IsNotNull(Result.Parcel);
            Assert.IsNotNull(Result.Settings);
            Assert.AreEqual(12.0m, Result.Cost);
            Assert.AreEqual(ParcelType.OddSize, Result.Type);
        }
    }
}
