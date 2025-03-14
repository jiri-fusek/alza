using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V2
{
    /// <summary>
    /// Controller for managing e-shop products
    /// </summary>
    [ApiController]
    [Route("api/v2/[controller]")]
    [Produces("application/json")]
    [ApiVersion("2.0")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Initializes a new instance of the ProductsController
        /// </summary>
        /// <param name="productService">The product service</param>
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Retrieves products with pagination
        /// </summary>
        /// <param name="pageNumber">Page number (default: 1)</param>
        /// <param name="pageSize">Page size (default: 10)</param>
        /// <returns>A paginated list of products</returns>
        /// <response code="200">Returns paginated products</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PaginatedResult<ProductDto>>> GetProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber < 1)
                pageNumber = 1;

            if (pageSize < 1 || pageSize > 100)
                pageSize = 10;

            var paginatedProducts = await _productService.GetPaginatedProductsAsync(pageNumber, pageSize);
            return Ok(paginatedProducts);
        }

        /// <summary>
        /// Retrieves a specific product by id
        /// </summary>
        /// <param name="id">The id of the product to retrieve</param>
        /// <returns>The requested product</returns>
        /// <response code="200">Returns the requested product</response>
        /// <response code="404">If the product is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        /// <summary>
        /// Updates the description of a specific product
        /// </summary>
        /// <param name="id">The id of the product to update</param>
        /// <param name="descriptionDto">The new description</param>
        /// <returns>No content if successful</returns>
        /// <response code="204">If the update was successful</response>
        /// <response code="404">If the product is not found</response>
        /// <response code="400">If the request is invalid</response>
        [HttpPatch("{id}/description")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProductDescription(int id, [FromBody] UpdateProductDescriptionDto descriptionDto)
        {
            if (descriptionDto == null)
                return BadRequest();

            var result = await _productService.UpdateProductDescriptionAsync(id, descriptionDto);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
