using System;
using System.ComponentModel.DataAnnotations;

namespace Auxo.Models;

public class Parts
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Price should be greater than $1")]
    public double Price { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity should be greater than 1")]
    public int Quantity { get; set; }

}
