using Application.Categories.Commands;
using Application.Categories.Dto;
using AutoMapper;
using Common.Exceptions;
using Domain.Entities;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Categories.CommandHandlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existingCategory = await _context.Categories
                .FirstOrDefaultAsync(c => c.Name == request.Name, cancellationToken);

            if (existingCategory != null)
            {
                throw new AppException(ExceptionCode.Duplicate, "Danh mục đã tồn tại");
            }

            var category = _mapper.Map<Category>(request);
            _context.Categories.Add(category);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
