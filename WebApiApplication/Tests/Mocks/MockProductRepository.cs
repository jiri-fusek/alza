using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Mocks
{
    public class MockProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public MockProductRepository()
        {
            // Initialize with mock data
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Test Product 1", ImgUri = "https://example.com/test1.jpg", Price = 19.99m, Description = "Test Description 1" },
                new Product { Id = 2, Name = "Test Product 2", ImgUri = "https://example.com/test2.jpg", Price = 29.99m, Description = "Test Description 2" },
                new Product { Id = 3, Name = "Test Product 3", ImgUri = "https://example.com/test3.jpg", Price = 39.99m, Description = "Test Description 3" },
                new Product { Id = 4, Name = "Test Product 4", ImgUri = "https://example.com/test4.jpg", Price = 49.99m, Description = "Test Description 4" },
                new Product { Id = 5, Name = "Test Product 5", ImgUri = "https://example.com/test5.jpg", Price = 59.99m, Description = "Test Description 5" },
                new Product { Id = 6, Name = "Test Product 6", ImgUri = "https://example.com/test6.jpg", Price = 69.99m, Description = "Test Description 6" },
                new Product { Id = 7, Name = "Test Product 7", ImgUri = "https://example.com/test7.jpg", Price = 79.99m, Description = "Test Description 7" },
                new Product { Id = 8, Name = "Test Product 8", ImgUri = "https://example.com/test8.jpg", Price = 89.99m, Description = "Test Description 8" },
                new Product { Id = 9, Name = "Test Product 9", ImgUri = "https://example.com/test9.jpg", Price = 99.99m, Description = "Test Description 9" },
                new Product { Id = 10, Name = "Test Product 10", ImgUri = "https://example.com/test10.jpg", Price = 109.99m, Description = "Test Description 10" },
                new Product { Id = 11, Name = "Test Product 11", ImgUri = "https://example.com/test11.jpg", Price = 119.99m, Description = "Test Description 11" },
                new Product { Id = 12, Name = "Test Product 12", ImgUri = "https://example.com/test12.jpg", Price = 129.99m, Description = "Test Description 12" }
            };
        }

        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return Task.FromResult<IEnumerable<Product>>(_products);
        }

        public Task<Product?> GetProductByIdAsync(int id)
        {
            return Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
        }

        public Task<bool> UpdateProductDescriptionAsync(int id, string? description)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return Task.FromResult(false);

            product.Description = description;
            return Task.FromResult(true);
        }
    }
}