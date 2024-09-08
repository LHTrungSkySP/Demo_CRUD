using Application.Categories.Dto;
using Application.Products.Dto;
using Application.Products.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Models;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Application.Products.QueryHandlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PaginatedList<ProductDto>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(request.Name))
            {
                query = query.Where(p => p.Name.Contains(request.Name));
            }
            // Thực hiện phân trang bằng PaginatedList
            var paginatedProducts = await PaginatedList<ProductDto>.CreateAsync(
                query.ProjectTo<ProductDto>(_mapper.ConfigurationProvider),
                request.PageIndex,
                request.PageSize
            );
            return paginatedProducts;
        }
    }
}
