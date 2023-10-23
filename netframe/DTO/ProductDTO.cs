using System.ComponentModel.DataAnnotations.Schema;

namespace netframe.DTO
{
    public class ProductDTO
    {
        public Guid ProductId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string ImageLink { get; set; }
        public short Quality { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
    }
}
