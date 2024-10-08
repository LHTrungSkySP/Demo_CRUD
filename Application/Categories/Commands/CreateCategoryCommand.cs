﻿using MediatR;
using Application.Common.Mapping;
using Domain.Entities;
using Application.Categories.Dto;

namespace Application.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<CategoryDto>, IMapTo<Category>
    {
        public string Name { get; set; }
        public string SeoAlias { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeyword { get; set; }
        public string SeoDescription { get; set; }
        public int? ParentId { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
