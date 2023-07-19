using CRUD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CRUD.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductContext _context;

        public  ProductController (ProductContext context)
        {
            _context = context;
        }
       //[AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {

            if (_context.Products==null)
            {
                return NotFound("Not Products Available to Display.");

            }
            return  await   _context.Products.ToListAsync();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductByID(int id)
        {

            if (_context.Products == null)
            {
                return NotFound("No Product available to Display against Prodcut ID {id}");

            }
            var product= await _context.Products.FindAsync(id);
            if (product==null)
            {
                return NotFound();
            }
            return product;

        }
       
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            try
            {

                if (ProductAvailable(product.ProdName))
                {
                    return NotFound("Product Already Available With Existing Name");

                }
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetProductByID), new { id = product.ID }, product);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<Product>> UpDateProduct(Product product)
        {

            if (!ProductAvailable(product.ID))
            {
                return NotFound("Product not found against product ID={product.ID}");
            }
          
            _context.Entry(product).State = EntityState.Modified;

            try
            {

                await _context.SaveChangesAsync();
            }
            catch (Exception ex )
            {
                BadRequest("Update Failed with Message=" +ex.Message);

            }
            return Ok();

        }

        private bool ProductAvailable(int id) {

            return (_context.Products?.Any(x => x.ID == id)).GetValueOrDefault() ;
        }
        private bool ProductAvailable(string Name)
        {

            return (_context.Products?.Any(x => x.ProdName == Name)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {

            try
            {

            
            if (_context.Products == null)
            {
                return NotFound("No Products are available to Delte");

            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound("Product Id is not available.Enter Valid Product ID.");

            }
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
            return Ok("Product Deleted Successfully.");
             }
            catch (Exception ex)
            {

                return BadRequest("Exception occured ="+ex.Message);
            }

        }
    }
}
