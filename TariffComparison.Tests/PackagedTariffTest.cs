using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using TarrifComparison.Products.Impls;
using Xunit;

namespace TariffComparison.Tests
{
    public class PackagedTariffTest
    {
        [Theory]
        [InlineData(3500, 800, 3500, 500, 0.3,800)]
        [InlineData(4500, 800, 3500, 500, 0.3, 950)]
        [InlineData(6000, 800, 3500, 500, 0.3, 1400)]
        public void Should_AnnualCostCalculateCorrectly_WithApproperiateConsumption
            (int consumptions,
                int baseAnnualCost,
                int baseConsumption,
                int baseAllowedDifference,
                decimal addedKwPrice,
                decimal expectedAnnualCost)
        {
            //arrange
            var package = new PackagedTariff(consumptions,
                baseAnnualCost,
                baseConsumption,baseAllowedDifference, addedKwPrice);

            //act
            package.Calculate();

            //assert
            package.AnnualCost.Should().Be(expectedAnnualCost);
        }


        [Theory]
        [InlineData(-3500, 800, 3500, 500, 0.3)]
        [InlineData(4500, -800, 3500, 500, 0.3)]
        [InlineData(6000, 800, -3500, 500, 0.3)]
        [InlineData(6000, 800, 3500, -500, 0.3)]
        [InlineData(6000, 800, 3500, 500, -0.3)]
        public void Should_ThrowArgumentOutOfRangeException_WithInapproperiateInputData
            (int consumptions,
                int baseAnnualCost,
                int baseConsumption,
                int baseAllowedDifference,
                decimal addedKwPrice)
        {
            //arrange
            Action act = () => new PackagedTariff(consumptions,
                baseAnnualCost,
                baseConsumption, baseAllowedDifference, addedKwPrice);

            //assert
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
