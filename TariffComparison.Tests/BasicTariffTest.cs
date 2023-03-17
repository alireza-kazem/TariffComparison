using FluentAssertions;
using System;
using TarrifComparison.Products.Impls;
using Xunit;

namespace TariffComparison.Tests
{
    public class BasicTariffTest
    {
        [Theory]
        [InlineData(0.22,5,3500, 830)]
        [InlineData(0.22,5,4500, 1050)]
        [InlineData(0.22,5,6000, 1380)]
        public void Should_AnnualCostCalculateCorrectly_WithApproperiateConsumption
            (decimal kwPrice, decimal monthlyPrice, int consumptions,
            decimal expectedAnnualCost)
        {
            //arrange
            var package = new BasicTarrif(consumptions, kwPrice, monthlyPrice);

            //act
            package.Calculate();

            //assert
            package.AnnualCost.Should().Be(expectedAnnualCost);
        }


        [Theory]
        [InlineData(0, 5, 3500)]
        [InlineData(0.22, 0, 4500)]
        [InlineData(-1, 5, 6000)]
        [InlineData(0.22, -5, 6000)]
        public void Should_ThrowArgumentOutOfRangeException_WithInapproperiateInputData
            (decimal kwPrice, decimal monthlyPrice, int consumptions)
        {
            Action act = () => new BasicTarrif(consumptions, kwPrice, monthlyPrice);
            
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
