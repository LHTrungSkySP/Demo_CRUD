using Xunit;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Application.Products.CommandHandlers;
using Application.Products.Commands;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Mapping;
using Infrastructure;
using Utility.FileLog;
using Unitilities.Object;

public class CreateProductCommandHandlerTests
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly CreateProductCommandHandler _handler;

    public CreateProductCommandHandlerTests()
    {
        // Cấu hình DbContext để sử dụng InMemoryDatabase
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDatabase") // Tên cơ sở dữ liệu trong bộ nhớ
            .Options;

        _context = new AppDbContext(options);
        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AutoMapperProfile>();
        }).CreateMapper();
        _handler = new CreateProductCommandHandler(_context, _mapper);
    }

    [Fact]
    public async Task Handle_ShouldCreateProduct()
    {
        // Arrange
        var command = new CreateProductCommand
        {
            Name = "Test Product 1",
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
        };

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result.Id > 0); // Check if ID is returned
        var product = await _context.Products.FindAsync(result.Id);
        FileLogger.WriteLog(ConvertToJson.ConvertObjectToJson(product));
        Assert.NotNull(product);
        Assert.Equal(command.Name, product.Name);
    }
}
