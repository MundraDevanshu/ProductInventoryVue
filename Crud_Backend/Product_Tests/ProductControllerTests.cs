using Business_Layer.Dto;
using Business_Layer.Factories;
using Business_Layer.repository;
using Crud_Product_Backend.Controllers;
using Data_Layer.Entity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Tests
{
    [TestFixture]
    class ProductControllerTests
    {
        private Mock<IProductServiceFactory> _mockProductServiceFactory;
        private Mock<IProductService> _mockProductService;
        private ProductController _controller;

        [SetUp]
        public void Setup()
        {
            _mockProductService = new Mock<IProductService>();
            _mockProductServiceFactory = new Mock<IProductServiceFactory>();
            _mockProductServiceFactory.Setup(f => f.Create()).Returns(_mockProductService.Object);
            _controller = new ProductController(_mockProductServiceFactory.Object);
        }



        [Test]
        public async Task GetAll_ReturnOkObjectResult_WithListOfProductDtos()
        {
            var pageNumber = 1;
            var pageSize = 10;
            var products = new List<Product>() {
                   new Product{Id = 1,Title="Product 1" , Description="Description 1" ,Price=100},
                   new Product{Id = 2,Title="Product 2" , Description="Description 2" ,Price=200},
                   new Product{Id = 3,Title="Product 3" , Description="Description 3" ,Price=300},
            };
            int TotalCount = 3;
            var pagedProducts = new PagedResult<Product>(products, TotalCount, pageNumber, pageSize);


            _mockProductService.Setup(x => x.GetProductAsync(pageNumber, pageSize)).ReturnsAsync(pagedProducts);

            var result = await _controller.GetProducts(pageNumber, pageSize);

            Assert.AreEqual(TotalCount, result.Value.TotalCount);
            Assert.AreEqual(products, result.Value.Products);
        }

        [Test]
        public async Task GetById_WithValidId_ReturnsOkObjectResult_WithProductDto()
        {

            int itemId = 1;
            var expectedProductDto = new ProductDto { Id = itemId, Title = "Task 1", Description = "Des Task 1 ", Price = 300 };

            _mockProductService.Setup(x => x.GetProductById(itemId))
                .ReturnsAsync(expectedProductDto);

            var result = await _controller.GetProductByIdAsync(itemId);

            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okObjectResult = (OkObjectResult)result.Result;

            Assert.IsInstanceOf<ProductDto>(okObjectResult.Value);
            var actualProductDto = (ProductDto)okObjectResult.Value;

            Assert.AreEqual(expectedProductDto.Id, actualProductDto.Id);
            Assert.AreEqual(expectedProductDto.Title, actualProductDto.Title);
            Assert.AreEqual(expectedProductDto.Description, actualProductDto.Description);
            Assert.AreEqual(expectedProductDto.Price, actualProductDto.Price);
        }
        [Test]
        public async Task AddProductAsync_ReturnsCreated()
        {
            var productDto = new ProductDto {Title = "Test Product", Price = 900 };
            var product = productDto.MapToProduct();
            var createdProductDto = product.MapToProductDto();
            _mockProductService.Setup(s => s.AddProduct(productDto)).ReturnsAsync(productDto);

            var result = await _controller.AddProductAsync(productDto);

            Assert.IsInstanceOf<CreatedAtActionResult>(result.Result);
            var createdResult = (CreatedAtActionResult)result.Result;
            Assert.AreEqual(createdProductDto.Id, createdResult.RouteValues["id"]);
        }

        [Test]
        public async Task UpdateProductAsync_ReturnsOk()
        {
            var product = new ProductDto { Id = 1, Title = "Test Product", Price = 70 };
            _mockProductService.Setup(s => s.UpdateProduct(product)).ReturnsAsync(product);

            var result = await _controller.UpdateProductAsync(product.Id, product);

            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(product, okResult.Value);
        }
        [Test]
        public async Task DeleteProductAsync_ReturnsNoContent()
        {
            var productId = 1;
            var product = new ProductDto { Id = productId, Title = "Test Product", Price = 700 };
            _mockProductService.Setup(s => s.GetProductById(productId)).ReturnsAsync(product);

            var result = await _controller.DeleteProductAsync(productId);

            Assert.IsInstanceOf<NoContentResult>(result);
            _mockProductService.Verify(s => s.DeleteProduct(productId), Times.Once);
        }
       

    }
}
