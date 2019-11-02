using SimpleShoppingCart.Core.Models;
using SimpleShoppingCart.Core.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SimpleShoppingCart.Core.Test
{
    public class OrderServiceTests
    {
        // service under test
        private OrderService _sut;

        [Fact]
        public void CalculateOrderSummary_WithEmptyParam_ShouldReturnNull()
        {
            // Arrange
            _sut = new OrderService();
            var empty = Enumerable.Empty<LineItem>();

            // Act
            var result = _sut.CalulateOrderSummary(empty);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void CalculateOrderSummary_TotalEqualThreshHold_ShouldShipAtMinShipping()
        {
            // Arrange
            _sut = new OrderService();
            var items = GenData();

            var unitPrice = _sut.ThreshHold / 2;

            items[0].Product.Price = unitPrice;
            items[0].Quantity = 1;
            items[1].Product.Price = unitPrice;
            items[1].Quantity = 1;

            // Act
            var result = _sut.CalulateOrderSummary(items);

            // Assert
            Assert.Equal(_sut.MinShipping, result.Shipping);
        }

        [Fact]
        public void CalculateOrderSummary_TotalOverThreshHold_ShouldShipAtMaxShipping()
        {
            // Arrange
            _sut = new OrderService();
            var items = GenData();

            items[0].Product.Price = 20;
            items[0].Quantity = 2;
            items[1].Product.Price = 20;
            items[1].Quantity = 2;

            // Act
            var result = _sut.CalulateOrderSummary(items);

            // Assert
            Assert.Equal(_sut.MaxShipping, result.Shipping);
        }

        [Fact]
        public void CalculateOrderSummary_TotalUnderThreshHold_ShouldShipAtMinShipping()
        {
            // Arrange
            _sut = new OrderService();
            var items = GenData();

            items[0].Product.Price = 10;
            items[0].Quantity = 2;
            items[1].Product.Price = 5;
            items[1].Quantity = 2;

            // Act
            var result = _sut.CalulateOrderSummary(items);

            // Assert
            Assert.Equal(_sut.MinShipping, result.Shipping);
        }

        private List<LineItem> GenData() 
        {
            return new List<LineItem>
            {
                new LineItem
                {
                    Product = new Product
                    {
                        Id = 1,
                        Name = "Test",
                        Description = "Description",
                        Category = "book",
                        Price = 0,
                        Image = "image.jpg"

                    },
                    Quantity = 2
                },
                new LineItem
                {
                    Product = new Product
                    {
                        Id = 1,
                        Name = "Test",
                        Description = "Description",
                        Category = "book",
                        Price = 0,
                        Image = "image.jpg"

                    },
                    Quantity = 1
                }
            };
        }
    }
}
