using Core.DTOs;
using Core.Entities;

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