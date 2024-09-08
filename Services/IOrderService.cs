using System;
using Auxo.Models;
using Auxo.Models.Dtos.Requests;

namespace Auxo.Services;

public interface IOrderService
{
    Task<List<Orders>> GetOrders();

    Task<Orders> PostOrders(OrdersRequest ordersRequest);
}
