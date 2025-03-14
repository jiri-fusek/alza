using Core.DTOs;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Mocks;
using Xunit;

namespace Tests.Services
{
    public class ProductServiceTests
    {
        private readonly ProductService _productService;
        private readonly MockProductRepository _mockRepository;

        public ProductServiceTests()
        {
            _mockRepository = new MockProductRepository();
            _productService = new ProductService(_mockRepository);
        }

        [Fact]
        public async Task GetAllProductsAsync_ShouldReturnAllProducts()
        {
            // Act
            var result = await _productService.GetAllProductsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(12, result.Count());
        }

        [Fact]
        public async Task GetProductByIdAsync_WithValidId_ShouldReturnProduct()
        {
            // Arrange
            int productId = 3;

            // Act
            var result = await _productService.GetProductByIdAsync(productId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(productId, result.Id);
            Assert.Equal("Test Product 3", result.Name);
        }

        [Fact]
        public async Task GetProductByIdAsync_WithInvalidId_ShouldReturnNull()
        {
            // Arrange
            int invalidProductId = 999;

            // Act
            var result = await _productService.GetProductByIdAsync(invalidProductId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateProductDescriptionAsync_WithValidId_ShouldReturnTrue()
        {
            // Arrange
            int productId = 4;
            var descriptionDto = new UpdateProductDescriptionDto { Description = "Updated Description" };

            // Act
            var result = await _productService.UpdateProductDescriptionAsync(productId, descriptionDto);

            // Assert
            Assert.True(result);

            // Verify the description was updated
            var updatedProduct = await _productService.GetProductByIdAsync(productId);
            Assert.Equal("Updated Description", updatedProduct!.Description);
        }

        [Fact]
        public async Task UpdateProductDescriptionAsync_WithInvalidId_ShouldReturnFalse()
        {
            // Arrange
            int invalidProductId = 999;
            var descriptionDto = new UpdateProductDescriptionDto { Description = "Updated Description" };

            // Act
            var result = await _productService.UpdateProductDescriptionAsync(invalidProductId, descriptionDto);

            // Assert
            Assert.False(result);
        }
    }
}