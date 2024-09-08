using System;
using System.ComponentModel.DataAnnotations;

namespace Auxo.Models.Dtos.Requests;

public class PartsRequest
{
    public int Id { get; set; }

    public string Description { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Price should be greater than $1")]
    [Required(ErrorMessage = "Price is required")]
    public double Price { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Quantity should be greater than 1")]
    [Required(ErrorMessage = "Quantity is required")]
    public int Quantity { get; set; }

}
