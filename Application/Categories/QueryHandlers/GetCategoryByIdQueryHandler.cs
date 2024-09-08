using MediatR;
using AutoMapper;
using Application.Categories.Dto;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Application.Categories.Queries;
using Common.Exceptions;

namespace Application.Categories.QueryHandlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
            if (category == null)
            {
                throw new AppException(ExceptionCode.Notfound, "Không tìm thấy danh mục");
            }
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
