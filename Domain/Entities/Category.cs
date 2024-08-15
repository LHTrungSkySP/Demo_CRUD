using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Entities
{
    public class Category : BaseModel
    {
        public string Name { get; set; }
        public string SeoAlias { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeyword { get; set; }
        public string SeoDescription { get; set; }
        public int? ParentId { get; set; } // Nullable int để cho phép giá trị null cho các danh mục gốc
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }

}
//Name: Tên của danh mục.
//SeoAlias: Alias SEO của danh mục, thường dùng để tạo URL thân thiện với SEO.
//SeoTitle: Tiêu đề SEO cho danh mục.
//SeoKeyword: Từ khóa SEO cho danh mục.
//SeoDescription: Mô tả SEO cho danh mục.
//ParentId: ID của danh mục cha, có thể là null nếu danh mục này là danh mục gốc.
//SortOrder: Thứ tự sắp xếp của danh mục.
//IsActive: Trạng thái hoạt động của danh mục.