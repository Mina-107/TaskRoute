using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Data.Entities
{
    public class Product:BaseEntity<int>
    {
        public string Name { get; set; }
        [DataType("decimal(10,3)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }

    }
}

