using System;

namespace Auxo.Models;

public class Orders
{

    public int Id { get; set; }

    public DateTime OrderDate { get; set; }

    public int TotalItems { get; set; }

    public double TotalAmount { get; set; }

    public List<OrderDetails> LineItems { get; set; } = new();

}
