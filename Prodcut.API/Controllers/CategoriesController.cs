// File: C:\Users\Welcome\Desktop\New folder\Prodcut.API\Controllers\CategoriesController.cs
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Categories.Commands;
using Application.Categories.Queries;
using Application.Categories.Dto;
using Common.Models;
using Prodcut.API;

namespace Product.API.Controllers
{
    public class CategoriesController : ApiControllerBase
    {
        // Get all categories with pagination
        [HttpGet]
        public async Task<ActionResult<PaginatedList<CategoryDto>>> GetAll([FromQuery] GetCategoriesQuery query)
        {
            return await Mediator.Send(query);
        }

        // Get category by ID
        [HttpGet("Get-by-id")]
        public async Task<ActionResult<CategoryDto>> GetById([FromQuery] GetCategoryByIdQuery query)
        {
            return await Mediator.Send(query);
        }

        // Create a new category
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create(CreateCategoryCommand command)
        {
            return await Mediator.Send(command);
        }

        // Update an existing category
        [HttpPut]
        public async Task<ActionResult<CategoryDto>> Update(UpdateCategoryCommand command)
        {
            return await Mediator.Send(command);
        }

        // Delete a category
        [HttpDelete]
        public async Task<ActionResult<CategoryDto>> Delete(DeleteCategoryCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
