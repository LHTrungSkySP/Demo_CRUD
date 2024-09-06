using Xunit;
using Application.Products.QueryHandlers;
using Application.Products.Queries;
using Application.Products.Dto;
using Infrastructure;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Application.Common.Mapping;
using Unitilities.Object;
using Utility.FileLog;

public class GetProductByIdQueryHandlerTests
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly GetProductByIdQueryHandler _handler;

    public GetProductByIdQueryHandlerTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        _context = new AppDbContext(options);
        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AutoMapperProfile>();
        }).CreateMapper();
        _handler = new GetProductByIdQueryHandler(_context, _mapper);

        // Seed the database with test data
        SeedDatabase();
    }

    private void SeedDatabase()
    {
        _context.Products.Add(new Product
        {
            Id = 2,
            Name = "Test Product 2",
            Description = "Product Description",
            Content = "Product Content",
            Sku = "SKU123",
            Price = 150.0m,
            ImageUrl = "http://example.com/image.jpg",
            ImageList = "image1.jpg,image2.jpg",
            SeoAlias = "test-product",
            SeoTitle = "Test Product Title",
            SeoKeyword = "Test,Product",
            SeoDescription = "Test Product SEO Description"
        });
        _context.SaveChanges();
    }

    [Fact]
    public async Task Handle_ShouldReturnProductDto()
    {
        // Arrange
        var query = new GetProductByIdQuery { Id = 2 };

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);
        FileLogger.WriteLog(ConvertToJson.ConvertObjectToJson(result));
        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Id);
        Assert.Equal("Test Product 2", result.Name);
    }
}
