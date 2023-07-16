using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Models
{
  
    public class ProductContext :DbContext
    {

        public ProductContext(DbContextOptions<ProductContext> options ) :base (options)
        {


            
        }
        public  DbSet<Product> Products { get; set;}
    }
}
