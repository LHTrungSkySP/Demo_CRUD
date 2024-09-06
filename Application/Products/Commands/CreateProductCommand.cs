using MediatR;
using Application.Common.Mapping;
using Domain.Entities;
using Application.Products.Dto;

namespace Application.Products.Commands
{
    public class CreateProductCommand : IRequest<ProductDto>, IMapTo<Product>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
        public int? IdVoucher { get; set; } // Nullable int để cho phép giá trị null nếu không có voucher
        public string ImageUrl { get; set; }
        public string ImageList { get; set; } // Có thể dùng JSON hoặc CSV để lưu danh sách hình ảnh
        public int ViewCount { get; set; }
        public string SeoAlias { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeyword { get; set; }
        public string SeoDescription { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
