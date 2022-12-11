using System;
using System.Collections.Generic;

namespace StudentManagement.API.Models;

public partial class EmployeeHistory
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string Address { get; set; } = null!;

    public decimal AnnualSalary { get; set; }

    public DateTime ValidFrom { get; set; }

    public DateTime ValidTo { get; set; }
}
