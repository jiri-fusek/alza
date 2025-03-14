using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<PaginatedResult<Product>> GetPaginatedProductsAsync(int pageNumber, int pageSize);
        Task<Product?> GetProductByIdAsync(int id);
        Task<bool> UpdateProductDescriptionAsync(int id, string? description);
    }
}