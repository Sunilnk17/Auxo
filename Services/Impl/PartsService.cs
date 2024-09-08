using System;
using Auxo.Models;
using Auxo.Models.Dtos.Requests;
using Auxo.Repository;
using Microsoft.EntityFrameworkCore;

namespace Auxo.Services;

public class PartsService : IPartsService
{
    public readonly ApplicationDbContext _dbContext;

    public PartsService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Parts>> GetParts()
    {
        return await _dbContext.Parts.ToListAsync();
    }

    public async Task<Parts> PostParts(PartsRequest partsRequest)
    {
        // Check if a part with the same description, price, and quantity already exists
        Parts partsFromDB = await _dbContext.Parts
            .Where(p => p.Description == partsRequest.Description &&
                        p.Price == partsRequest.Price &&
                        p.Quantity == partsRequest.Quantity)
            .FirstOrDefaultAsync();

        if (partsFromDB == null)
        {
            // If not found, create a new part
            Parts parts = new()
            {
                Description = partsRequest.Description,
                Price = partsRequest.Price,
                Quantity = partsRequest.Quantity
            };

            // Add the new part to the database
            _dbContext.Parts.Add(parts);
            await _dbContext.SaveChangesAsync();

            return parts;
        }
        else
        {
            throw new Exception("Part already exists");
        }
    }
}
