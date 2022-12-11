using System;
using System.Collections.Generic;

namespace StudentManagement.API.Models;

public partial class Customer
{
    public string CustomerId { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string? ContactName { get; set; }

    public string? ContactTitle { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Region { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? ParentCompanyId { get; set; }

    public virtual ICollection<Customer> InverseParentCompany { get; } = new List<Customer>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual Customer? ParentCompany { get; set; }
}
