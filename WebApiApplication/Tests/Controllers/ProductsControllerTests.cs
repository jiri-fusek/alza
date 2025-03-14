using Api.Controllers;
using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Tests.Mocks;
using Xunit;

namespace Tests.Controllers
{
    public class ProductsControllerTests
    {
        private readonly ProductsController _controller;
        private readonly ProductService _productService;

        public ProductsControllerTests()
        {
            var mockRepository = new MockProductRepository();
            _productService = new ProductService(mockRepository);
            _controller = new ProductsController(_productService);
        }

        [Fact]
        public async Task GetProducts_ShouldReturnAllProducts()
        {
            // Act
            var result = await _controller.GetProducts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var products = Assert.IsAssignableFrom<IEnumerable<ProductDto>>(okResult.Value);
            Assert.Equal(12, products.Count());
        }

        [Fact]
        public async Task GetProduct_WithValidId_ShouldReturnProduct()
        {
            // Arrange
            int productId = 5;

            // Act
            var result = await _controller.GetProduct(productId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var product = Assert.IsType<ProductDto>(okResult.Value);
            Assert.Equal(productId, product.Id);
            Assert.Equal("Test Product 5", product.Name);
        }

        [Fact]
        public async Task GetProduct_WithInvalidId_ShouldReturnNotFound()
        {
            // Arrange
            int invalidProductId = 999;

            // Act
            var result = await _controller.GetProduct(invalidProductId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task UpdateProductDescription_WithValidId_ShouldReturnNoContent()
        {
            // Arrange
            int productId = 6;
            var descriptionDto = new UpdateProductDescriptionDto { Description = "Updated Description" };

            // Act
            var result = await _controller.UpdateProductDescription(productId, descriptionDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateProductDescription_WithInvalidId_ShouldReturnNotFound()
        {
            // Arrange
            int invalidProductId = 999;
            var descriptionDto = new UpdateProductDescriptionDto { Description = "Updated Description" };

            // Act
            var result = await _controller.UpdateProductDescription(invalidProductId, descriptionDto);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task UpdateProductDescription_WithNullDto_ShouldReturnBadRequest()
        {
            // Act
            var result = await _controller.UpdateProductDescription(1, null!);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
}