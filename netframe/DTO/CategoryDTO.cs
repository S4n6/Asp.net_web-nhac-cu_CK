using System.ComponentModel.DataAnnotations.Schema;

namespace netframe.DTO
{
    public class CategoryDTO
    {
        public Guid CategoryId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public Guid? parentCategoryId { get; set; }
    }
}
