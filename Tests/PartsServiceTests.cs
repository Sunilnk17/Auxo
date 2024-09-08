using System;
using Auxo.Models;
using Auxo.Repository;
using Auxo.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Auxo.Tests;

public class PartsServiceTests
{
    private readonly PartsService _partsService;
    private readonly ApplicationDbContext _dbContext;
    
    public PartsServiceTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _dbContext = new ApplicationDbContext(options);
        _partsService = new PartsService(_dbContext);
    }

    [Fact]
    public async Task GetParts_ShouldReturnListOfParts()
    {
        // Arrange
        _dbContext.Parts.Add(new Parts { Description = "Bolt", Price = 10, Quantity = 100 });
        _dbContext.Parts.Add(new Parts { Description = "Nut", Price = 0.99, Quantity = 200 });
        await _dbContext.SaveChangesAsync();

        // Act
        var result = await _partsService.GetParts();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
    }
}

