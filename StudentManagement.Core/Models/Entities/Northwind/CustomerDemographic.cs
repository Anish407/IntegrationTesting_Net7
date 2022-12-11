using System;
using System.Collections.Generic;

namespace StudentManagement.API.Models;

public partial class CustomerDemographic
{
    public string CustomerTypeId { get; set; } = null!;

    public string? CustomerDesc { get; set; }

    public virtual ICollection<CustomerCustomerDemo> CustomerCustomerDemos { get; } = new List<CustomerCustomerDemo>();
}
