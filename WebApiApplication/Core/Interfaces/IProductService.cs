using Core.DTOs;

namespace Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<PaginatedResult<ProductDto>> GetPaginatedProductsAsync(int pageNumber, int pageSize);
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<bool> UpdateProductDescriptionAsync(int id, UpdateProductDescriptionDto descriptionDto);
    }
}
