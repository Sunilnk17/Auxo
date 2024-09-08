using System;
using System.ComponentModel.DataAnnotations;

namespace Auxo.Models.Dtos.Requests;

public class PartsOrderRequest
{

	[Required]
    public int Id { get; set; }

	[Required]
    public int Quantity { get; set; }

}
