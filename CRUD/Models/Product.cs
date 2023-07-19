using System.Text.Json.Serialization;

namespace CRUD.Models
{
    public class Product
    {
     //   [JsonIgnore]
        public int ID { get; set; }
        public string? ProdName { get; set; }
        public string? CategoryName { get; set; }
        public decimal Price { get; set; }
    }
}
