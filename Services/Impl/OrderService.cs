using System;
using System.Net;
using Auxo.Models;
using Auxo.Models.Dtos.Requests;
using Auxo.Models.Dtos.Responses;
using Auxo.Repository;
using Microsoft.EntityFrameworkCore;

namespace Auxo.Services.Impl;

public class OrderService : IOrderService
{
    public readonly ApplicationDbContext _dbContext;
    public OrderService(ApplicationDbContext _dbContext)
    {
        this._dbContext = _dbContext;
    }

    public Task<List<Orders>> GetOrders()
    {

        try
        {
            var orders = _dbContext.Orders.Include(o => o.LineItems)
                            .ThenInclude(l => l.Parts)
                                .OrderByDescending(o => o.OrderDate).ToListAsync();

            return orders;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Orders> PostOrders(OrdersRequest ordersRequest)
    {
        try
        {
            Orders order = new()
            {
                OrderDate = DateTime.Now
            };

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            foreach (var item in ordersRequest.LineItems)
            {
                OrderDetails orderDetails = new()
                {
                    OrdersId = order.Id,
                    PartsId = item.Id,
                    Quantity = item.Quantity,
                };

                var part = _dbContext.Parts.FirstOrDefault(p => p.Id == item.Id) ?? throw new Exception("Part not found");
                order.TotalItems += item.Quantity;
                order.TotalAmount += part.Price * item.Quantity;
                order.LineItems.Add(orderDetails);
            }

            _dbContext.SaveChanges();


            var orderWithDetails = _dbContext.Orders.Include(o => o.LineItems)
                                .ThenInclude(od => od.Parts)
                                    .FirstOrDefault(o => o.Id == order.Id);

            return orderWithDetails;

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

    }
}
