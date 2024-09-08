using Application.Categories.Dto;
using Application.Categories.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Models;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Categories.QueryHandlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, PaginatedList<CategoryDto>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(request.Name))
            {
                query = query.Where(c => c.Name.Contains(request.Name));
            }
            // Thực hiện phân trang bằng PaginatedList
            var paginatedCategories = await PaginatedList<CategoryDto>.CreateAsync(
                query.ProjectTo<CategoryDto>(_mapper.ConfigurationProvider),
                request.PageIndex,
                request.PageSize
            );
            var categories = await query.ToListAsync(cancellationToken);
            return paginatedCategories;
        }
    }
}
