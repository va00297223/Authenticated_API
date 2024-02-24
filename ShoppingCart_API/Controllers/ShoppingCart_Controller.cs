using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart_Model;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ShoppingCart_Controller : ControllerBase
{
    private readonly Data_Context _context;

    public ShoppingCart_Controller(Data_Context context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product_Model>>> GetShoppingCart()
    {
        var Shopping_Cart = await _context.ShoppingCarts
            .Include(cart => cart.Products)
            .Where(cart => cart.User == User.Identity.Name)
            .FirstOrDefaultAsync();

        if (Shopping_Cart == null)
        {
            return NotFound("Shopping cart not found for this user.");
        }

        var CartProducts = Shopping_Cart.Products;

        return Ok(CartProducts);
    }

    [HttpPost("RemoveItem/{productId}")]
    public async Task<ActionResult> RemoveItem(int productId)
    {
        var Shopping_Cart = await _context.ShoppingCarts
            .Include(cart => cart.Products)
            .Where(cart => cart.User == User.Identity.Name)
            .FirstOrDefaultAsync();

        if (Shopping_Cart == null)
        {
            return NotFound("Shopping cart is not available for this user.");
        }

        var RemoveProduct = Shopping_Cart.Products?.FirstOrDefault(p => p.Id == productId);

        if (RemoveProduct == null)
        {
            return NotFound("Product not found in the shopping cart.");
        }

        Shopping_Cart.Products?.Remove(RemoveProduct);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost("AddItem/{productId}")]
    public async Task<ActionResult> AddItem(int productId)
    {
        var Shopping_Cart = await _context.ShoppingCarts
            .Include(cart => cart.Products)
            .Where(cart => cart.User == User.Identity.Name)
            .FirstOrDefaultAsync();

        if (Shopping_Cart == null)
        {
            Shopping_Cart = new ShoppingCart
            {
                User = User.Identity.Name,
                Products = new List<Product_Model>()
            };

            _context.ShoppingCarts.Add(Shopping_Cart);
        }

        var existingProduct = Shopping_Cart.Products?.FirstOrDefault(p => p.Id == productId);

        if (existingProduct != null)
        {
            return Conflict("Product already exists in the shopping cart.");
        }

        // Add the product to the shopping cart
        var AddProduct = await _context.Products.FindAsync(productId);

        if (AddProduct == null)
        {
            return NotFound("Product not found.");
        }

        Shopping_Cart.Products.Add(AddProduct);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetShoppingCart), new { }, Shopping_Cart);
    }
}


