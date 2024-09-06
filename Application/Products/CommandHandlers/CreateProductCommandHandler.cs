using MediatR;
using Domain.Entities;
using Infrastructure;
using AutoMapper;
using Application.Products.Commands;
using Application.Products.Dto;

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
            var product = _mapper.Map<Product>(request);

            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ProductDto>(product); // Return ID of created product
        }
    }
}
