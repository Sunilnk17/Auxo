using System;

namespace Auxo.Models.Dtos.Responses;

public class OrderDetailsResponse
{

    public int OrderDetailsId { get; set; }

    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }

    public PartsOrderResponse Part { get; set; } = new();

}
