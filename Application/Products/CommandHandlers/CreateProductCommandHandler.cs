using MediatR;
using Domain.Entities;
using Infrastructure;
using AutoMapper;
using Application.Products.Commands;
using Application.Products.Dto;
using Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Kiểm tra điều kiện hợp lệ (ví dụ: kiểm tra tên sản phẩm đã tồn tại)
            var existingProduct = await _context.Products
                .FirstOrDefaultAsync(p => p.Name == request.Name, cancellationToken);

            if (existingProduct != null)
            {
                throw new AppException(ExceptionCode.Duplicate, "Sản phẩm đã tồn tại");
            }

            var product = _mapper.Map<Product>(request);

            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ProductDto>(product); 
        }
    }
}
