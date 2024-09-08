using MediatR;
using AutoMapper;
using Application.Products.Dto;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Application.Products.Queries;
using Common.Exceptions;

namespace Application.Products.QueryHandlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
            if (product != null)
            {
                throw new AppException(ExceptionCode.Notfound, "Không tìm thấy sản phẩm");
            }
            return _mapper.Map<ProductDto>(product);
        }
    }
}
