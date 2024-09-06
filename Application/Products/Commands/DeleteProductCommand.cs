using Application.Products.Dto;
using MediatR;

namespace Application.Products.Commands
{
    public class DeleteProductCommand : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}
