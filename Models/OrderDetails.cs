using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auxo.Models;

public class OrderDetails
{
    [Key]
    public int OrderDetailsId { get; set; }

    public int PartsId { get; set; }

    [ForeignKey("PartsId")]
    public Parts Parts { get; set; }

    public int OrdersId { get; set; }

    [Required]
    public int Quantity { get; set; }
}
