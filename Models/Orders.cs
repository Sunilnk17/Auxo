using System;
using System.ComponentModel.DataAnnotations;

namespace Auxo.Models;

public class Orders
{

    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity should be greater than 1")]
    public int TotalItems { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Total Amount should be greater than $1")]
    public double TotalAmount { get; set; }

    [Required]
    public List<OrderDetails> LineItems { get; set; } = new();

}
