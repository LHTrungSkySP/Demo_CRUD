using MediatR;
using Application.Categories.Dto;

namespace Application.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest<CategoryDto>
    {
        public int Id { get; set; }
    }
}
