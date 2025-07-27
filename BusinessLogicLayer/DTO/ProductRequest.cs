

namespace BusinessLogicLayer.SI.DTO
{
    public class ProductRequest {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
        [Required]

        public int Stock { get; set; }

    }
}

