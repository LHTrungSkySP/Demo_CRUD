using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
    }
}
