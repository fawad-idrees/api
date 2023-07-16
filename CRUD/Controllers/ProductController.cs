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
                return NotFound();

            }
            return  await   _context.Products.ToListAsync();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductByID(int id)
        {

            if (_context.Products == null)
            {
                return NotFound();

            }
            var product= await _context.Products.FindAsync(id);
            if (product==null)
            {
                return NotFound();
            }
            return product;

        }
        //[AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {

            _context.Products.Add(product);
            await   _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProductByID), new {id=product.ID},product);

        }
        [HttpPut]
        public async Task<ActionResult<Product>> UpDateProduct(int id,Product product)
        {

            if (id !=product.ID)
            {
                return BadRequest();

            }
            _context.Entry(product).State = EntityState.Modified;

            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ProductAvailable(id))
                {
                    return NotFound(ex);

                }
                else
                {
                    throw;
                }

            }
            return Ok();

        }

        private bool ProductAvailable(int id) {

            return (_context.Products?.Any(x => x.ID == id)).GetValueOrDefault() ;
        }


        [HttpDelete("{id}") ]
        public  async Task<IActionResult>DeleteProduct(int id)
        {
            if     (_context.Products==null)
            {
                return NotFound();

            }
            var product = await _context.Products.FindAsync(id);
            if (product==null)
            {
                return NotFound();

            }
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
