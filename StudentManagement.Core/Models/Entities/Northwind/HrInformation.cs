using System;
using System.Collections.Generic;

namespace StudentManagement.API.Models;

public partial class HrInformation
{
    public int EmployeeId { get; set; }

    public string? Ssn { get; set; }

    public decimal? Salary { get; set; }

    public bool? IsManager { get; set; }
}
