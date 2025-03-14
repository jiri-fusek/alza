using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return products.Select(MapToDto);
        }

        public async Task<PaginatedResult<ProductDto>> GetPaginatedProductsAsync(int pageNumber, int pageSize)
        {
            var paginatedResult = await _productRepository.GetPaginatedProductsAsync(pageNumber, pageSize);

            var result = new PaginatedResult<ProductDto>
            {
                PageNumber = paginatedResult.PageNumber,
                PageSize = paginatedResult.PageSize,
                TotalCount = paginatedResult.TotalCount,
                Items = paginatedResult.Items.Select(MapToDto).ToList()
            };

            return result;
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return product != null ? MapToDto(product) : null;
        }

        public async Task<bool> UpdateProductDescriptionAsync(int id, UpdateProductDescriptionDto descriptionDto)
        {
            return await _productRepository.UpdateProductDescriptionAsync(id, descriptionDto.Description);
        }

        private static ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                ImgUri = product.ImgUri,
                Price = product.Price,
                Description = product.Description
            };
        }
    }
}