using System.ComponentModel.DataAnnotations.Schema;

namespace netframe.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public Guid? parentCategoryId { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
