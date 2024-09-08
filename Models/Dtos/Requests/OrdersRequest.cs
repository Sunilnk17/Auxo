using System;
using System.ComponentModel.DataAnnotations;

namespace Auxo.Models.Dtos.Requests;

public class OrdersRequest
{

    [Required]
    public List<PartsOrderRequest> LineItems { get; set; } = new List<PartsOrderRequest>();

}
