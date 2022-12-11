using System;
using System.Collections.Generic;

namespace StudentManagement.API.Models;

public partial class OrderDetail
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal UnitPrice { get; set; }

    public short Quantity { get; set; }

    public float Discount { get; set; }

    public string? Q2 { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
