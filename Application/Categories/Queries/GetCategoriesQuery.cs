using MediatR;
using Application.Categories.Dto;
using System.Collections.Generic;
using Common.Models;

namespace Application.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<PaginatedList<CategoryDto>>
    {
        public string Name { get; set; } // Lọc theo tên nếu cần
        public int PageIndex { get; set; } = 1; // Mặc định là trang 1
        public int PageSize { get; set; } = 10; // Mặc định là 10 danh mục mỗi trang
    }
}
