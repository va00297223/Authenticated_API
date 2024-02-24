using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart_Model;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class Product_Controller : ControllerBase
{
    private readonly Data_Context _context;

    public Product_Controller(Data_Context context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product_Model>>> GetProducts()
    {
        var products = await _context.Products.ToListAsync();
        return Ok(products);
    }

    [HttpGet("GetByCategory/{categoryId}")]
    public async Task<ActionResult<IEnumerable<Product_Model>>> GetProductsByCategory(int categoryId)
    {
        var ProductsCategory = await _context.Products
            .Where(product => product.ProductCategory.Id == categoryId)
            .ToListAsync();

        if (ProductsCategory == null || !ProductsCategory.Any())
        {
            return NotFound("No products are found in this category.");
        }

        return Ok(ProductsCategory);
    }

    [HttpPost("AddProduct")]
    public async Task<ActionResult<Product_Model>> AddProduct(Product_Model product)
    {
        if (product == null)
        {
            return BadRequest("Invalid product data.");
        }

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProducts), new { }, product);
    }
}
