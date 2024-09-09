using Application.Products.Dto;
using Common.Models;
using MediatR;

namespace Application.Products.Queries
{
    public class GetProductsQuery : IRequest<PaginatedList<ProductDto>>
    {
        public string? Name { get; set; } // Lọc theo tên nếu cần
        public int PageIndex { get; set; } = 1; // Mặc định là trang 1
        public int PageSize { get; set; } = 10; // Mặc định là 10 danh mục mỗi trang
    }
}
