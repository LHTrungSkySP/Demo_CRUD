using Application.Products.Commands;
using Application.Products.Dto;
using AutoMapper;
using Common.Exceptions;
using Domain.Entities;
using Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products.CommandHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.Id);
            if (product == null)
            {
                throw new AppException(ExceptionCode.Notfound, "Không tìm thấy sản phẩm");
            }
            product = _mapper.Map<Product>(request);

            _context.Products.Update(product);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
