using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using TarrifComparison.Products;
using TarrifComparison.Services;
using Xunit;

namespace TariffComparison.Tests
{
    public class ProductServiceTest
    {
        [Theory]
        [InlineData(3500, "Basic electricity tariff")]
        [InlineData(4500, "Basic electricity tariff")]
        [InlineData(6000, "Packaged tariff")]
        public void Should_ReturnOrderedList_WhenProvidingApproperiateData(int consumption,
            string expectedName)
        {
            //arrange
            var productService = new ProductService();

            //act
            var productList = productService.GetProducts(consumption);

            //assert
            productList.First().Name.Should().Be(expectedName);
        }
    }
}
