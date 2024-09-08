using System;

namespace Auxo.Models.Dtos.Requests;

public class OrdersRequest
{

    public List<PartsOrderRequest> LineItems { get; set; } = new List<PartsOrderRequest>();

}
