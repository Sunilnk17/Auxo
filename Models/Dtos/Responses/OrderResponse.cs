using System;

namespace Auxo.Models.Dtos.Responses;

public class OrderResponse
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }

    public int TotalItems { get; set; }

    public double TotalAmount { get; set; }

    public List<OrderDetailsResponse> LineItems { get; set; } = new();

}
