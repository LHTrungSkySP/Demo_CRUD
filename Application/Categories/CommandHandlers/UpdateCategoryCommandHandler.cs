using Application.Categories.Commands;
using Application.Categories.Dto;
using AutoMapper;
using Common.Exceptions;
using Domain.Entities;
using Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Categories.CommandHandlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(request.Id);
            if (category == null)
            {
                throw new AppException(ExceptionCode.Notfound, "Không tìm thấy danh mục");
            }

            category = _mapper.Map<Category>(request);

            _context.Categories.Update(category);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
