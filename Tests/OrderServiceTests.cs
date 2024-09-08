
using Microsoft.EntityFrameworkCore;
using Xunit;
using Auxo.Models;
using Auxo.Models.Dtos.Requests;
using Auxo.Services.Impl;
using Auxo.Repository;
namespace Auxo.Tests
{
    public class OrdersServiceTests
    {
        private readonly OrderService _orderService;
        private readonly DbContextOptions<ApplicationDbContext> _dbContextOptions;

        public OrdersServiceTests()
        {
            // Set up an in-memory database for testing
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Create a new instance of OrdersService with an in-memory database
            _orderService = new OrderService(new ApplicationDbContext(_dbContextOptions));
        }

        [Fact]
        public async Task GetOrders_ShouldReturnOrders()
        {
            // Arrange
            using (var context = new ApplicationDbContext(_dbContextOptions))
            {
                context.Orders.Add(new Orders
                {
                    OrderDate = DateTime.Now,
                    TotalItems = 5,
                    TotalAmount = 100,
                    LineItems = new List<OrderDetails>
                {
                    new OrderDetails { Quantity = 3, Parts = new Parts { Description = "Part 1", Price = 10 } },
                }
                });
                await context.SaveChangesAsync();
            }

            // Act
            var orders = await _orderService.GetOrders();

            // Assert
            Assert.NotNull(orders);
            Assert.True(orders.Any());
        }

        [Fact]
        public async Task PostOrders_ShouldCreateOrderWithDetails()
        {
            // Arrange

            var ordersRequest = new OrdersRequest
            {
                LineItems = new List<PartsOrderRequest>
            {
                new PartsOrderRequest
                {
                    Id = 1,
                    Quantity = 2
                }
            }
            };

            // Act
            var createdOrder = await _orderService.PostOrders(ordersRequest);

            // Assert
            Assert.NotNull(createdOrder);
            Assert.Equal(2, createdOrder.TotalItems);
            Assert.Equal(20.0, createdOrder.TotalAmount);
            Assert.True(createdOrder.LineItems.Any());
        }

        [Fact]
        public async Task PostOrders_ShouldThrowException_WhenPartNotFound()
        {
            // Arrange
            var ordersRequest = new OrdersRequest
            {
                LineItems = new List<PartsOrderRequest>
            {
                new PartsOrderRequest
                {
                    Id = 999, // An ID that does not exist in the database
                    Quantity = 2
                }
            }
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _orderService.PostOrders(ordersRequest));


            // Optionally, you can assert the exception message if needed
            Assert.Equal("Part not found", exception.Message);
        }
    }

}
