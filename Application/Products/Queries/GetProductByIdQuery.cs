using MediatR;
using Application.Products.Dto;

namespace Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}
