using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Products.Commands;
using Application.Products.Queries;
using Application.Products.Dto;
using Common.Models;
using Prodcut.API;

namespace Product.API.Controllers
{
    public class ProductsController : ApiControllerBase
    {
        // Get all products with pagination
        [HttpGet]
        public async Task<ActionResult<PaginatedList<ProductDto>>> GetAll([FromQuery] GetProductsQuery command)
        {
            return await Mediator.Send(command);
        }

        // Get product by ID
        [HttpGet("Get-by-id")]
        public async Task<ActionResult<ProductDto>> GetById([FromQuery] GetProductByIdQuery command)
        {
            return await Mediator.Send(command);
        }

        // Create a new product
        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create(CreateProductCommand command)
        {
            return await Mediator.Send(command);
        }

        // Update an existing product
        [HttpPut]
        public async Task<ActionResult<ProductDto>> Update(UpdateProductCommand command)
        {
            return await Mediator.Send(command);
        }

        // Delete a product
        [HttpDelete]
        public async Task<ActionResult<ProductDto>> Delete(DeleteProductCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
